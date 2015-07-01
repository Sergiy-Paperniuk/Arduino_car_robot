namespace Robot_car_arduino_controller
{
    partial class Form1
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.Joystick_button = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.Open_the_com_port_button = new System.Windows.Forms.Button();
      this.Com_port_name_text_box = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Location = new System.Drawing.Point(50, 50);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(300, 300);
      this.panel1.TabIndex = 0;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
      // 
      // Joystick_button
      // 
      this.Joystick_button.Location = new System.Drawing.Point(175, 175);
      this.Joystick_button.Name = "Joystick_button";
      this.Joystick_button.Size = new System.Drawing.Size(50, 50);
      this.Joystick_button.TabIndex = 0;
      this.Joystick_button.UseVisualStyleBackColor = true;
      this.Joystick_button.Click += new System.EventHandler(this.Joystick_button_Click);
      this.Joystick_button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseDown);
      this.Joystick_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseMove);
      this.Joystick_button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Joystick_button_MouseUp);
      // 
      // button2
      // 
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.button2.Location = new System.Drawing.Point(406, 50);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(316, 67);
      this.button2.TabIndex = 1;
      this.button2.Text = "Center the joystick";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(401, 145);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(110, 25);
      this.label1.TabIndex = 2;
      this.label1.Text = "Joystick X";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(401, 185);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(111, 25);
      this.label2.TabIndex = 3;
      this.label2.Text = "Joystick Y";
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.checkBox1.Location = new System.Drawing.Point(406, 321);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(398, 29);
      this.checkBox1.TabIndex = 4;
      this.checkBox1.Text = "Center the joystick on mouse up event";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(401, 220);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(189, 25);
      this.label3.TabIndex = 5;
      this.label3.Text = "Joystick command";
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
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(741, 141);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(169, 25);
      this.label4.TabIndex = 8;
      this.label4.Text = "COM port name:";
      // 
      // timer1
      // 
      this.timer1.Interval = 500;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1072, 409);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.Com_port_name_text_box);
      this.Controls.Add(this.Open_the_com_port_button);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.checkBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.Joystick_button);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Robot car arduino controller";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Joystick_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Open_the_com_port_button;
        private System.Windows.Forms.TextBox Com_port_name_text_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}

