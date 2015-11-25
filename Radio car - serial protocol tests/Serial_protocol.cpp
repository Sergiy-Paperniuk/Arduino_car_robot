#include "stdafx.h"

#include "stdint.h"  // Defines uint8_t

#include "Serial_protocol.h"

Serial_protocol_class::Serial_protocol_class()  // Constructor
{
  State = IDLE;
}

void Serial_protocol_class::Serial_protocol_class::Handle_one_byte( uint8_t Incomming_byte )
{
  // "$M" - valid packet beginning
  switch( State )
  {
    case IDLE:
    if( Incomming_byte == '$' )  // Packet starts from the '$' byte
    {
      State = HEADER_START;
    }
    break;

    case HEADER_START:
    if( Incomming_byte == 'M' )
    {
      State = HEADER_M;
    }
    else
    {
      State = IDLE;  // It's not 'M' - skip this byte
    }
    break;

    case HEADER_M:
    if( Incomming_byte > MESSAGE_BUFFER_SIZE )  // Command size is too big (Command size > 64 bytes) ---> Error
    {
      State = IDLE;
      return;
    }

    Message_size = Incomming_byte;
    Checksum = Incomming_byte;  // Init checksum
    Message_buffer_offset = 0;  // Init message buffer offset

    State = HEADER_SIZE;
    break;

    case HEADER_SIZE:
    Message_type_ID = Incomming_byte;  // Read the message type ID
    Checksum ^= Incomming_byte;  // Update checksum  ( XOR )

    State = HEADER_MESSAGE_TYPE_ID;
    break;

    case HEADER_MESSAGE_TYPE_ID:
    if( Message_buffer_offset < Message_size )  // Continue readding message bytes
    {
      Checksum ^= Incomming_byte;  // Update checksum  ( XOR )
      Message_buffer[Message_buffer_offset] = Incomming_byte;  // Copy one byte to the message buffer
      Message_buffer_offset++;
    }
    else
    {
      if( Checksum == Incomming_byte )  // The last packet byte is a checksum. Compare calculated and transferred checksum.
      {
        Handle_message( Message_buffer, Message_size, Message_type_ID );  // The checksum is OK. We got a valid message. Handle it.
      }

      State = IDLE;  // Wait for the next message
    }
    break;
  }
}

void
Serial_protocol_class::
Handle_message( uint8_t* Message_buffer_POINTER,  // 64 bytes buffer POINTER
                uint8_t Message_size,
                uint8_t Message_type_ID )
{
  return;
}