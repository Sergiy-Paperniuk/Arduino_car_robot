#include "Rover_driving_message_handler.h"

using namespace Rover_driving_message_handler;

bool An_error_has_occured = false;

void Handle_rover_driving_message( uint8_t* Message_buffer_POINTER,
                                   uint8_t Message_size,
                                   uint8_t Message_type_ID )
{
  Turn( & An_error_has_occured, Message_buffer_POINTER );
  Drive( & An_error_has_occured, Message_buffer_POINTER );
}

void Turn( bool* An_error_has_occured_POINTER,
           uint8_t* Message_buffer_POINTER )
{
  unsigned char Input_turn_angle = Message_buffer_POINTER[ 2 ];
  unsigned long Servo_absolute_turn_angle;
                      
  // MIN and MAX servo angle thresholds
  if( Servo_absolute_turn_angle < SERVO_ABSOLUTE_MIN_ANGLE )
  {
    Servo_absolute_turn_angle = SERVO_ABSOLUTE_MIN_ANGLE;
  }
  else
  {
    if( Servo_absolute_turn_angle > SERVO_ABSOLUTE_MAX_ANGLE )
    {
      Servo_absolute_turn_angle = SERVO_ABSOLUTE_MAX_ANGLE;
    }
  }

  // Servo angle: the value to write to the servo, int - from 0 to 180    
  // 0 - Max right    180 - Max left 
  RobotSteeringServo.write( (int)Servo_absolute_turn_angle );
}

void Drive( bool* An_error_has_occured_POINTER,
            uint8_t* Message_buffer_POINTER,
{
  unsigned char Input_speed = Serial_?????????????????????????
                    
  // Absolute speed [0..255]
  unsigned long Absolute_speed = 255 * Input_speed / 99 ;
  
  // MAX rorot speed threshold
  if( Absolute_speed > ABSOLUTE_MAX_SPEED )
  {
    Absolute_speed = ABSOLUTE_MAX_SPEED;
  }

  switch( Message_buffer_POINTER[ 0 ] )
  {
   case ROVER_DRIVING_COMMAND_FORWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, HIGH );
     digitalWrite( IN3_PIN, HIGH );
     digitalWrite( IN4_PIN, LOW );
     analogWrite( ENB_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
   break;
  
   case ROVER_DRIVING_COMMAND_STOP :
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );
     digitalWrite( IN3_PIN, LOW );
     digitalWrite( IN4_PIN, LOW );
     analogWrite( ENB_PIN, 0 );  // PWM - Absolute speed [0..255]
   break;
   
   case ROVER_DRIVING_COMMAND_BACKWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, HIGH );
     digitalWrite( IN2_PIN, LOW );
     digitalWrite( IN3_PIN, LOW );
     digitalWrite( IN4_PIN, HIGH );
     analogWrite( ENB_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
   break;
   
   default :  // Error
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );
     digitalWrite( IN3_PIN, LOW );
     digitalWrite( IN4_PIN, LOW );
     analogWrite( ENB_PIN, 0 );  // PWM - Absolute speed [0..255]
     
     * An_error_has_occured_POINTER = true;  // Error
  }
}
