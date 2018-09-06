using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budzik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Hide();
            timer1.Enabled = false;
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            timer1.Enabled = true;
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Close();
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = "Time and Date: " + DateTime.Now.ToShortTimeString() + ", " + DateTime.Now.ToShortDateString();

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            string s = "Date: " + DateTime.Today.ToLongDateString();
            string[] DayOfTheWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            byte NumberDayOfTheWeek = (byte)DateTime.Now.DayOfWeek;
            s += "\nDay of the week: " + DayOfTheWeek[NumberDayOfTheWeek];
            s += "\nDay of the year: " + DateTime.Now.DayOfYear;
            s += "\nTime: " + DateTime.Now.ToLongTimeString();
            notifyIcon1.BalloonTipText = s;
            notifyIcon1.ShowBalloonTip(20000);
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime nextFullHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0, 0);
            long howManyMilisecondsToFullHour = (nextFullHour.Ticks - DateTime.Now.Ticks) / 10000;
            timer2.Interval = (int)howManyMilisecondsToFullHour;
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 3600000;
            (new System.Media.SoundPlayer("sound.wav")).Play();
            notifyIcon1_DoubleClick(sender, e);
        }
    }
}
