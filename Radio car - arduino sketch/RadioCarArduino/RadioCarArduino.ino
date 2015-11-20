#include <Servo.h>

#include "Serial_protocol.h"
#include "Rover_driving_message_handler.h"

// Pins ---------------------------------------------

const int SERVO_PIN = 12;

const int ENA_PIN = 6;  // PWM ~ only !!!
const int IN1_PIN = 7;
const int IN2_PIN = 4;

const int IN3_PIN = 3;
const int IN4_PIN = 2;
const int ENB_PIN = 5;  // PWM ~ only !!!

const int LED_PIN = 13;

//---------------------------------------------------

Servo RobotSteeringServo;

Serial_protocol_class Serial_protocol;

// Code ---------------------------------------------

void setup() 
{
  pinMode( LED_PIN, OUTPUT );

  pinMode( ENA_PIN, OUTPUT );  // PWM ~ only !!!
  pinMode( IN1_PIN, OUTPUT );
  pinMode( IN2_PIN, OUTPUT );
  pinMode( IN3_PIN, OUTPUT );
  pinMode( IN4_PIN, OUTPUT );
  pinMode( ENB_PIN, OUTPUT );  // PWM ~ only !!!

  RobotSteeringServo.attach( SERVO_PIN );
  RobotSteeringServo.write( Rover_driving_message_handler::SERVO_ABSOLUTE_CENTER_ANGLE );
  
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
}



















