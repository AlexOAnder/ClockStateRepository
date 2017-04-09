namespace WindowsFormsApplication1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(270, 80);
			this.Name = "Form1";
			this.Text = "Clock State";
			this.Load += new System.EventHandler(this.Form1_Load);
			_buttonA.Click += new System.EventHandler(this.ButtonA_Click);
			_buttonB.Click += new System.EventHandler(this.ButtonB_Click);
			_buttonC.Click += new System.EventHandler(this.ButtonC_Click);
			this.ResumeLayout(false);

		}

		#endregion
	}
}

