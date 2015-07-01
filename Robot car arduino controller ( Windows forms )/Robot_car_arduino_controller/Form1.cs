using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot_car_arduino_controller
{
  public partial class Form1 : Form
  {
    const string Default_com_port_name = "COM5";
    const int Send_command_to_arduino_interval = 10;  // In milliseconds

    const int Joystick_center_X = 175;
    const int Joystick_center_Y = 175;

    const int Min_X = Joystick_center_X - 150;
    const int Max_X = Joystick_center_X + 150;
    const int Min_Y = Joystick_center_Y - 150;
    const int Max_Y = Joystick_center_Y + 150;

    private Com_port_class Com_port = null;

    public Form1()
    {
      InitializeComponent();

      Com_port_name_text_box.Text = Default_com_port_name;
      Center_the_joystick();
    }

    string Get_joystick_command_string()
    {
      string Moving_speed = Math.Abs( Joystick_Y ).ToString("00");

      string Moving_direction = "S";  // Stop

      if( Joystick_Y < 0 )
      {
        Moving_direction = "F";  // Forward
      }

      if( Joystick_Y > 0 )
      {
        Moving_direction = "B";  // Backward
      }

      string Turn_angle = Math.Abs( Joystick_X ).ToString("00");

      string Turn_direction = "L";  // Left

      if( Joystick_X > 0 )
      {
        Turn_direction = "R";  // Right
      }

      // Something like: "L00S00"
      string Arduino_robot_car_command =
        Turn_direction +
        Turn_angle +
        Moving_direction +
        Moving_speed;

      return Arduino_robot_car_command;
    }

    // -99 .. +99
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

    // -99 .. +99
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

    private void panel1_Paint( object sender, PaintEventArgs e )
    {
      e.Graphics.DrawLine( Pens.Black, 150, 0, 150, 300 );
      e.Graphics.DrawLine( Pens.Black, 0, 150, 300, 150 );
    }

    private void button2_Click( object sender, EventArgs e )
    {
      Center_the_joystick();

      //if( Com_port != null )
      //{
      //  Com_port.Write( Get_joystick_command_string() );
      //}
    }

    void Center_the_joystick()
    {
      Joystick_button.Location = new System.Drawing.Point( Joystick_center_X, Joystick_center_Y );
      Update_joystick_coordinates_text_on_the_screen();
    }

    private void Joystick_button_Click( object sender, EventArgs e )
    {

    }

    private Point MouseDownLocation;

    private void Joystick_button_MouseDown( object sender, MouseEventArgs e )
    {
      if( e.Button == System.Windows.Forms.MouseButtons.Left )
      {
        MouseDownLocation = e.Location;
      }
    }

    private void Joystick_button_MouseMove( object sender, MouseEventArgs e )
    {
      if( e.Button == System.Windows.Forms.MouseButtons.Left )
      {
        int New_left = e.X + Joystick_button.Left - MouseDownLocation.X;
        int New_top = e.Y + Joystick_button.Top - MouseDownLocation.Y;

        // X
        if( New_left < Min_X )
        {
          New_left = Min_X;
        }
        else
        {
          if( New_left > Max_X )
          {
            New_left = Max_X;
          }
        }

        // Y
        if( New_top < Min_Y )
        {
          New_top = Min_Y;
        }
        else
        {
          if( New_top > Max_Y )
          {
            New_top = Max_Y;
          }
        }

        Joystick_button.Left = New_left;
        Joystick_button.Top = New_top;

        Joystick_button.Invalidate();
        Update_joystick_coordinates_text_on_the_screen();

        //if( Com_port != null )
        //{
        //  Com_port.Write( Get_joystick_command_string() );
        //}

        Joystick_button.Invalidate();
      }
    }

    void Update_joystick_coordinates_text_on_the_screen()
    {
      label1.Text = "X = " + Joystick_X.ToString();
      label2.Text = "Y = " + Joystick_Y.ToString();
      label3.Text = "Joystick command: \"" + Get_joystick_command_string() + "\"";
    }

    private void Joystick_button_MouseUp( object sender, MouseEventArgs e )
    {
      if( checkBox1.Checked )
      {
        Center_the_joystick();
      }
    }

    private void checkBox1_CheckedChanged( object sender, EventArgs e )
    {
      Center_the_joystick();
    }

    private void Open_the_com_port_button_Click( object sender, EventArgs e )
    {
      try
      {
        string Com_port_name = Com_port_name_text_box.Text;

        Com_port = new Com_port_class( Com_port_name );
        MessageBox.Show( "COM port \"" + Com_port_name  + "\" has been opened successfully." );

        timer1.Interval = Send_command_to_arduino_interval;
        timer1.Enabled = true;
        timer1.Start();

        //if( Com_port != null )
        //{
        //  Com_port.Write( Get_joystick_command_string() );
        //}
      }
      catch( Exception Ex )
      {
        Com_port = null;
        MessageBox.Show( Ex.Message );
      }
    }

    private void timer1_Tick( object sender, EventArgs e )
    {
      if( Com_port != null )
      {
        Com_port.Write( Get_joystick_command_string() );
      }
    }
  }
}