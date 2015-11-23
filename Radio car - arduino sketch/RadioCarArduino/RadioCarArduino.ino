#include <Servo.h>

#include "Serial_protocol.h"
#include "Rover_driving_message_handler.h"

// Pins ---------------------------------------------
const int SERVO_PIN = 12;

int ENA_PIN = 6;  // PWM ~ only !!!
int IN1_PIN = 7;
int IN2_PIN = 4;

const int LED_PIN = 13;

// Global variables ---------------------------------
bool An_error_has_occured = false;
Servo RobotSteeringServo;
Serial_protocol_class Serial_protocol;

// Code ---------------------------------------------
void setup() 
{
  pinMode( LED_PIN, OUTPUT );

  pinMode( ENA_PIN, OUTPUT );  // PWM ~ only !!!
  pinMode( IN1_PIN, OUTPUT );
  pinMode( IN2_PIN, OUTPUT );

  RobotSteeringServo.attach( SERVO_PIN );
  RobotSteeringServo.write( Rover_driving_message_handler::SERVO_CENTER_ANGLE );
  
  Serial.begin( 9600 );
}

unsigned char I = 0;

void loop()
{
  if ( Serial.available() > 0 ) 
  {
    Serial_protocol.Handle_one_byte( Serial.read() );
  }
}

// These functions are for debug
void LED_blink()
{
  digitalWrite( LED_PIN, HIGH );
  delay( 500 );
  digitalWrite( LED_PIN, LOW );
  delay( 500 );
}

void LED_blink( unsigned int Number_of_blinks ) 
{
  for( unsigned int I = 0; 
       I < Number_of_blinks; 
       I++ )
  {
    LED_blink();
  }

  delay( 1000 );
}


















































