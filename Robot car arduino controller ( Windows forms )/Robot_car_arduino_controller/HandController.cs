using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_car_arduino_controller {

	internal sealed class HandController {

		private const int Step = 5;
		private int m_currentServo = 1;

		private sealed class Servo {

			private byte m_minAngle = 0;
			private byte m_maxAngle = 180;

			private byte m_currentAngle;

			public Servo( byte number, byte minAngle, byte maxAngle ) {
				Number = number;
				m_minAngle = minAngle;
				m_maxAngle = maxAngle;

				m_currentAngle = minAngle;
			}

			public Servo( byte number ) : this( number, 0, 180 ) { }

			public byte Number { get; private set; }

			public byte CurrentAngle {
				get {
					return m_currentAngle;
				}
				set {
					if( m_currentAngle != value ) {
						IsChanged = true;
						m_currentAngle = value;
					}
				}
			}

			public byte MinAngle {
				get { return m_minAngle; }
			}

			public byte MaxAngle {
				get { return m_maxAngle; }
			}

			public bool IsChanged { get; set; }

			public byte[] GetCommand() {

				byte[] result = new byte[]{
						Number,
						CurrentAngle
					};

				IsChanged = false;
				return result;
			}
		}

		private readonly Servo[] m_servoes = new Servo[] {
			new Servo(0),
			new Servo(1, 10, 180),
			new Servo(2, 60, 180),
			new Servo(3),
			new Servo(4),
			new Servo(5, 115, 180)
		};

		public IEnumerable<byte[]> GetCommand() {

			return m_servoes
				.Where( x => x.IsChanged )
				.Select( x => x.GetCommand() )
				.ToArray();
		}

		public int TurnRight() {
			return TurnRight( 0 );
		}

		public int TurnLeft() {
			return TurnLeft( 0 );
		}

		public int MoveBack() {
			return TurnRight( m_currentServo );
		}

		public int MoveForward() {
			return TurnLeft( m_currentServo );
		}

		public int MoveToThePreviousServo() {

			if( m_currentServo - 1 <= 1 ) {
				return m_currentServo = 1;
			}

			return --m_currentServo;
		}

		public int MoveToTheNextServo() {
			if( m_currentServo + 1 >= 5 ) {
				return m_currentServo = 5;
			}

			return ++m_currentServo;
		}

		internal int GetCurrentAngle() {
			Servo servo = m_servoes[m_currentServo];

			return servo.CurrentAngle;
		}

		private int TurnLeft( int servoNumber ) {
			Servo servo = m_servoes[servoNumber];

			if( servo.CurrentAngle + Step >= servo.MaxAngle ) {
				servo.CurrentAngle = servo.MaxAngle;
			} else {
				servo.CurrentAngle += Step;
			}

			return servo.CurrentAngle;
		}

		private int TurnRight( int servoNumber ) {
			Servo servo = m_servoes[servoNumber];

			if( servo.CurrentAngle - Step <= servo.MinAngle ) {
				servo.CurrentAngle = servo.MinAngle;
			} else {
				servo.CurrentAngle -= Step;
			}

			return servo.CurrentAngle;
		}

	}
}
