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
  const uint8_t ROVER_DRIVING_MESSAGE_LENGTH = 3;  // In bytes
  const uint8_t ROVER_DRIVING_MESSAGE_TYPE_ID = 0;

  const uint8_t ROVER_DRIVING_COMMAND_STOP = 0;
  const uint8_t ROVER_DRIVING_COMMAND_FORWARD = 1;
  const uint8_t ROVER_DRIVING_COMMAND_BACKWARD = 2;
}

#endif  // ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD