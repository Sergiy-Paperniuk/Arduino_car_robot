#include "Rover_driving_message_handler.h"

#include "wiring_private.h"
#include <Servo.h>

using namespace Rover_driving_message_handler;

// Forward declarations
extern int ENA_PIN;  // PWM ~ only !!!
extern int IN1_PIN;
extern int IN2_PIN;

extern int LED_PIN;

extern Servo RobotSteeringServo;
extern bool An_error_has_occured;
void LED_blink( unsigned int Number_of_blinks );  // Debug

void 
Rover_driving_message_handler::
Handle_rover_driving_message( uint8_t* Message_buffer_POINTER,
                              uint8_t Message_size,
                              uint8_t Message_type_ID )
{
  Turn( & An_error_has_occured, Message_buffer_POINTER );
  Drive( & An_error_has_occured, Message_buffer_POINTER );
}

void 
Rover_driving_message_handler::
Turn( bool* An_error_has_occured_POINTER,
      uint8_t* Message_buffer_POINTER )
{
  unsigned char Servo_turn_angle = Message_buffer_POINTER[ 2 ];
                      
  // MIN and MAX servo angle thresholds
  if( Servo_turn_angle < SERVO_MIN_ANGLE )
  {
    Servo_turn_angle = SERVO_MIN_ANGLE;
  }
  else
  {
    if( Servo_turn_angle > SERVO_MAX_ANGLE )
    {
      Servo_turn_angle = SERVO_MAX_ANGLE;
    }
  }

  // Servo angle: the value to write to the servo, int - from 0 to 180    
  // 0 - Max right    180 - Max left 
  RobotSteeringServo.write( (int)Servo_turn_angle );
}

void 
Rover_driving_message_handler::
Drive( bool* An_error_has_occured_POINTER,
       uint8_t* Message_buffer_POINTER )
{
  uint8_t Rover_speed = Message_buffer_POINTER[ 1 ];  // Speed [0..255]
                    
  // MAX rover speed threshold
  if( Rover_speed > MAX_ROVER_SPEED )
  {
    Rover_speed = MAX_ROVER_SPEED;
  }

  switch( Message_buffer_POINTER[ 0 ] )
  {
   case ROVER_DRIVING_COMMAND_FORWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Rover_speed );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, HIGH );

     digitalWrite( LED_PIN, HIGH );  // Debug
   break;
  
   case ROVER_DRIVING_COMMAND_BACKWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Rover_speed );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, HIGH );
     digitalWrite( IN2_PIN, LOW );

     digitalWrite( LED_PIN, LOW );  // Debug
   break;

   case ROVER_DRIVING_COMMAND_STOP :
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );

     digitalWrite( LED_PIN, LOW );  // Debug
   break;  
   
   default :  // Error
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );
     
     * An_error_has_occured_POINTER = true;  // Error
  }
}
