using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_car_arduino_controller.Proxies;

namespace Robot_car_arduino_controller
{
    public partial class Robot_car_arduino_controller_form : Form
    {
        #region Class data

        private const string ConnectButtonText = "Open the COM port";
        private const string DisconnectButtonText = "Close the COM port";

        private readonly Joystick_controller_class Joystick_controller;
        private readonly HandController m_handController;

        private const int Send_command_to_arduino_interval = 10;  // In milliseconds

        private bool Keyboard_key_left_is_pressed;  // Equals "false" by default
        private bool Keyboard_key_right_is_pressed;  // Equals "false" by default

        private Com_port_class Current_com_port;

        RadioButton[] m_servos;

        #endregion  // Class data


        #region Application entry point

        public Robot_car_arduino_controller_form()  // The main form constructor
        {
            InitializeComponent();

            m_handController = new HandController();

            Joystick_controller = new Joystick_controller_class( Joystick_button );
            Update_joystick_coordinates_text_on_the_screen();

            // Set a value indicating whether the form will receive key events before the event is passed to the control that has focus.\
            // Without this setting the joystick keyboard input will not work.
            this.KeyPreview = true;

            Disable_UI_control_focus_moving_from_the_keyboard();
            Init_timer();

            m_servos = new RadioButton[] { rbServo1, rbServo2, rbServo3, rbServo4, rbServo5 };

            InitComPortsAsync();
        }

        private async void InitComPortsAsync()
        {
            cbComPorts.Enabled = false;
            lblComPortsLoading.Visible = true;
            Open_the_com_port_button.Enabled = false;

            cbComPorts.ValueMember = "Key";
            cbComPorts.DisplayMember = "Value";

            ComPortInfo[] ports = await Com_port_class.GetComPorts();

            cbComPorts.DataSource = ports
                .Select( x => new KeyValuePair<string, string>(
                    x.Port,
                    x.Port + " - " + x.Caption
                ) )
                .ToArray();

            ComPortInfo autoValue = ports
                .FirstOrDefault( x => x.Caption.Contains( "Arduino" ) );

            if( autoValue != null )
            {
                cbComPorts.SelectedValue = autoValue.Port;
            }

            cbComPorts.Enabled = true;
            lblComPortsLoading.Visible = false;
            Open_the_com_port_button.Enabled = true;
        }

        #endregion  // Application entry point

        private void Init_timer()
        {
            Send_one_comand_timer.Interval = Send_command_to_arduino_interval;
            Send_one_comand_timer.Enabled = true;
            Send_one_comand_timer.Start();
        }

        private void Disable_UI_control_focus_moving_from_the_keyboard()
        {
            // Disable the UI control focus moving from the keyboard 
            // ( Looks dirty - try to find some better solution )

            foreach( Control control in this.Controls )
            {
                control.PreviewKeyDown += ControlPreviewKeyDown; // Add an event handler
            }
        }

        private static void ControlPreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
        {
            if( ( e.KeyCode == Keys.Up ) ||
                ( e.KeyCode == Keys.Down ) ||
                ( e.KeyCode == Keys.Left ) ||
                ( e.KeyCode == Keys.Right ) )
            {
                e.IsInputKey = true;
            }
        }

        private void Joystick_background_panel_paint_event_handler( object sender, PaintEventArgs e )
        {
            e.Graphics.DrawLine( Pens.Black, 0, 150, 300, 150 );  // Horizontal axis
            e.Graphics.DrawLine( Pens.Black, 150, 0, 150, 300 );  // Vertical axis
        }

        private void Center_the_joystick_button_click_event_handler( object sender, EventArgs e )
        {
            Joystick_controller.Center_the_joystick();
            Update_joystick_coordinates_text_on_the_screen();
        }


        #region Joystick button GUI events handling

        private Point MouseDownLocation;

        private void Joystick_button_MouseDown( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Left )
            {
                MouseDownLocation = e.Location;
            }
        }

        private void Joystick_button_MouseUp( object sender, MouseEventArgs e )
        {
            if( Center_the_joystick_on_mouse_up_event_checkbox.Checked )
            {
                Joystick_controller.Center_the_joystick();
                Update_joystick_coordinates_text_on_the_screen();
            }
        }

        private void Joystick_button_MouseMove( object sender, MouseEventArgs e )
        {
            if( e.Button == MouseButtons.Left )
            {
                int New_left = e.X + Joystick_button.Left - MouseDownLocation.X;
                int New_top = e.Y + Joystick_button.Top - MouseDownLocation.Y;

                Joystick_controller.Set_new_joystick_button_coordinates( New_left, New_top );  // In pixels
                Update_joystick_coordinates_text_on_the_screen();

                Joystick_button.Invalidate();
            }
        }

        #endregion  // Joystick button GUI events handling

        private void Update_joystick_coordinates_text_on_the_screen()
        {
            Joystick_x_label.Text = "X = " + Joystick_controller.Joystick_X.ToString();
            Joystick_y_label.Text = "Y = " + Joystick_controller.Joystick_Y.ToString();

            // Command bytes array to HEX string
            string Command_HEX = BitConverter.ToString( Joystick_controller.Get_rover_driving_command_bytes_array() ).Replace( "-", " | " );

            Joystick_current_command_label.Text =
                @"Joystick command: """ +
                Command_HEX +
                @"""";
        }

        private void Center_the_joystick_on_mouse_up_event_checkbox_checked_changed_event_handler( object sender, EventArgs e )
        {
            Joystick_controller.Center_the_joystick();
            Update_joystick_coordinates_text_on_the_screen();
        }


        #region COM port interaction

        private async void Open_the_com_port_button_Click( object sender, EventArgs e )
        {
            try
            {
                Open_the_com_port_button.Enabled = false;
                cbComPorts.Enabled = false;

                Joystick_controller.Center_the_joystick();
                Update_joystick_coordinates_text_on_the_screen();

                if( Current_com_port != null )
                {
                    Current_com_port.Close();
                    Current_com_port = null;

                    return;
                }

                string Com_port_name = cbComPorts.SelectedValue.ToString();

                Task<Com_port_class> openComPort = new Task<Com_port_class>( () =>
                {
                    return new Com_port_class( Com_port_name );
                } );

                openComPort.Start();

                Current_com_port = await openComPort;

                MessageBox.Show( "COM port \"" + Com_port_name + "\" has been opened successfully." );
            }
            catch( Exception Ex )
            {
                if( Current_com_port != null )
                {
                    Current_com_port.Close();
                    Current_com_port = null;
                }

                MessageBox.Show( Ex.Message );
            }
            finally
            {
                Open_the_com_port_button.Enabled = true;

                if( Current_com_port != null )
                {
                    Open_the_com_port_button.Text = DisconnectButtonText;
                }
                else
                {
                    Open_the_com_port_button.Text = ConnectButtonText;
                    cbComPorts.Enabled = true;
                }
            }
        }

        private byte[] m_Previous_rover_command;
        private void Send_current_rover_driving_command_to_com_port()
        {
            byte[] Command_bytes_array = Joystick_controller.Get_rover_driving_command_bytes_array();

            if( m_Previous_rover_command != null &&  // If there is some previous command...
                Enumerable.SequenceEqual( m_Previous_rover_command, Command_bytes_array ) )  // ...and the previous command is the same as the current command.
            {
               return;  // Don't send the current command
            }

            m_Previous_rover_command = Command_bytes_array;  // Save the last send command, to not send it again

            SendCommandAsync( Command_bytes_array );
        }

        private void SendCurrentHandCommandAsync()
        {
            if( lstHandCommands.Items.Count > 6 )
            {
                lstHandCommands.Items.Clear();
            }

            IEnumerable<byte[]> commands = m_handController.GetCommand();

            foreach( byte[] cmd in commands )
            {

                WakePacket packet = new WakePacket()
                {
                    Address = 1,
                    Command = 77,
                    Data = cmd
                };

                string outputCommand = String.Format(
                    "H {0} {1}",
                    cmd[0],
                    cmd[1]
                );

                lstHandCommands.Items.Add( outputCommand );
                // SendCommandAsync( packet );  // Temporary disabled !!!
            }
        }

        private async void SendCommandAsync( byte[] packet )
        {
            if( Current_com_port == null || packet == null )
            {
                return;
            }

            try
            {
                await Current_com_port.WriteAsync( packet );
            }
            catch( TaskCanceledException )
            {
                // Ignore
            }
            catch( Exception ex )
            {
                if( Current_com_port != null )
                {
                    Current_com_port.Close();
                    Current_com_port = null;
                }

                MessageBox.Show( ex.Message );
            }
        }

        #endregion  // Timer tick event. COM port interaction.

        private void Send_one_comand_timer_tick( object sender, EventArgs e )
        {
            // Read log message from the COM port and display it on the screen
            if( Current_com_port != null )
            {
                string message = Current_com_port.Read();

                if (message != null)
                {
                    SerialPortMonitorTextBox.AppendText(message + "\r\n");
                }
            }

            Send_current_rover_driving_command_to_com_port();
            SendCurrentHandCommandAsync();

            // Turn left
            if( ( Keyboard_key_left_is_pressed == true ) &&
                ( Keyboard_key_right_is_pressed == false ) )
            {
                Joystick_controller.Shift_left( 5 );  // In pixels
                Update_joystick_coordinates_text_on_the_screen();
            }

            // Turn right
            if( ( Keyboard_key_left_is_pressed == false ) &&
                ( Keyboard_key_right_is_pressed == true ) )
            {
                Joystick_controller.Shift_right( 5 );  // In pixels
                Update_joystick_coordinates_text_on_the_screen();
            }

        }

        #region Keyboard events handling

        private void Robot_car_arduino_controller_form_KeyDown( object sender, KeyEventArgs e )
        {
            Center_the_joystick_on_mouse_up_event_checkbox.Checked = false;  // Disable the joystick return to the center;

            switch( e.KeyCode )
            {
                case Keys.Left:
                    Keyboard_key_left_is_pressed = true;  // Turn left
                    Keyboard_key_right_is_pressed = false;
                    break;

                case Keys.Right:
                    Keyboard_key_left_is_pressed = false;
                    Keyboard_key_right_is_pressed = true;  // Turn right
                    break;

                case Keys.Up:
                    Joystick_controller.Shift_max_front();
                    Update_joystick_coordinates_text_on_the_screen();
                    break;

                case Keys.Down:
                    Joystick_controller.Shift_max_back();
                    Update_joystick_coordinates_text_on_the_screen();
                    break;

                case Keys.Space:
                    Joystick_controller.Center_the_joystick();
                    Update_joystick_coordinates_text_on_the_screen();
                    break;

                case Keys.W:
                    HandMoveForward();
                    break;

                case Keys.S:
                    HandMoveBack();
                    break;

                case Keys.A:
                    HandMoveLeft();
                    break;

                case Keys.D:
                    HandMoveRight();
                    break;

                case Keys.PageUp:
                    MoveToTheNextServo();
                    break;

                case Keys.PageDown:
                    MoveToThePreviousServo();
                    break;
            }
        }

        #region Hand controlling

        private void MoveToThePreviousServo()
        {
            int currentServo = m_handController.MoveToThePreviousServo();

            m_servos[currentServo - 1].Checked = true;
            tbOtherServosValue.Text = m_handController
                .GetCurrentAngle()
                .ToString();
        }

        private void MoveToTheNextServo()
        {
            int currentServo = m_handController.MoveToTheNextServo();

            m_servos[currentServo - 1].Checked = true;
            tbOtherServosValue.Text = m_handController
                .GetCurrentAngle()
                .ToString();
        }

        private void HandMoveRight()
        {
            int currentAngle = m_handController.TurnRight();

            tbServo0Value.Text = currentAngle.ToString();
        }

        private void HandMoveLeft()
        {
            int currentAngle = m_handController.TurnLeft();

            tbServo0Value.Text = currentAngle.ToString();
        }

        private void HandMoveBack()
        {
            int currentAngle = m_handController.MoveBack();

            tbOtherServosValue.Text = currentAngle.ToString();
        }

        private void HandMoveForward()
        {
            int currentAngle = m_handController.MoveForward();

            tbOtherServosValue.Text = currentAngle.ToString();
        }

        #endregion

        private void Robot_car_arduino_controller_form_KeyUp( object sender, KeyEventArgs e )
        {
            Center_the_joystick_on_mouse_up_event_checkbox.Checked = false;  // Disable the joystick return to the center;

            switch( e.KeyCode )
            {
                case Keys.Left:
                    Keyboard_key_left_is_pressed = false;  // Turn left - disable
                    break;

                case Keys.Right:
                    Keyboard_key_right_is_pressed = false;  // Turn right - disable
                    break;


                case Keys.Up:
                    // Drossel = 0
                    Joystick_controller.Center_the_joystick_y_axis();
                    Update_joystick_coordinates_text_on_the_screen();
                    break;

                case Keys.Down:
                    // Drossel = 0
                    Joystick_controller.Center_the_joystick_y_axis();
                    Update_joystick_coordinates_text_on_the_screen();
                    break;
            }
        }

        #endregion  // Keyboard evemts handling

        private void Robot_car_arduino_controller_form_FormClosed( object sender, FormClosedEventArgs e )
        {
            if( Current_com_port != null )
            {
                Current_com_port.Close();
                Current_com_port = null;
            }
        }

        private void radioButton1_CheckedChanged( object sender, EventArgs e )
        {

        }
    }
}