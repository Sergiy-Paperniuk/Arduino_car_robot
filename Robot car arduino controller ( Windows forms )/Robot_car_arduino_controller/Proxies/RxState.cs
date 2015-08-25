namespace Robot_car_arduino_controller.Proxies {
	public enum RxState {
		BEGIN,
		STARTPACKET,
		ADDRESS,
		COMMAND,
		DATA,
		CRC
	}
}
