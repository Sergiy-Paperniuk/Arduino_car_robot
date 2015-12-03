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

long Map( long X, 
          long In_min,
          long In_max, 
          long Out_min, 
          long Out_max )
{
  return (X - In_min) * (Out_max - Out_min) / (In_max - In_min) + Out_min;
}

void 
Rover_driving_message_handler::
Handle_rover_driving_message( uint8_t* Message_buffer_POINTER,
                              uint8_t Message_size,
                              uint8_t Message_type_ID )
{
  //Serial.write( "New rover driving message received:\n" );  // Debug
  
  Turn( & An_error_has_occured, Message_buffer_POINTER );
  Drive( & An_error_has_occured, Message_buffer_POINTER );
}

void 
Rover_driving_message_handler::
Turn( bool* An_error_has_occured_POINTER,
      uint8_t* Message_buffer_POINTER )
{
  unsigned char Servo_turn_angle = Message_buffer_POINTER[ 2 ];  // 0 - 40 - 80

  //Serial.write( "Input turn angle = " );  // Debug
  //Serial.print( Servo_turn_angle, DEC );  // Debug
  //Serial.write( ".\n" );                  // Debug
  
  // MIN and MAX input angle thresholds
  if( Servo_turn_angle < MIN_INPUT_ANGLE )
  {
    Servo_turn_angle = MIN_INPUT_ANGLE;
  }
  else
  {
    if( Servo_turn_angle > MAX_INPUT_ANGLE )
    {
      Servo_turn_angle = MAX_INPUT_ANGLE;
    }
  }

  // ( 0 - 40 - 80 ) ---> ( 156 - 102 - 54 )
  if( Servo_turn_angle < CENTER_INPUT_ANGLE )
  {
    // Turn left
    Servo_turn_angle = Map( Servo_turn_angle,     // X
                           MIN_INPUT_ANGLE,       // In_min  =   0
                           CENTER_INPUT_ANGLE,    // In_max  =  40
                           SERVO_MAX_ANGLE,       // Out_min = 156
                           SERVO_CENTER_ANGLE );  // Out_max = 102
  }
  else
  {
    // Turn right
    Servo_turn_angle = Map( Servo_turn_angle,    // X
                            CENTER_INPUT_ANGLE,  // In_min  =  40
                            MAX_INPUT_ANGLE,     // In_max  =  80
                            SERVO_CENTER_ANGLE,  // Out_min = 102
                            SERVO_MIN_ANGLE );   // Out_max =  54
  }

  // Absolute MIN and MAX servo angle thresholds
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

  //Serial.write( "Servo turn angle = " );  // Debug
  //Serial.print( Servo_turn_angle, DEC );  // Debug
  //Serial.write( ".\n" );                  // Debug

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

  uint8_t Driving_command = Message_buffer_POINTER[ 0 ];

  switch( Driving_command )
  {
   case ROVER_DRIVING_COMMAND_FORWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Rover_speed );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, HIGH );

     //digitalWrite( LED_PIN, HIGH );              // Debug
     //Serial.write( "Drive forward. Speed = " );  // Debug
     //Serial.print( Rover_speed, DEC );           // Debug
   break;
  
   case ROVER_DRIVING_COMMAND_BACKWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Rover_speed );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, HIGH );
     digitalWrite( IN2_PIN, LOW );

     digitalWrite( LED_PIN, LOW );                // Debug
     //Serial.write( "Drive backward. Speed = " );  // Debug
     //Serial.print( Rover_speed, DEC );            // Debug
   break;

   case ROVER_DRIVING_COMMAND_STOP :
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );

     digitalWrite( LED_PIN, LOW );  // Debug
     //Serial.write( "Stop" );       // Debug
   break;  
   
   default :  // Error
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );

     //Serial.write( "Error driving command. Command = " );  // Debug
     //Serial.print( Driving_command, DEC );                 // Debug

     * An_error_has_occured_POINTER = true;  // Error
  }

  //Serial.write( ".\n\n" );  // Debug
}
