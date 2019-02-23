using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        string gun, saat;
        bool tf = true;
        //SoundPlayer alarm = new SoundPlayer();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            player.SoundLocation = "../alarm.wav";
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            gun = dateTimePicker1.Text;
            saat = maskedTextBox1.Text;
            timer2.Start();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            player.Stop();
            timer4.Stop();
            timer4.Interval = 100;
            pictureBox1.Image = Image.FromFile("../Pics/1.jpg");
            richTextBox1.BackColor = Color.White;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (gun == DateTime.Now.ToLongDateString() && saat == DateTime.Now.ToShortTimeString())
            {
                Show();
                notifyIcon1.Visible = false;
                this.WindowState = FormWindowState.Normal;
                timer3.Start();
                timer4.Start();
                pictureBox1.Image = Image.FromFile("../Pics/2.gif");
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (tf == false)
            {
                richTextBox1.BackColor = Color.Red;
                tf = true;
            }
            else
            {
                richTextBox1.BackColor = Color.White;
                tf = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            player.Play();
            timer4.Interval = 5000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
