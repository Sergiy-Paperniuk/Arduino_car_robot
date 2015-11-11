class Communication_protocol
{
  private:
    // Constants --------------------------------------------------------------------
    static const unsigned int PACKET_BUFFER_SIZE = 256;  // In bytes
    static const unsigned int VALID_PACKET_MINIMAL_SIZE = 16;  // In bytes
  
    static const unsigned int PACKET_HEADER_SIZE = 16;  // In bytes
  
    // Packet header offsets:
    static const unsigned int HEADER_CRC32_OFFSET = 4;  // In bytes
    static const unsigned int HEADER_COMMAND_SIZE_OFFSET = 8;  // In bytes
    static const unsigned int HEADER_COMMAND_TYPE_OFFSET = 12;  // In bytes
    static const unsigned int HEADER_COMMAND_OFFSET = 16;  // In bytes
  
    // Variables --------------------------------------------------------------------

    static unsigned char Packet_buffer[ PACKET_BUFFER_SIZE ];
  
    static unsigned int First_packet_byte_number;
    static unsigned int After_last_packet_byte_number;
  
    // ------------------------------------------------------------------------------
  
  public: 
    inline static void Init()
    {
      First_packet_byte_number = 0;
      After_last_packet_byte_number = 0;
      
      for( int i = 0; i < PACKET_BUFFER_SIZE; i++ )
      {
        Packet_buffer[i] = 0;
      }
    }
  
  private:
    inline static void Put_one_byte( unsigned char Incoming_byte )
    {
      if( After_last_packet_byte_number == PACKET_BUFFER_SIZE )
      {
        for( int i = 0; i < (PACKET_BUFFER_SIZE - 2); i++ )  // Shift all buffer bytes on one step left
        {
          Packet_buffer[i] = Packet_buffer[ i + 1 ];
        }
        
        Packet_buffer[ PACKET_BUFFER_SIZE - 1 ] = Incoming_byte;  // Put the incoming byte into the last buffer array cell
      }
      else
      {
        Packet_buffer[ After_last_packet_byte_number ] = Incoming_byte;
        After_last_packet_byte_number++;
      }
    }
    
    inline static unsigned int The_current_packet_size()
    {
      return After_last_packet_byte_number - First_packet_byte_number;
    }
    
    inline static bool The_packet_buffer_starts_with_ABCD_magic_word()
    {
      // The valid command always starts with the "ABCD" magic word
      return( ( Packet_buffer[0] == 'A' ) &&
              ( Packet_buffer[1] == 'B' ) &&
              ( Packet_buffer[2] == 'C' ) &&
              ( Packet_buffer[3] == 'D' ) );
    }
    
    inline static bool The_command_size_is_OK()
    {
      unsigned long Command_size_from_packet_header = * ( reinterpret_cast< unsigned long* >( Packet_buffer + HEADER_COMMAND_SIZE_OFFSET ) );
      signed long Actual_command_size = ((unsigned long)The_current_packet_size) - ((unsigned long)PACKET_HEADER_SIZE);
      
      return( Actual_command_size == Command_size_from_packet_header );  // Returns a boolean value
    }
    
    inline static bool The_command_CRC32_is_OK()
    {
      int Actual_command_size = The_current_packet_size() - PACKET_HEADER_SIZE;
      unsigned char* Command_size_first_byte_POINTER = Packet_buffer + HEADER_COMMAND_SIZE_OFFSET;
      unsigned long CRC32_from_command_header =  * ( reinterpret_cast< unsigned long* >( Packet_buffer + HEADER_CRC32_OFFSET ) );
      
      unsigned long Actual_CRC32 = 0;
      Actual_CRC32 = GetCRC32( Command_size_first_byte_POINTER, Actual_command_size + 8  );  // ( Command size - 4 bytes ) + ( Command type - 4 bytes ) ---> 8
      
      return( Actual_CRC32 == CRC32_from_command_header );  // Returns a boolean value
    }
    
    inline static bool The_packet_buffer_contains_a_valid_command()
    {
      if( The_current_packet_size() >= VALID_PACKET_MINIMAL_SIZE )
      {
        if( The_packet_buffer_starts_with_ABCD_magic_word() )  // The valid command always starts with the "ABCD" magic word
        {
          if( The_command_size_is_OK() )
          {
            if( The_command_CRC32_is_OK() )
            {
              return true;  // Packet buffer CONTAINS a valid command           
            }           
          }
        }
      }

      return false;  // Packet buffer DOES NOT contain a valid command
    }
    
    // true - there is a command / false - NO command
    inline static bool Get_command( unsigned long Command_type, 
                                    unsigned char* Command_first_byte_POINTER,
                                    unsigned long Command_size )
    {
      if( The_packet_buffer_contains_a_valid_command )
      {
        Command_type = * ( reinterpret_cast< unsigned long* >( Packet_buffer + HEADER_COMMAND_TYPE_OFFSET ) );
        
        Command_first_byte_POINTER = Packet_buffer + HEADER_COMMAND_OFFSET;
        Command_size = * ( reinterpret_cast< unsigned long* >( Packet_buffer + HEADER_COMMAND_SIZE_OFFSET ) );
       
        return true;  // Packet buffer CONTAINS a valid command
      }

      return false;  // Packet buffer DOES NOT contain a valid command
    }
};


















































