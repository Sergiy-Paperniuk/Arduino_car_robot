#include <Servo.h>

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

const char LEFT = 'L';
const char RIGHT = 'R';

const char FORWARD = 'F';
const char STOP = 'S';
const char BACKWARD = 'B';

Servo RobotSteeringServo;

const unsigned char COMMAND_SIZE = 6;
char Comand_bytes_array[ COMMAND_SIZE ] = { 'L', '0', '0', 'S', '0', '0' };

// 0 - Max right    180 - Max left 
const int SERVO_ABSOLUTE_CENTER_ANGLE = 102;  // [0..180]  Degrees

const int SERVO_MAX_LEFT_ANGLE_SHIFT_FROM_THE_CENTER = 54;  // Degrees
const int SERVO_MAX_RIGHT_ANGLE_SHIFT_FROM_THE_CENTER = 48;  // Degrees

const int SERVO_ABSOLUTE_MIN_ANGLE = 
          SERVO_ABSOLUTE_CENTER_ANGLE -                 // Turn rigth
          SERVO_MAX_RIGHT_ANGLE_SHIFT_FROM_THE_CENTER;  // = 102 - 48 = 54  Degrees
  
const int SERVO_ABSOLUTE_MAX_ANGLE = 
          SERVO_ABSOLUTE_CENTER_ANGLE +                // Turn left
          SERVO_MAX_LEFT_ANGLE_SHIFT_FROM_THE_CENTER;  // = 102 + 54 = 156  Degrees
          
// MAX rorot speed threshold
const int ABSOLUTE_MAX_SPEED = 255; // [0..255]

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
  RobotSteeringServo.write( SERVO_ABSOLUTE_CENTER_ANGLE );
  
  Serial.begin( 9600 );
}

unsigned char I = 0;

void loop()
{
  if ( Serial.available() > 0 ) 
  {
    Comand_bytes_array[I] = Serial.read();
    I++;
    
    if( I == COMMAND_SIZE )
    {
      I = 0;
      Execute_command();
    }
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

bool An_error_has_occured = false;

void Execute_command() {
  Turn( & An_error_has_occured );
  Drive( & An_error_has_occured );
}

// '0' ---> 0        '9' ---> 9
unsigned char OneSymbolToByte( char Symbol, bool* An_error_has_occured_POINTER )
{
  switch( Symbol )
  {
    case '0' : return 0;
    case '1' : return 1;
    case '2' : return 2;
    case '3' : return 3;
    case '4' : return 4;
    case '5' : return 5;
    case '6' : return 6;
    case '7' : return 7;
    case '8' : return 8;
    case '9' : return 9;
    
    default :
      * An_error_has_occured_POINTER = true;  // Error
      return 0;  // Error
  }
}

// '0' '0'  ---> 0        '9' '9' ----> 99
unsigned char TwoSymbolsToByte( char First_symbol, 
                                char Second_symbol, 
                                bool* An_error_has_occured_POINTER )
{
  return 10 * OneSymbolToByte( First_symbol, An_error_has_occured_POINTER ) + 
              OneSymbolToByte( Second_symbol, An_error_has_occured_POINTER );
}

void Turn( bool* An_error_has_occured_POINTER )
{
  unsigned char Input_turn_angle = 
    TwoSymbolsToByte( Comand_bytes_array[1], 
                      Comand_bytes_array[2],
                      An_error_has_occured_POINTER );
                    
  unsigned long Servo_absolute_turn_angle;
                      
  switch( Comand_bytes_array[0] )
  {
    case LEFT :
      Servo_absolute_turn_angle = SERVO_ABSOLUTE_CENTER_ANGLE + 
      SERVO_MAX_LEFT_ANGLE_SHIFT_FROM_THE_CENTER * Input_turn_angle / 99 ;
    break;
   
    case RIGHT :
      Servo_absolute_turn_angle = SERVO_ABSOLUTE_CENTER_ANGLE - 
      SERVO_MAX_RIGHT_ANGLE_SHIFT_FROM_THE_CENTER * Input_turn_angle / 99 ;
    break;
   
    default :  // Error
      Servo_absolute_turn_angle = SERVO_ABSOLUTE_CENTER_ANGLE;
      * An_error_has_occured_POINTER = true;  // Error
  }
                
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

void Drive( bool* An_error_has_occured_POINTER ) 
{
  unsigned char Input_speed = 
    TwoSymbolsToByte( Comand_bytes_array[4], 
                      Comand_bytes_array[5],
                      An_error_has_occured_POINTER );
                    
  // Absolute speed [0..255]
  unsigned long Absolute_speed = 255 * Input_speed / 99 ;
  
  // MAX rorot speed threshold
  if( Absolute_speed > ABSOLUTE_MAX_SPEED )
  {
    Absolute_speed = ABSOLUTE_MAX_SPEED;
  }

  switch( Comand_bytes_array[ 3 ] )
  {
   case FORWARD :
     // [0..255]
     analogWrite( ENA_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, HIGH );
     digitalWrite( IN3_PIN, HIGH );
     digitalWrite( IN4_PIN, LOW );
     analogWrite( ENB_PIN, (int)Absolute_speed );  // PWM - Absolute speed [0..255]
   break;
  
   case STOP :
     // [0..255]
     analogWrite( ENA_PIN, 0 );  // PWM - Absolute speed [0..255]
     digitalWrite( IN1_PIN, LOW );
     digitalWrite( IN2_PIN, LOW );
     digitalWrite( IN3_PIN, LOW );
     digitalWrite( IN4_PIN, LOW );
     analogWrite( ENB_PIN, 0 );  // PWM - Absolute speed [0..255]
   break;
   
   case BACKWARD :
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

















