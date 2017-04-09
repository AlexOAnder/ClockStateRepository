using System;
using System.Text;
using System.Timers;


namespace ClockLibrary
{
	public class Clock
	{
		private IClockState _state;
		private readonly StringBuilder s = new StringBuilder();
		private readonly Timer _timer;

		public int Hours { get; protected internal set; }
		public int Minutes { get; protected internal set; }
		public int Seconds { get; protected internal set; }

		public Clock()
		{
			// init timer for the clock's work
			_timer = new Timer(1000);
			_timer.Elapsed += Tick;
			// set state as ShowClock - it mean base state
			SetState(new ClockStateShowClock());
		}

		private void Tick(object sender, ElapsedEventArgs elapsedEventArgs)
		{
			// don't use method from state because tick is always just a tick 
			ChangeValue(ClockIdentifiersEnum.Seconds);
		}

		// internal method for the State changing
		internal void SetState(IClockState cs)
		{
			_state = cs;
		}

		// Method that Change status of the clock. Checks transitions from minutes to hours and from seconds to minutes
		internal void ChangeValue(ClockIdentifiersEnum value)
		{
			while (true)
			{
				switch (value)
				{
					case ClockIdentifiersEnum.Seconds:
						Seconds++;
						if (Seconds >= 60)
						{
							// if we have 60 second - we change logic to Increment Minutes and 
							// continue the loop
							value = ClockIdentifiersEnum.Minutes;
							Seconds = 0;
							continue;
						}
						break;
					case ClockIdentifiersEnum.Minutes:
						Minutes++;
						if (Minutes >= 60)
						{
							// if we have 60 minutes - we change logic to Increment Hours and
							// continue the loop
							value = ClockIdentifiersEnum.Hours;
							Minutes = 0;
							continue;
						}
						break;
					case ClockIdentifiersEnum.Hours:
						Hours++;
						// if hours == 24 we just change that to 0 because in day we have only 24 hours 
						// 0 hour mean 12:00 AM
						if (Hours >= 24) Hours = 0;
						break;
					default:
						throw new ArgumentOutOfRangeException("value", value, null);
				}
				break;
			}
		}

		//  method for the string implementation of current clock's values
		internal string CurrentValue()
		{
			s.Clear();
			s.Append(Hours / 10 > 0 ? "" + Hours : "0" + Hours);
			s.Append(":");
			s.Append(Minutes / 10 > 0 ? "" + Minutes : "0" + Minutes);
			s.Append(":");
			s.Append(Seconds / 10 > 0 ? "" + Seconds : "0" + Seconds);
			return s.ToString();
		}

		// public method for the change state of the clock to the next one
		public void ChangeState()
		{
			_state.ChangeState(this);
		}

		// public method for the change state of the clock to the next one
		public void IncrementValue()
		{
			_state.ChangeValue(this);
		}

		// public method that Depending on state increment something (like second,minutes or hour)
		public string GetCurrentClockValue()
		{
			return _state.ShowClockValue(this);
		}

		// run the clock's timer
		public void Start()
		{
			_timer.Enabled = true;
		}

		// pause/stop the clock's timer
		public void Stop()
		{
			_timer.Enabled = false;
		}

		// return status of the clock's timer
		public bool IsClockOn()
		{
			return _timer.Enabled;
		}
	}
}
