using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3___Car_SystemForCsharp
{
    public partial class Form1 : Form
    {
        bool toggle = false;    // toggle message send
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) 
        { 
            serialPort1.Close();
        }
        private void btnReadSerial_Click(object sender, EventArgs e)
        {
            if (toggle)
            {
                serialPort1.WriteLine("normal");
            }
            else
            {
                serialPort1.WriteLine("hazard");
            }
            toggle = !toggle;
        }

        private void lbLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
          
        }

        private void tbTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbHeadLight_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (serialPort1.BytesToRead > 0)
            {
                string message = serialPort1.ReadLine();
                message = message.Trim();
                if (message == "ON")
                {
                    tbHeadLight.Text = "ON";
                    Refresh();
                }
                else if (message == "OFF")
                {
                    tbHeadLight.Text = "OFF";
                    Refresh();
                }
                else
                {
                    tbTemp.Text = message;
                }
            }
        }
    }
}
