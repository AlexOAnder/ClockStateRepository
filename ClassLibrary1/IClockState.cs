namespace ClockLibrary
{
	public interface IClockState
	{
		void ChangeState(Clock context);
		void ChangeValue(Clock context);
		string ShowClockValue(Clock context);
	}

}
