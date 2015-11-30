#ifndef SERIAL_PROTOCOL_INCLUDE_GUARD
#define SERIAL_PROTOCOL_INCLUDE_GUARD

#include "stdint.h"  // Defines uint8_t

// Serial protocol packet structure:
//
// Byte 0 - '$',   // Packet beginning first byte
// Byte 1 - 'M',   // Packet beginning second byte
// Byte 2 - 3      // Message length in bytes
// Byte 3 - 0      // Message type ID ( 0 - Rover / 1 - Arm )
// Byte 4 - 0      // Message byte 0  |
// Byte 5 - 10,    // Message byte 1  | - Internal message bytes
// Byte 6 - 45,    // Message byte 2  |
// Byte 7 - 37 };  // Checksum (XOR) from: ( Message length + Message type ID + Message body )

enum MSP_protocol_bytes
{
  IDLE,
  HEADER_START,
  HEADER_M,
  HEADER_SIZE,
  HEADER_MESSAGE_TYPE_ID
};

class Serial_protocol_class
{
  public:  // Code 
    Serial_protocol_class();  // Constructor

    void Handle_one_byte( uint8_t Incomming_byte );

    void Handle_message( uint8_t* Message_buffer_POINTER,  // 64 bytes buffer POINTER
                         uint8_t Message_size,
                         uint8_t Message_type_ID );

  public:  // Data
    static const uint8_t MESSAGE_BUFFER_SIZE = 64;

  private:  // Data
    MSP_protocol_bytes State;
    
    uint8_t Message_buffer[ MESSAGE_BUFFER_SIZE ];
    uint8_t Message_buffer_offset;
    uint8_t Message_size;
    uint8_t Message_type_ID;
    uint8_t Checksum;
};

#endif  // SERIAL_PROTOCOL_INCLUDE_GUARD
