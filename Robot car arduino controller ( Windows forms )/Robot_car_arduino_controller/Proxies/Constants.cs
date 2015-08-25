namespace Robot_car_arduino_controller.Proxies {
	public class Constants {
		//codes for common command:
		public const byte NOP = 0;    //not operation
		public const byte ERR = 1;    //error at packet receiving
		public const byte ECHO = 2;    //translate echo
		public const byte INFO = 3;    //translate device info

		public const int SLIPFRAME = 255;
		public const int CRC_INIT = 0xDE;  //initial CRC value
												  //SLIP protocol
		public const byte FEND = (byte)0xC0; // Frame End
		public const byte FESC = (byte)0xDB; // Frame Escape
		public const byte TFEND = (byte)0xDC; // Transposed Frame End
		public const byte TFESC = (byte)0xDD; // Transposed Frame Escape
													 //
													 //code error:
		public const byte ERR_NO = 0x00;   //no error
		public const byte ERR_TX = 0x01;   //Rx/Tx error
		public const byte ERR_BU = 0x02;   //device busy error
		public const byte ERR_RE = 0x03;   //device not ready error
		public const byte ERR_PA = 0x04;   //parameters value error
		public const byte ERR_NR = 0x05;   //no replay
		public const byte ERR_NC = 0x06;   //no carrier
	}
}
