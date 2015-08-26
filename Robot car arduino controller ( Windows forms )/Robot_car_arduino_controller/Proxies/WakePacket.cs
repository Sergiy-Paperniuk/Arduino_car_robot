using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_car_arduino_controller.Proxies {
	public class WakePacket {
		private byte m_address;
		private byte m_command;
		private List<byte> m_data = new List<byte>();
		private byte CodeErr = 0;
		// for RX logic
		private bool flagFESC = false; // for byte stuffing
		private RxState state = RxState.BEGIN;
		private byte rxdataCnt = 0;
		private bool sendAddress = true;


		public byte Address {
			get { return m_address; }
			set { m_address = value; }
		}

		public byte Command {
			get { return m_command; }
			set { m_command = value; }
		}

		public byte[] Data {
			get { return m_data.ToArray(); }
			set {
				if( value.Length> Constants.SLIPFRAME ) {
					throw new ArgumentException( "data size bigger then SLIPFRAME" );
				}

				this.m_data = value.ToList();
			}
		}


		private int GetDataCount() {
			return m_data != null ? m_data.Count : 0;
		}

		private Byte getCodeErr() {
			return CodeErr;
		}

		// --------------------- CRC ------------------------
		public byte[] GetTransferBuffer() {
			List<Byte> bufTX = new List<Byte>();

			bufTX.Add( Constants.FEND ); // start packet
			bufTX.AddRange( translateCharSLIP( (byte)( this.Address | 0x80 ) ) ); // set
																				  // address
			bufTX.AddRange( translateCharSLIP( this.Command ) ); // set command
			bufTX.AddRange( translateCharSLIP( (byte)this.GetDataCount() ) );

			foreach( Byte bt in this.Data ) {
				bufTX.AddRange( translateCharSLIP( bt ) );
			}

			bufTX.AddRange( translateCharSLIP( (byte)performCRCcalculation() ) );

			return bufTX.ToArray();
		}

		public bool setRXbyte( byte rcv ) {

			bool wakePacketIsReceived = false;

			if( rcv == Constants.FEND ) {
				state = RxState.BEGIN;
			}

			// byte stuffing
			if( rcv == Constants.FESC && flagFESC == false ) {
				flagFESC = true;
				return false;
			}

			if( flagFESC == true ) {
				flagFESC = false;
				if( rcv == Constants.TFEND )
					rcv = Constants.FEND;
				else if( rcv == Constants.TFESC )
					rcv = Constants.FESC;
			}
			// end byte stuffing
			switch( state ) {
				case RxState.BEGIN:
					if( rcv == Constants.FEND ) {
						state = RxState.STARTPACKET;
					}
					break;
				case RxState.STARTPACKET:
					if( ( rcv & 0x80 ) != 0 ) {
						sendAddress = true;
						state = RxState.ADDRESS;
						this.Address = ( (byte)( rcv & 0x7F ) );
					} else {
						sendAddress = false;
						state = RxState.COMMAND;
						this.Address = ( (byte)0 );
						this.Command = rcv;
					}
					break;
				case RxState.ADDRESS:
					state = RxState.COMMAND;
					this.Command = rcv;
					break;
				case RxState.COMMAND: // receive CntData
					m_data.Clear();
					state = ( rcv != 0 ) ? RxState.DATA : RxState.CRC;
					rxdataCnt = rcv;
					if( rxdataCnt > Constants.SLIPFRAME ) { // err: packet is very long
						throw new ArgumentException( "Received WakeUp packet is very long" );
					}
					break;
				case RxState.DATA:
					m_data.Add( rcv );
					if( m_data.Count == rxdataCnt ) {
						state = RxState.CRC;
					}
					break;
				case RxState.CRC:
					this.CodeErr = ( rcv == (byte)performCRCcalculation() )
						? Constants.ERR_NO
						: Constants.ERR_TX;
					state = RxState.BEGIN;
					wakePacketIsReceived = true;
					break;
			}
			return wakePacketIsReceived;
		}

		public override string ToString() {

			string strData = "";

			if( m_data != null ) {
				foreach( byte b in m_data ) {
					strData += b.ToString();
				}
			}

			return String.Format( "\nWakePacket %s:\n\taddress=0x{0:00},\n\tcommand=0x{1:00},\n\tdata:{2},\n\tCodeErr=0x{3:00}\n",
				m_address,
				m_command,
				strData,
				CodeErr
			);
		}

		private int do_crc8( int b, int crc ) {
			for( int i = 0; i < 8; b = b >> 1, i++ ) {
				if( ( ( b ^ crc ) & 1 ) == 1 ) {
					crc = ( ( crc ^ 0x18 ) >> 1 ) | 0x80;
				} else {
					crc = ( crc >> 1 ) & 0x7F;
				}
			}
			return crc;
		}

		private List<Byte> translateCharSLIP( Byte ch ) {
			List<Byte> result = new List<Byte>();

			if( ch == Constants.FEND ) {
				result.Add( Constants.FESC );
				result.Add( Constants.TFEND );
			} else if( ch == Constants.FESC ) {
				result.Add( Constants.FESC );
				result.Add( Constants.TFESC );
			} else {
				result.Add( ch );
			}

			return result;
		}

		private int performCRCcalculation() {
			int crc = Constants.CRC_INIT;

			crc = do_crc8( Constants.FEND, crc );

			if( sendAddress ) {
				crc = do_crc8( this.Address, crc );
			}

			crc = do_crc8( this.Command, crc );
			crc = do_crc8( this.GetDataCount(), crc );

			foreach( Byte bt in this.Data ) {
				crc = do_crc8( bt, crc );
			}

			return crc;
		}

	}
}
