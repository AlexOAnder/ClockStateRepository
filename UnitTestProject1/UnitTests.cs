using System;
using System.Threading;
using ClockLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTests
	{
		private Clock _clock;

		[TestInitialize]
		public void Init()
		{
			_clock = new Clock();
		}

		[TestMethod]
		public void GetCurrentClockValueTest()
		{
			//after constructor work we must have initialized fields 
			var res = _clock.GetCurrentClockValue();
			Assert.AreEqual("00:00:00",res);
		}

		[TestMethod]
		public void CheckTickMethod()
		{
			// after clock start Tick method increment seconds by 1 every second
			_clock.Start();
			Thread.Sleep(1400); // 400 ms for the test work. In that 400 ms value in clock must be 00:00:01
			Assert.AreEqual(1,_clock.Seconds);
			Assert.AreEqual("00:00:01", _clock.GetCurrentClockValue());
			Thread.Sleep(1400);
			Assert.AreEqual(2, _clock.Seconds);
			Assert.AreEqual("00:00:02", _clock.GetCurrentClockValue());
		}

		[TestMethod]
		public void IsClockOn()
		{
			_clock.Start();
			var b = _clock.IsClockOn();
			// after start method IsClockOn must return true. That mean clock is working now
			Assert.IsTrue(b);
			_clock.Stop();
			// after stop clock pausing its work
			b = _clock.IsClockOn();
			Assert.IsFalse(b);
		}

		[TestMethod]
		public void ChangeStateToChangeHours()
		{
			_clock.ChangeState(); // state Configurate Hours
			_clock.IncrementValue(); // must increment hours
			// hours changed
			Assert.AreEqual(1, _clock.Hours);
			Assert.AreEqual(0, _clock.Minutes);
			Assert.AreEqual(0, _clock.Seconds);
			
		}

		[TestMethod]
		public void ChangeStateToChangeMinutes()
		{
			_clock.ChangeState(); // state Configurate Hours
			_clock.ChangeState(); // state Configurate Minutes
			_clock.IncrementValue(); // must increment minutes
			// hours changed
			Assert.AreEqual(0, _clock.Hours);
			Assert.AreEqual(1, _clock.Minutes);
			Assert.AreEqual(0, _clock.Seconds);
		}

		[TestMethod]
		public void ChangeStateToChangeSeconds()
		{
			_clock.ChangeState(); // state Configurate Hours
			_clock.ChangeState(); // state Configurate Minutes
			_clock.ChangeState(); // state Configurate Seconds
			_clock.IncrementValue(); // must increment seconds
			// hours changed
			Assert.AreEqual(0, _clock.Hours);
			Assert.AreEqual(0, _clock.Minutes);
			Assert.AreEqual(1, _clock.Seconds);
		}

		[TestMethod]
		public void CheckIncrementValueMethodInShowClockState()
		{
			_clock.ChangeState(); // state Configurate Hours
			_clock.IncrementValue(); // must increment Hours
			_clock.ChangeState(); // state Configurate Minutes
			_clock.IncrementValue(); // must increment minutes
			_clock.ChangeState(); // state Configurate Seconds
			_clock.IncrementValue(); // must increment seconds
			_clock.ChangeState(); // return back to ShowClock mode
			// in that state that method resets all values to 0
			_clock.IncrementValue(); // must reset values
			// hours changed
			Assert.AreEqual(0, _clock.Hours);
			Assert.AreEqual(0, _clock.Minutes);
			Assert.AreEqual(0, _clock.Seconds);
		}
	}
}
