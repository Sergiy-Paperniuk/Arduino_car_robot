using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using Robot_car_arduino_controller.Proxies;

namespace Robot_car_arduino_controller
{
    internal sealed class Com_port_class : IDisposable
    {
        private SerialPort serialPort;

        public Com_port_class( string Port_name )
        {
            // Create the serial port with basic settings

            // serialPort = new SerialPort( portName: "Port_name",
            serialPort = new SerialPort( portName: "COM6",  // Temborary hardcoded
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

        public async Task WriteAsync( byte[] packet )
        {

            if( serialPort == null )
            {
                return;
            }

            try
            {

                await Task.Run(
                    () =>
                    {

                        if( m_disposed )
                        {
                            return;
                        }

                        byte[] buffer = packet;

                        string hex = BitConverter.ToString( buffer ).Replace( "-", "" );

                        serialPort.Write(
                            buffer: buffer,
                            offset: 0,
                            count: buffer.Length
                        );
                    }
                );
            }
            catch( Exception )
            {
                if( m_disposed )
                {
                    return;
                }

                throw;
            }
        }

        public async static Task<ComPortInfo[]> GetComPorts()
        {

            ComPortInfo[] comPorts = await Task.Run( () =>
            {

                using( ManagementObjectSearcher searcher = new ManagementObjectSearcher( "SELECT * FROM WIN32_SerialPort" ) )
                {
                    IEnumerable<string> portnames = SerialPort
                        .GetPortNames();

                    IEnumerable<ManagementBaseObject> ports = searcher
                        .Get()
                        .Cast<ManagementBaseObject>();

                    ComPortInfo[] result = portnames
                        .Join(
                            ports,
                            name => name,
                            port => port["DeviceID"].ToString(),
                            ( name, port ) => new ComPortInfo()
                            {
                                Port = name,
                                Caption = ( port["Caption"].ToString() )
                            }
                        )
                        .ToArray();

                    return result;
                }
            } );

            return comPorts;
        }

        public void Close()
        {

            Dispose( true );
        }

        #region IDisposable Support
        private bool m_disposed = false;

        private async void Dispose( bool disposing )
        {
            if( !m_disposed )
            {
                if( disposing )
                {

                    m_disposed = true;

                    await Task.Run( () => serialPort.Dispose() );
                }

                serialPort = null;
            }
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            Dispose( true );
        }
        #endregion

    }

    internal sealed class ComPortInfo
    {
        public string Port { get; set; }

        public string Caption { get; set; }

    }
}