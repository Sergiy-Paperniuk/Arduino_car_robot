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

    // [ -99 .. +99 ]
    public int Joystick_X
    {
      get
      {
        int X = Joystick_button.Location.X - Joystick_center_X;

        X = (int)( (float)X / 150 * 100 );

        if( X < -99 )
        {
          X = -99;
        }
        else
        {
          if( X > 99 )
          {
            X = 99;
          }
        }

        return X;
      }
    }

    // [ -99 .. +99 ]
    public int Joystick_Y
    {
      get
      {
        int Y = Joystick_button.Location.Y - Joystick_center_Y;

        Y = (int)( (float)Y / 150 * 100 );

        if( Y < -99 )
        {
          Y = -99;
        }
        else
        {
          if( Y > 99 )
          {
            Y = 99;
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

    public string Get_joystick_command_string()
    {
      string Moving_speed = Math.Abs( Joystick_Y ).ToString( "00" );
      string Moving_direction = "S";  // Stop

      if( Joystick_Y < 0 )
      {
        Moving_direction = "F";  // Forward
      }

      if( Joystick_Y > 0 )
      {
        Moving_direction = "B";  // Backward
      }

      string Turn_angle = Math.Abs( Joystick_X ).ToString( "00" );
      string Turn_direction = "L";  // Left

      if( Joystick_X > 0 )
      {
        Turn_direction = "R";  // Right
      }

      // Something like: "L00S00"
      string Arduino_robot_car_command =
        "W" +
        Turn_direction +
        Turn_angle +
        Moving_direction +
        Moving_speed;

      return Arduino_robot_car_command;
    }
  }
}