#ifndef ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD
#define ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD

#include "stdint.h"

// Rover driving command structure:
//
// Byte 0 - Rover driving command - [ 0..5 ]
// Byte 1 - Rover speed - [ 0..255 ]
// Byte 2 - Rover turn angle [ 0..90 ]

const uint8_t ROVER_DRIVING_MESSAGE_LENGTH = 3;  // In bytes
const uint8_t ROVER_DRIVING_MESSAGE_TYPE_ID = 0;

namespace Rover_driving_message_handler
{
  const uint8_t ROVER_DRIVING_COMMAND_STOP_RIGHT = 0;
  const uint8_t ROVER_DRIVING_COMMAND_FORWARD_RIGHT = 1;
  const uint8_t ROVER_DRIVING_COMMAND_BACKWARD_RIGHT = 2;
  const uint8_t ROVER_DRIVING_COMMAND_STOP_LEFT = 3;
  const uint8_t ROVER_DRIVING_COMMAND_FORWARD_LEFT = 4;
  const uint8_t ROVER_DRIVING_COMMAND_BACKWARD_LEFT = 5;
}

#endif  // ROVER_DRIVING_MESSAGE_HANDLER_INCLUDE_GUARD