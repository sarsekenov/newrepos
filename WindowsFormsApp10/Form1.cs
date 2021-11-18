using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        string dataOut;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox_Ports.Items.AddRange(ports);
            serialPort1.ReadTimeout = 500;
            serialPort1.WriteTimeout = 500;
        }

        private void buttonOPen_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox_Ports.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_Rate.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBox_Dbits.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBox_Sbits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBox_Pbits.Text);
                serialPort1.Open();
                progressBar1.Value = 100;
            }
            catch (Exception err) {
                MessageBox.Show(err.Message,"Ошибка у вас сударь!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) {
                serialPort1.Close();
                progressBar1.Value = 0;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) {
                dataOut = tb_DataOut.Text;
                serialPort1.Write(dataOut);
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            MessageBox.Show("Информация отправлена");
        }
    }
}
