using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Media;

namespace For_Soha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PortBarlaweDak();
        }
        private void PortBarlaweDak()
        {
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
            else
            {
                // Get a list of serial port names.
                string[] ports = SerialPort.GetPortNames();
                Console.WriteLine(ports);
                // Display each port name to the console.
                foreach (string port in ports)
                {
                    serialPort1.PortName = port;
                }
                try
                {
                    serialPort1.Open();
                }
                catch (Exception)
                {
                    MessageBox.Show("Maglumat beriji enjamlar bilen baglanyşyk kesildi! Baglanyşygy barlaň!");
                    Form1_Load(MessageBoxButtons.OKCancel, null);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadLine();
            data = data.TrimEnd(new char[] { '\r', '\n' });
            Console.WriteLine(data.ToString());
            string az = data.ToString();
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    yazdyr(az);
                }));
            }
        }

        private void yazdyr(string data)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.URL = "C:/Users/" + Environment.UserName + "/Music/Soha/" + data + ".mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
