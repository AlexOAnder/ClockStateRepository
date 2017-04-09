namespace ClockLibrary
{
	class ClockStateChangeHours : IClockState
	{
		public void ChangeState(Clock context)
		{
			context.SetState(new ClockStateChangeMinutes());
		}

		public void ChangeValue(Clock context)
		{
			context.ChangeValue(ClockIdentifiersEnum.Hours);
		}

		public string ShowClockValue(Clock context)
		{
			return context.CurrentValue() + " -> Hours";
		}
	}

	class ClockStateChangeMinutes : IClockState
	{
		public void ChangeState(Clock context)
		{
			context.SetState(new ClockStateChangeSeconds());
		}

		public void ChangeValue(Clock context)
		{
			context.ChangeValue(ClockIdentifiersEnum.Minutes);
		}

		public string ShowClockValue(Clock context)
		{
			return context.CurrentValue() + " -> Minutes";
		}
	}

	class ClockStateChangeSeconds : IClockState
	{
		public void ChangeState(Clock context)
		{
			context.SetState(new ClockStateShowClock());
		}

		public void ChangeValue(Clock context)
		{
			context.ChangeValue(ClockIdentifiersEnum.Seconds);
		}

		public string ShowClockValue(Clock context)
		{
			return context.CurrentValue() + " ->Seconds";
		}
	}

	class ClockStateShowClock : IClockState
	{
		public void ChangeState(Clock context)
		{
			context.SetState(new ClockStateChangeHours());
		}

		public void ChangeValue(Clock context)
		{
			// hard reset
			context.Hours = 0;
			context.Minutes = 0;
			context.Seconds = 0;
		}

		public string ShowClockValue(Clock context)
		{
			return context.CurrentValue();
		}
	}

}
