#ifndef ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD
#define ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD

#include "stdint.h"  // Defines uint8_t

// Rover driving message structure:
//
// Byte 0 - Rover driving command - [ 1..2 ]
// Byte 1 - Rover turn angle [ 0..180 ]
// Byte 2 - Rover speed - [ 0..255 ]

namespace Rover_driving_message_handler
{
  // Message constants ----------------------------------------------------------------------------------------------------
  const uint8_t ROVER_DRIVING_MESSAGE_LENGTH = 3;  // In bytes
  const uint8_t ROVER_DRIVING_MESSAGE_TYPE_ID = 0;

  const uint8_t ROVER_DRIVING_COMMAND_STOP = 0;
  const uint8_t ROVER_DRIVING_COMMAND_FORWARD = 1;
  const uint8_t ROVER_DRIVING_COMMAND_BACKWARD = 2;

  // Turn constants -------------------------------------------------------------------------------------------------------
  // 0 - Max right    180 - Max left 
  const int SERVO_CENTER_ANGLE = 102;  // [0..180]  Degrees

  const int SERVO_MIN_ANGLE = 54; // Degrees
  const int SERVO_MAX_ANGLE = 156; // Degrees
  
  // Drive constants ------------------------------------------------------------------------------------------------------
  // MAX rover speed threshold
  const int MAX_ROVER_SPEED = 255;  // [0..255]
  
  // Code -----------------------------------------------------------------------------------------------------------------
  void Handle_rover_driving_message( uint8_t* Message_buffer_POINTER,
                                     uint8_t Message_size,
                                     uint8_t Message_type_ID );

  void Turn( bool* An_error_has_occured_POINTER,
             uint8_t* Message_buffer_POINTER  );
             
  void Drive(  bool* An_error_has_occured_POINTER,
               uint8_t* Message_buffer_POINTER  );
}

#endif  // ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD









































