using System;
using System.IO.Ports;
using System.Text;

namespace Robot_car_arduino_controller
{
  class Com_port_class
  {
    private SerialPort serialPort;

    public Com_port_class( string Port_name )
    {
      // Create the serial port with basic settings
      serialPort = new SerialPort( portName: Port_name,
                                   baudRate: 9600,
                                   parity: Parity.None,
                                   dataBits: 8,
                                   stopBits: StopBits.One );

      // serialPort.Handshake = Handshake.None;

      // Set the read/write timeouts
      serialPort.ReadTimeout = 3000;  // 3 seconds
      serialPort.WriteTimeout = 3000;  // 3 seconds

      serialPort.Open();
    }

		public void Write( byte[] cmd ) {

			serialPort.Write( 
					buffer: cmd,
					offset: 0,
					count: cmd.Length
				);
		}

		public void Close()
    {
      if( serialPort != null )
      {
        serialPort.Close();
        serialPort = null;
      }
    }
	}
}