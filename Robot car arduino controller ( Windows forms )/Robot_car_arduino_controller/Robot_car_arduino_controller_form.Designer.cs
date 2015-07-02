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
      this.Com_port_name_text_box = new System.Windows.Forms.TextBox();
      this.COM_port_name_label = new System.Windows.Forms.Label();
      this.Send_one_comand_timer = new System.Windows.Forms.Timer(this.components);
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
      this.Center_the_joystick_on_mouse_up_event_checkbox.Location = new System.Drawing.Point(406, 321);
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
      // Com_port_name_text_box
      // 
      this.Com_port_name_text_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Com_port_name_text_box.Location = new System.Drawing.Point(746, 175);
      this.Com_port_name_text_box.Name = "Com_port_name_text_box";
      this.Com_port_name_text_box.Size = new System.Drawing.Size(304, 31);
      this.Com_port_name_text_box.TabIndex = 7;
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
      // Robot_car_arduino_controller_form
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1072, 409);
      this.Controls.Add(this.COM_port_name_label);
      this.Controls.Add(this.Com_port_name_text_box);
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
        private System.Windows.Forms.TextBox Com_port_name_text_box;
        private System.Windows.Forms.Label COM_port_name_label;
        private System.Windows.Forms.Timer Send_one_comand_timer;
    }
}