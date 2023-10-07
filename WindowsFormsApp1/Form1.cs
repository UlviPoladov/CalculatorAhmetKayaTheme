using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using NAudio.Wave;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFile;
        double num1 = 0;
        double num2 = 0;
        string operatorforcalculator = "";
        public Form1()
        {
            InitializeComponent();       
            waveOutDevice = new WaveOut(); 
            audioFile = new AudioFileReader("kumgibi.mp3"); 
            waveOutDevice.Init(audioFile);
            audioFile.Volume = 0.2f;
            if (waveOutDevice.PlaybackState == PlaybackState.Playing)
            {
                waveOutDevice.Stop();
                audioFile.Position = 0;
            }
            waveOutDevice.Play();
        }
        private void reqembutton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
        }

        private void opartorbutton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (double.TryParse(textBox1.Text, out num1)) 
            {
                operatorforcalculator = button.Text;
                textBox1.Clear();
            }
            else
            {
                
                MessageBox.Show("Reqem Daxil Edin");
                textBox1.Clear();
            }
        }

        private void bereberdibutton(object sender, EventArgs e)
        {
            num2 = double.Parse(textBox1.Text);
            double son = 0;

            switch (operatorforcalculator)
            {
                case "+":
                    son = num1 + num2;
                    break;
                case "-":
                    son = num1 - num2;
                    break;
                case "*":
                    son = num1 * num2;
                    break;
                case "/":
                    son = num1 / num2;
                    break;
            }

            textBox1.Text = son.ToString();
        }

        private void clearbutton(object sender, EventArgs e)
        {
            textBox1.Clear();
            num1 = 0;
            num2 = 0;
            operatorforcalculator = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void XButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void maximazedbutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        int mouseX, mouseY;


        private void borderlbl_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;

            timer1.Enabled = true;
        }

        private void borderlbl_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }
        
    }
}
