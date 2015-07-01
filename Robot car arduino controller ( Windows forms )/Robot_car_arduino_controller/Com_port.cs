using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void Write( string Command_string )
    {
      // The command looks like this: "L00S00"
      byte[] Command_bytes_array = Encoding.ASCII.GetBytes( Command_string );

      serialPort.Write( buffer : Command_bytes_array,
                        offset : 0,
                        count : 6 );
    }

    ~Com_port_class()  // Destructor
    {
      serialPort.Close();
    }
  }
}
