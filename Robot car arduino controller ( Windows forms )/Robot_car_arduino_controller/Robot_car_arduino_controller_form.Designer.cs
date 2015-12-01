namespace Robot_car_arduino_controller
{
    partial class Robot_car_arduino_controller_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Joystick_background_panel = new System.Windows.Forms.Panel();
            this.Joystick_button = new System.Windows.Forms.Button();
            this.Center_the_joystick_button = new System.Windows.Forms.Button();
            this.Joystick_x_label = new System.Windows.Forms.Label();
            this.Joystick_y_label = new System.Windows.Forms.Label();
            this.Center_the_joystick_on_mouse_up_event_checkbox = new System.Windows.Forms.CheckBox();
            this.Joystick_current_command_label = new System.Windows.Forms.Label();
            this.Open_the_com_port_button = new System.Windows.Forms.Button();
            this.COM_port_name_label = new System.Windows.Forms.Label();
            this.Send_one_comand_timer = new System.Windows.Forms.Timer(this.components);
            this.rbServo5 = new System.Windows.Forms.RadioButton();
            this.rbServo4 = new System.Windows.Forms.RadioButton();
            this.rbServo3 = new System.Windows.Forms.RadioButton();
            this.rbServo2 = new System.Windows.Forms.RadioButton();
            this.rbServo1 = new System.Windows.Forms.RadioButton();
            this.tbOtherServosValue = new System.Windows.Forms.TextBox();
            this.tbServo0Value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstHandCommands = new System.Windows.Forms.ListBox();
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.lblComPortsLoading = new System.Windows.Forms.Label();
            this.SerialPortMonitorTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Joystick_background_panel
            // 
            this.Joystick_background_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Joystick_background_panel.Location = new System.Drawing.Point(50, 50);
            this.Joystick_background_panel.Name = "Joystick_background_panel";
            this.Joystick_background_panel.Size = new System.Drawing.Size(300, 300);
            this.Joystick_background_panel.TabIndex = 0;
            this.Joystick_background_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Joystick_background_panel_paint_event_handler);
            // 
            // Joystick_button
            // 
            this.Joystick_button.Location = new System.Drawing.Point(175, 175);
            this.Joystick_button.Name = "Joystick_button";
            this.Joystick_button.Size = new System.Drawing.Size(50, 50);
            this.Joystick_button.TabIndex = 0;
            this.Joystick_button.UseVisualStyleBackColor = true;
            this.Joystick_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseDown);
            this.Joystick_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseMove);
            this.Joystick_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseUp);
            // 
            // Center_the_joystick_button
            // 
            this.Center_the_joystick_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Center_the_joystick_button.Location = new System.Drawing.Point(406, 50);
            this.Center_the_joystick_button.Name = "Center_the_joystick_button";
            this.Center_the_joystick_button.Size = new System.Drawing.Size(316, 67);
            this.Center_the_joystick_button.TabIndex = 1;
            this.Center_the_joystick_button.Text = "Center the joystick";
            this.Center_the_joystick_button.UseVisualStyleBackColor = true;
            this.Center_the_joystick_button.Click += new System.EventHandler(this.Center_the_joystick_button_click_event_handler);
            // 
            // Joystick_x_label
            // 
            this.Joystick_x_label.AutoSize = true;
            this.Joystick_x_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Joystick_x_label.Location = new System.Drawing.Point(401, 145);
            this.Joystick_x_label.Name = "Joystick_x_label";
            this.Joystick_x_label.Size = new System.Drawing.Size(110, 25);
            this.Joystick_x_label.TabIndex = 2;
            this.Joystick_x_label.Text = "Joystick X";
            // 
            // Joystick_y_label
            // 
            this.Joystick_y_label.AutoSize = true;
            this.Joystick_y_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Joystick_y_label.Location = new System.Drawing.Point(401, 185);
            this.Joystick_y_label.Name = "Joystick_y_label";
            this.Joystick_y_label.Size = new System.Drawing.Size(111, 25);
            this.Joystick_y_label.TabIndex = 3;
            this.Joystick_y_label.Text = "Joystick Y";
            // 
            // Center_the_joystick_on_mouse_up_event_checkbox
            // 
            this.Center_the_joystick_on_mouse_up_event_checkbox.AutoSize = true;
            this.Center_the_joystick_on_mouse_up_event_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Center_the_joystick_on_mouse_up_event_checkbox.Location = new System.Drawing.Point(406, 12);
            this.Center_the_joystick_on_mouse_up_event_checkbox.Name = "Center_the_joystick_on_mouse_up_event_checkbox";
            this.Center_the_joystick_on_mouse_up_event_checkbox.Size = new System.Drawing.Size(398, 29);
            this.Center_the_joystick_on_mouse_up_event_checkbox.TabIndex = 4;
            this.Center_the_joystick_on_mouse_up_event_checkbox.Text = "Center the joystick on mouse up event";
            this.Center_the_joystick_on_mouse_up_event_checkbox.UseVisualStyleBackColor = true;
            this.Center_the_joystick_on_mouse_up_event_checkbox.CheckedChanged += new System.EventHandler(this.Center_the_joystick_on_mouse_up_event_checkbox_checked_changed_event_handler);
            // 
            // Joystick_current_command_label
            // 
            this.Joystick_current_command_label.AutoSize = true;
            this.Joystick_current_command_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Joystick_current_command_label.Location = new System.Drawing.Point(401, 220);
            this.Joystick_current_command_label.Name = "Joystick_current_command_label";
            this.Joystick_current_command_label.Size = new System.Drawing.Size(189, 25);
            this.Joystick_current_command_label.TabIndex = 5;
            this.Joystick_current_command_label.Text = "Joystick command";
            // 
            // Open_the_com_port_button
            // 
            this.Open_the_com_port_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Open_the_com_port_button.Location = new System.Drawing.Point(746, 50);
            this.Open_the_com_port_button.Name = "Open_the_com_port_button";
            this.Open_the_com_port_button.Size = new System.Drawing.Size(304, 67);
            this.Open_the_com_port_button.TabIndex = 6;
            this.Open_the_com_port_button.Text = "Open the COM port";
            this.Open_the_com_port_button.UseVisualStyleBackColor = true;
            this.Open_the_com_port_button.Click += new System.EventHandler(this.Open_the_com_port_button_Click);
            // 
            // COM_port_name_label
            // 
            this.COM_port_name_label.AutoSize = true;
            this.COM_port_name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.COM_port_name_label.Location = new System.Drawing.Point(741, 141);
            this.COM_port_name_label.Name = "COM_port_name_label";
            this.COM_port_name_label.Size = new System.Drawing.Size(169, 25);
            this.COM_port_name_label.TabIndex = 8;
            this.COM_port_name_label.Text = "COM port name:";
            // 
            // Send_one_comand_timer
            // 
            this.Send_one_comand_timer.Interval = 500;
            this.Send_one_comand_timer.Tick += new System.EventHandler(this.Send_one_comand_timer_tick);
            // 
            // rbServo5
            // 
            this.rbServo5.AutoSize = true;
            this.rbServo5.Enabled = false;
            this.rbServo5.Location = new System.Drawing.Point(406, 258);
            this.rbServo5.Name = "rbServo5";
            this.rbServo5.Size = new System.Drawing.Size(62, 17);
            this.rbServo5.TabIndex = 9;
            this.rbServo5.Tag = "5";
            this.rbServo5.Text = "Servo 5";
            this.rbServo5.UseVisualStyleBackColor = true;
            this.rbServo5.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbServo4
            // 
            this.rbServo4.AutoSize = true;
            this.rbServo4.Enabled = false;
            this.rbServo4.Location = new System.Drawing.Point(406, 281);
            this.rbServo4.Name = "rbServo4";
            this.rbServo4.Size = new System.Drawing.Size(62, 17);
            this.rbServo4.TabIndex = 10;
            this.rbServo4.Tag = "4";
            this.rbServo4.Text = "Servo 4";
            this.rbServo4.UseVisualStyleBackColor = true;
            // 
            // rbServo3
            // 
            this.rbServo3.AutoSize = true;
            this.rbServo3.Enabled = false;
            this.rbServo3.Location = new System.Drawing.Point(406, 304);
            this.rbServo3.Name = "rbServo3";
            this.rbServo3.Size = new System.Drawing.Size(62, 17);
            this.rbServo3.TabIndex = 11;
            this.rbServo3.Tag = "3";
            this.rbServo3.Text = "Servo 3";
            this.rbServo3.UseVisualStyleBackColor = true;
            // 
            // rbServo2
            // 
            this.rbServo2.AutoSize = true;
            this.rbServo2.Enabled = false;
            this.rbServo2.Location = new System.Drawing.Point(406, 327);
            this.rbServo2.Name = "rbServo2";
            this.rbServo2.Size = new System.Drawing.Size(62, 17);
            this.rbServo2.TabIndex = 12;
            this.rbServo2.Tag = "2";
            this.rbServo2.Text = "Servo 2";
            this.rbServo2.UseVisualStyleBackColor = true;
            // 
            // rbServo1
            // 
            this.rbServo1.AutoSize = true;
            this.rbServo1.Checked = true;
            this.rbServo1.Enabled = false;
            this.rbServo1.Location = new System.Drawing.Point(406, 350);
            this.rbServo1.Name = "rbServo1";
            this.rbServo1.Size = new System.Drawing.Size(62, 17);
            this.rbServo1.TabIndex = 13;
            this.rbServo1.TabStop = true;
            this.rbServo1.Tag = "1";
            this.rbServo1.Text = "Servo 1";
            this.rbServo1.UseVisualStyleBackColor = true;
            // 
            // tbOtherServosValue
            // 
            this.tbOtherServosValue.Enabled = false;
            this.tbOtherServosValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOtherServosValue.Location = new System.Drawing.Point(508, 301);
            this.tbOtherServosValue.Name = "tbOtherServosValue";
            this.tbOtherServosValue.Size = new System.Drawing.Size(100, 26);
            this.tbOtherServosValue.TabIndex = 15;
            this.tbOtherServosValue.Text = "0";
            // 
            // tbServo0Value
            // 
            this.tbServo0Value.Enabled = false;
            this.tbServo0Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbServo0Value.Location = new System.Drawing.Point(746, 301);
            this.tbServo0Value.Name = "tbServo0Value";
            this.tbServo0Value.Size = new System.Drawing.Size(100, 26);
            this.tbServo0Value.TabIndex = 16;
            this.tbServo0Value.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(696, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Servo 0";
            // 
            // lstHandCommands
            // 
            this.lstHandCommands.FormattingEnabled = true;
            this.lstHandCommands.Location = new System.Drawing.Point(866, 258);
            this.lstHandCommands.Name = "lstHandCommands";
            this.lstHandCommands.Size = new System.Drawing.Size(120, 95);
            this.lstHandCommands.TabIndex = 18;
            // 
            // cbComPorts
            // 
            this.cbComPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(746, 185);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(304, 33);
            this.cbComPorts.TabIndex = 19;
            // 
            // lblComPortsLoading
            // 
            this.lblComPortsLoading.AutoSize = true;
            this.lblComPortsLoading.Location = new System.Drawing.Point(916, 150);
            this.lblComPortsLoading.Name = "lblComPortsLoading";
            this.lblComPortsLoading.Size = new System.Drawing.Size(50, 13);
            this.lblComPortsLoading.TabIndex = 20;
            this.lblComPortsLoading.Text = "loading...";
            // 
            // SerialPortMonitorTextBox
            // 
            this.SerialPortMonitorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SerialPortMonitorTextBox.Location = new System.Drawing.Point(26, 425);
            this.SerialPortMonitorTextBox.Multiline = true;
            this.SerialPortMonitorTextBox.Name = "SerialPortMonitorTextBox";
            this.SerialPortMonitorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SerialPortMonitorTextBox.Size = new System.Drawing.Size(1024, 145);
            this.SerialPortMonitorTextBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Serial port monitor";
            // 
            // Robot_car_arduino_controller_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 599);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SerialPortMonitorTextBox);
            this.Controls.Add(this.lblComPortsLoading);
            this.Controls.Add(this.cbComPorts);
            this.Controls.Add(this.lstHandCommands);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServo0Value);
            this.Controls.Add(this.tbOtherServosValue);
            this.Controls.Add(this.rbServo1);
            this.Controls.Add(this.rbServo2);
            this.Controls.Add(this.rbServo3);
            this.Controls.Add(this.rbServo4);
            this.Controls.Add(this.rbServo5);
            this.Controls.Add(this.COM_port_name_label);
            this.Controls.Add(this.Open_the_com_port_button);
            this.Controls.Add(this.Joystick_current_command_label);
            this.Controls.Add(this.Center_the_joystick_on_mouse_up_event_checkbox);
            this.Controls.Add(this.Joystick_y_label);
            this.Controls.Add(this.Joystick_x_label);
            this.Controls.Add(this.Joystick_button);
            this.Controls.Add(this.Center_the_joystick_button);
            this.Controls.Add(this.Joystick_background_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Robot_car_arduino_controller_form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robot car arduino controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Robot_car_arduino_controller_form_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Robot_car_arduino_controller_form_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Robot_car_arduino_controller_form_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Joystick_background_panel;
        private System.Windows.Forms.Button Joystick_button;
        private System.Windows.Forms.Button Center_the_joystick_button;
        private System.Windows.Forms.Label Joystick_x_label;
        private System.Windows.Forms.Label Joystick_y_label;
        private System.Windows.Forms.CheckBox Center_the_joystick_on_mouse_up_event_checkbox;
        private System.Windows.Forms.Label Joystick_current_command_label;
        private System.Windows.Forms.Button Open_the_com_port_button;
        private System.Windows.Forms.Label COM_port_name_label;
        private System.Windows.Forms.Timer Send_one_comand_timer;
		private System.Windows.Forms.RadioButton rbServo5;
		private System.Windows.Forms.RadioButton rbServo4;
		private System.Windows.Forms.RadioButton rbServo3;
		private System.Windows.Forms.RadioButton rbServo2;
		private System.Windows.Forms.RadioButton rbServo1;
		private System.Windows.Forms.TextBox tbOtherServosValue;
		private System.Windows.Forms.TextBox tbServo0Value;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstHandCommands;
		private System.Windows.Forms.ComboBox cbComPorts;
		private System.Windows.Forms.Label lblComPortsLoading;
        private System.Windows.Forms.TextBox SerialPortMonitorTextBox;
        private System.Windows.Forms.Label label2;
    }
}