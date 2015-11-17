#ifndef SERIAL_PROTOCOL_INCLUDE_GUARD
#define SERIAL_PROTOCOL_INCLUDE_GUARD

enum MSP_protocol_bytes
{
  IDLE,
  HEADER_START,
  HEADER_M,
  HEADER_ARROW,
  HEADER_SIZE,
  HEADER_COMMAND_TYPE_ID
};

class Serial_protocol_class
{
  public:  // Code 
    Serial_protocol_class();  // Constructor

    void Handle_one_byte( uint8_t Incomming_byte );
    void Execute_command( uint8_t Command_size, uint8_t Command_type_ID );

  public:  // Data
    static const uint8_t COMMAND_BUFFER_SIZE = 64;

  private:  // Data
    MSP_protocol_bytes State;
    
    uint8_t Command_buffer[ COMMAND_BUFFER_SIZE ];
    uint8_t Command_buffer_offset;
    uint8_t Command_size;
    uint8_t Command_type_ID;
    uint8_t Checksum;
};

#endif  // SERIAL_PROTOCOL_INCLUDE_GUARD