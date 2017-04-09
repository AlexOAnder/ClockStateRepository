using System;
using System.Drawing;
using System.Windows.Forms;
using ClockLibrary;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		readonly Button _buttonA;
		readonly Button _buttonB;
		readonly Button _buttonC;
		private Clock cl;
		private readonly Label _l;
		public Form1()
		{
			cl = new Clock();
			_buttonA = new Button
			{
				Text = "A",
				Size = new Size(60, 20),
				Location = new Point(20, 40)
			};
			_buttonB = new Button
			{
				Text = "B",
				Size = new Size(60, 20),
				Location = new Point(90, 40),
			};
			_buttonC = new Button
			{
				Text = @"Stop",
				Size = new Size(60, 20),
				Location = new Point(160, 40),
			};
			_l = new Label
			{
				Text = @"Here must be a clock",
				Size = new Size(300, 50),
				Location = new Point(10, 10),
				Font = new Font("Arial",18)
			};
			this.Controls.Add(_buttonA);
			this.Controls.Add(_buttonB);
			this.Controls.Add(_buttonC);
			this.Controls.Add(_l);
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cl.Start();
			// run the timer for the clock's value update on form
			Timer tm = new Timer {Interval = 100};
			tm.Tick += UpdateClock;
			tm.Enabled = true;
		}


		private void UpdateClock(object sender, EventArgs eventArgs)
		{
			_l.Text = cl.GetCurrentClockValue();
		}

		private void ButtonA_Click(object sender, EventArgs e)
		{
			cl.ChangeState();
		}

		private void ButtonB_Click(object sender, EventArgs e)
		{
			cl.IncrementValue();
		}

		private void ButtonC_Click(object sender, EventArgs e)
		{
			if (cl.IsClockOn())
			{
				cl.Stop();
				this._buttonC.Text = @"Start";
			}
			else
			{
				cl.Start();
				this._buttonC.Text = @"Stop";
			}
		}
	}
}
