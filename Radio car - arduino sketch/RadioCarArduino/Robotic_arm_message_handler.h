#ifndef ROBOTIC_ARM_MESSAGE_HANDLER_INCLUDE_GUARD
#define ROBOTIC_ARM_MESSAGE_HANDLER_INCLUDE_GUARD

#include "stdint.h"  // Defines uint8_t

// Robotic arm command structure:
//
// Byte 0 - Arm servo ID - [ 0..5 ]
// Byte 1 - Arm servo angle - [ 0..180 ]

namespace Robotic_arm_message_handler
{
  const uint8_t ROBOTIC_ARM_MESSAGE_LENGTH = 2;  // In bytes
  const uint8_t ROBOTIC_ARM_MESSAGE_TYPE_ID = 1;
  
  void Hanhdle_robotic_arm_message( uint8_t* Message_buffer_POINTER,
                                    uint8_t Message_size,
                                    uint8_t Message_type_ID );
}

#endif  // ROBOTIC_ARM_MESSAGE_HANDLER_INCLUDE_GUARD
