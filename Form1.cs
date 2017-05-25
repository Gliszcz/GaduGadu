using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace GaduGadu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener serwer = null;
        private TcpClient client = null;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            IPAddress adressIP = null;
            try
            {
                adressIP = IPAddress.Parse(txtb_adress.Text);
            }
            catch
            {
                MessageBox.Show("WRONG IP ADRESS", "ERROR");
                txtb_adress.Text = string.Empty;
                return;
            }

            int port = System.Convert.ToInt32(nud_port.Value);
            try
            {
                serwer = new TcpListener(adressIP, port);
                serwer.Start();

                client =serwer.AcceptTcpClient();
                listBox_info.Items.Add("connected");
                btn_start.Enabled = false;
                btn_stop.Enabled = true;

                client.Close();
                serwer.Stop();
            }
            catch (Exception ex)
            {
                listBox_info.Items.Add("ERROR");
                MessageBox.Show(ex.ToString(), "ERROR");
            }
        }
    }
}
