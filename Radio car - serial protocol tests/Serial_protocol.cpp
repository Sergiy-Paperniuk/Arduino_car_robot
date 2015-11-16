#include "stdafx.h"

#include "stdint.h"

#include "Serial_protocol.h"

const uint8_t COMMAND_BUFFER_SIZE = 64;
static uint8_t Command_buffer[COMMAND_BUFFER_SIZE];
static uint8_t Checksum;
static uint8_t Command_type_ID = 0;

void Execute_command( uint8_t Command_type_ID );  // Forward declaration

uint8_t Read_one_byte()
{
  return 99;
}

enum MSP_protocol_bytes
{
  IDLE,
  HEADER_START,
  HEADER_M,
  HEADER_ARROW,
  HEADER_SIZE,
  HEADER_COMMAND_TYPE_ID
};

static MSP_protocol_bytes state = IDLE;

void Execute_next_command()
{
  uint8_t Incomming_byte;
  uint8_t cc;

  static uint8_t Command_buffer_offset;
  static uint8_t dataSize;

  Incomming_byte = Read_one_byte();

  // "$M<" - valid packet start
  if( state == IDLE )
  {
    if( Incomming_byte == '$' )  // Packet starts from the '$' byte
    {
      state = HEADER_START;
    }
  }
  else
  {
    if( state == HEADER_START )
    {
      if( Incomming_byte == 'M' )
      {
        state = HEADER_M;
      }
      else
      {
        state = IDLE;  // It's not 'M' - skip this byte
      }
    }
    else
    {
      if( state == HEADER_M )
      {
        if( Incomming_byte == '<' )
        {
          state = HEADER_ARROW;
        }
        else
        {
          state = IDLE;  // It's not '<' - skip this byte
        }
      }
      else
      {
        if( state == HEADER_ARROW )
        {
          if( Incomming_byte > COMMAND_BUFFER_SIZE )  // Command size is too big (Command size > 64 bytes) ---> Error
          {
            state = IDLE;
            return;
          }

          dataSize = Incomming_byte;
          Checksum = Incomming_byte;  // Init checksum
          Command_buffer_offset = 0;  // Init command buffer offset

          state = HEADER_SIZE;
        }
        else
        {
          if( state == HEADER_SIZE )
          {
            Command_type_ID = Incomming_byte;  // Read the command type ID
            Checksum ^= Incomming_byte;  // Update checksum  ( XOR )

            state = HEADER_COMMAND_TYPE_ID;
          }
          else
          {
            if( state == HEADER_COMMAND_TYPE_ID )
            {
              if( Command_buffer_offset < dataSize )
              {
                Checksum ^= Incomming_byte;  // Update checksum  ( XOR )
                Command_buffer[ Command_buffer_offset ] = Incomming_byte;  // Copy one byte to the command buffer
                Command_buffer_offset++;
              }
              else
              {
                if( Checksum == Incomming_byte )  // The last packet byte is a checksum. Compare calculated and transferred checksum.
                {
                  Execute_command( Command_type_ID );  // The checksum is OK. We got a valid command. Execute it.
                }

                state = IDLE;
                cc = 0;  // no more than one MSP per port and per cycle
              }
            }
          }
        }
      }
    }
  }
}

void Execute_command( uint8_t Command_type_ID )
{
  return;
}