using System;
using System.Drawing;
using System.Windows.Forms;

namespace Robot_car_arduino_controller
{
  class Joystick_controller_class
  {
    private Button Joystick_button;  // Joystick handle which we move by mouse. Actually it's a simple UI button.

    private const int Joystick_center_X = 175;  // In pixels
    private const int Joystick_center_Y = 175;  // In pixels

    private const int Joystick_max_shift_X = 150;  // In pixels
    private const int Joystick_max_shift_Y = 150;  // In pixels

    private const int Joystick_min_X = Joystick_center_X - Joystick_max_shift_X;  // In pixels
    private const int Joystick_max_X = Joystick_center_X + Joystick_max_shift_X;  // In pixels
    private const int Joystick_min_Y = Joystick_center_Y - Joystick_max_shift_Y;  // In pixels
    private const int Joystick_max_Y = Joystick_center_Y + Joystick_max_shift_Y;  // In pixels

    public Joystick_controller_class( Button Joystick_button )  // Constructor
    {
      this.Joystick_button = Joystick_button;
      Center_the_joystick();
    }

    // [ -255 .. +255 ]
    public int Joystick_X
    {
      get
      {
        int X = Joystick_button.Location.X - Joystick_center_X;

        X = (int)( (float)X / 150 * 255 );

        if( X < -255 )
        {
          X = -255;
        }
        else
        {
          if( X > 255 )
          {
            X = 255;
          }
        }

        return X;
      }
    }

    // [ -255 .. +255 ]
    public int Joystick_Y
    {
      get
      {
        int Y = Joystick_button.Location.Y - Joystick_center_Y;

        Y = (int)( (float)Y / 150 * 255 );

        if( Y < -255 )
        {
          Y = -255;
        }
        else
        {
          if( Y > 255 )
          {
            Y = 255;
          }
        }

        return Y;
      }
    }

    public void Shift_left( int Shift_value )  // In pixels
    {
      int New_left = Joystick_button.Left - Shift_value;
      int New_top = Joystick_button.Top;

      Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
    }

    public void Shift_right( int Shift_value )  // In pixels
    {

      int New_left = Joystick_button.Left + Shift_value;
      int New_top = Joystick_button.Top;

      Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
    }

    public void Shift_max_front()  // In pixels
    {

      int New_left = Joystick_button.Left;
      const int New_top = Joystick_min_Y;

      Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
    }

    public void Shift_max_back()  // In pixels
    {
      int New_left = Joystick_button.Left;
      const int New_top = Joystick_max_Y;

      Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
    }

    public void Center_the_joystick()
    {
      Joystick_button.Location = new Point( Joystick_center_X, Joystick_center_Y );
    }

    public void Center_the_joystick_y_axis()
    {
      int New_left = Joystick_button.Left;
      const int New_top = Joystick_center_Y;

      Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
    }

    public void Set_new_joystick_button_coordinates( int New_left, int New_top )  // In pixels
    {
      // X
      if( New_left < Joystick_min_X )
      {
        New_left = Joystick_min_X;
      }
      else
      {
        if( New_left > Joystick_max_X )
        {
          New_left = Joystick_max_X;
        }
      }

      // Y
      if( New_top < Joystick_min_Y )
      {
        New_top = Joystick_min_Y;
      }
      else
      {
        if( New_top > Joystick_max_Y )
        {
          New_top = Joystick_max_Y;
        }
      }

      Joystick_button.Left = New_left;
      Joystick_button.Top = New_top;
    }


    private byte Get_rover_turn_angle()  //  [0..180]
    {
      const long MIN_TURN_ANGLE = 0;
      const long MAX_TURN_ANGLE = 180;

      long Turn_angle = 255 - Joystick_X;  // [0..510]

      Turn_angle = (Turn_angle * 180) / 510;  // [0..180]

      if( Turn_angle < MIN_TURN_ANGLE )
      {
        Turn_angle = MIN_TURN_ANGLE;
      }
      else
      {
        if( Turn_angle > MAX_TURN_ANGLE )
        {
          Turn_angle = MAX_TURN_ANGLE;
        }
      }

      return (byte)Turn_angle;  // [MIN_TURN_ANGLE..MAX_TURN_ANGLE] == [0..180]
    }

    public byte[] Get_rover_driving_command_bytes_array()
    {
      const byte STOP = 0;
      const byte FORWARD = 1;
      const byte BACKWARD = 2;

      byte Moving_speed = (byte)(Math.Abs( Joystick_Y ));  // [0..255]
      byte Moving_direction = STOP;  // 0

      if( Joystick_Y < 0 )
      {
        Moving_direction = FORWARD;  // 1
      }

      if( Joystick_Y > 0 )
      {
        Moving_direction = BACKWARD;  // 2
      }

      byte Turn_angle = Get_rover_turn_angle();  // [0..180]

      byte[] Rover_driving_command = { /* 0 */ 0x24,  // '$'
                                       /* 1 */ 0x4D,  // 'M'
                                       /* 2 */ 0x03,  // 3 bytes
                                       /* 3 */ 0x00,  // Message type = Rover driving
                                       /* 4 */ Moving_direction,
                                       /* 5 */ Moving_speed,
                                       /* 6 */ Turn_angle,
                                       /* 7 */ 0x0 };  // Checksum (XOR)

      // Calculate checksum (XOR) from bytes [2..6]
      byte checksum = 0;

      for( byte i = 2; i < 7; i++ )  // [2..6]
      {
        checksum ^= Rover_driving_command[i];  // XOR
      }

      Rover_driving_command[7] = checksum;  // Save checksum

      return Rover_driving_command;
    }
  }
}