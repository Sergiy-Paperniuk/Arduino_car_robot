// Protocol.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "stdint.h"

#include "Serial_protocol.h"

Serial_protocol_class Serial_protocol;

uint8_t Current_byte_number = 0;
const uint8_t TEST_PACKET_1_SIZE = 12;
const uint8_t TEST_PACKET_2_SIZE = 6;

uint8_t Read_one_byte_for_test_1()
{
  uint8_t Test_packet[TEST_PACKET_1_SIZE]{ '$','M',  // "$M" - packet beginning
                                           '<',   // ('<' - to Aduino) - ('>' - from Adruino)
                                           6,     // Command length
                                           0,     // Command type ID ( 0 - Rover / 1 - Arm )
                                           'F',   // Move forward ( 'F' - Forward / 'S' - Stop / 'B' - Backward )
                                           0,     // Speed - first digit
                                           0,     // Speed - second digit
                                           'R',   // Turn right
                                           4,     // Turn - first digit  (45 degrees)
                                           5,     // Turn - second digit (45 degrees)
                                           19 };  // Checksum (XOR) from: ( Command length + Command type ID + Command )

  uint8_t Outcomming_byte = Test_packet[ Current_byte_number ];
  Current_byte_number++;  // To return the next byte

  return Outcomming_byte;
}

uint8_t Read_one_byte_for_test_2()
{
  uint8_t Test_paket_2[TEST_PACKET_2_SIZE]{ '$','M',  // "$M" - packet beginning
                                            '<',   // ('<' - to Aduino) - ('>' - from Adruino)
                                             0,     // Command length
                                             2,     // Command type ID ( 0 - Rover / 1 - Arm )
                                             2 };  // Checksum (XOR) from: ( Command length + Command type ID + Command )

  uint8_t Outcomming_byte = Test_paket_2[Current_byte_number];
  Current_byte_number++;  // To return the next byte

  return Outcomming_byte;
}

void Test_1()  // Handle simple rover command
{
  Current_byte_number = 0;

  for( uint8_t i = 0; i < TEST_PACKET_1_SIZE; i++ )
  {
    uint8_t Incomming_byte = Read_one_byte_for_test_1();
    Serial_protocol.Handle_one_byte( Incomming_byte );
  }
}

void Test_2()  // Test 2 - Handle command with zero length
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