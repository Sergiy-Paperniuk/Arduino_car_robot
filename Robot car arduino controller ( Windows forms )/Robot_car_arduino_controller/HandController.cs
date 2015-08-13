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

			private int m_minAngle = 0;
			private int m_maxAngle = 180;

			private int m_currentAngle;

			public Servo( byte number ) {
				Number = number;
			}

			public byte Number { get; private set; }

			public int CurrentAngle {
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

			public int MinAngle {
				get { return m_minAngle; }
			}

			public int MaxAngle {
				get { return m_maxAngle; }
			}

			public bool IsChanged { get; set; }

			public byte[] GetCommand() {

				byte[] result = new byte[]{
						Convert.ToByte('H'),
						Number,
						Convert.ToByte(CurrentAngle)
					};

				IsChanged = false;
				return result;
			}
		}

		private readonly Servo[] m_servoes = new Servo[] {
			new Servo(0),
			new Servo(1),
			new Servo(2),
			new Servo(3),
			new Servo(4),
			new Servo(5)
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
