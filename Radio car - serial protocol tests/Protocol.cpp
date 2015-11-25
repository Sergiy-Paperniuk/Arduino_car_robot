#include "stdafx.h"

#include "stdint.h"  // Defines uint8_t

#include "Serial_protocol.h"
#include "Rover_driving_message_handler.h"

using namespace Rover_driving_message_handler;

Serial_protocol_class Serial_protocol;

uint8_t Current_byte_number = 0;
const uint8_t TEST_PACKET_1_SIZE = 8;
const uint8_t TEST_PACKET_2_SIZE = 5;

uint8_t Read_one_byte_for_test_1()
{
  uint8_t Test_packet[ TEST_PACKET_1_SIZE ]{ '$',
                                             'M',  // "$M" - packet beginning
                                             ROVER_DRIVING_MESSAGE_LENGTH,  // = 3
                                             ROVER_DRIVING_MESSAGE_TYPE_ID,  // Message type ID ( 0 - Rover / 1 - Arm )
                                             ROVER_DRIVING_COMMAND_FORWARD,  // Rover command    |
                                             10,    // Rover speed - [0..255]                    | - Rover driving message = 3 bytes
                                             45,    // Rover turn angle [ 0..90 ] degrees        |
                                             37 };  // Checksum (XOR) from: ( Message length + Message type ID + Message body )

  uint8_t Outcomming_byte = Test_packet[ Current_byte_number ];
  Current_byte_number++;  // To return the next byte

  return Outcomming_byte;
}

uint8_t Read_one_byte_for_test_2()
{
  uint8_t Test_paket_2[ TEST_PACKET_2_SIZE ]{ '$',
                                              'M',  // "$M" - packet beginning
                                              0,    // Message length
                                              2,    // Message type ID ( 0 - Rover / 1 - Arm )
                                              2 };  // Checksum (XOR) from: ( Message length + Message type ID + Message body )

  uint8_t Outcomming_byte = Test_paket_2[ Current_byte_number ];
  Current_byte_number++;  // To return the next byte

  return Outcomming_byte;
}

void Test_1()  // Handle simple rover driving message
{
  Current_byte_number = 0;

  for( uint8_t i = 0; i < TEST_PACKET_1_SIZE; i++ )
  {
    uint8_t Incomming_byte = Read_one_byte_for_test_1();
    Serial_protocol.Handle_one_byte( Incomming_byte );
  }
}

void Test_2()  // Test 2 - Handle message with zero length
{
  Current_byte_number = 0;

  for( uint8_t i = 0; i < TEST_PACKET_2_SIZE; i++ )
  {
    uint8_t Incomming_byte = Read_one_byte_for_test_2();
    Serial_protocol.Handle_one_byte( Incomming_byte );
  }
}

int main()
{
  Test_1();
  Test_2();

  return 0;
}