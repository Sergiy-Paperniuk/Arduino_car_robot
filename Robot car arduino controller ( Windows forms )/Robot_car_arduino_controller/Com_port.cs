using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robot_car_arduino_controller {
	internal sealed class Com_port_class : IDisposable {
		private SerialPort serialPort;

		public Com_port_class( string Port_name ) {
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

		public async Task WriteAsync( byte[] cmd ) {

			if( serialPort == null ) {
				return;
			}

			try {

				await Task.Run(
					() => {

						if( m_disposed ) {
							return;
						}

						serialPort.Write(
							buffer: cmd,
							offset: 0,
							count: cmd.Length
						);
					}
				);
			} catch( Exception ) {
				if( m_disposed ) {
					return;
				}

				throw;
			}
		}

		public void Close() {

			Dispose( true );
		}

		#region IDisposable Support
		private bool m_disposed = false;

		private async void Dispose( bool disposing ) {
			if( !m_disposed ) {
				if( disposing ) {

					m_disposed = true;

					await Task.Run( () => serialPort.Dispose() );
				}

				serialPort = null;
			}
		}

		// This code added to correctly implement the disposable pattern.
		void IDisposable.Dispose() {
			Dispose( true );
		}
		#endregion

	}
}