#include "Robotic_arm_message_handler.h"

using namespace Robotic_arm_message_handler;

void 
Robotic_arm_message_handler::
Hanhdle_robotic_arm_message( uint8_t* Message_buffer_POINTER,
                             uint8_t Message_size,
                             uint8_t Message_type_ID )
{
  uint8_t Servo_ID = Message_buffer_POINTER[0];
  uint8_t Servo_angle = Message_buffer_POINTER[1];
}
