using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsAppBluetoothProject
{
    public partial class Form1 : Form
    {
        List<string> items;
        public Form1()
        {
            InitializeComponent();
            items = new List<string>();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonServer_Click(object sender, EventArgs e)
        {
            startScan();
        }

        private void startScan()
        {
            listBoxItem.DataSource = null;  //before every scan
            listBoxItem.Items.Clear();
            items.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(scan));
            bluetoothScanThread.Start();
        }

        BluetoothDeviceInfo[] devices;
        public void scan()
        {
            updatedUI("Start Scan....");
            BluetoothClient client = new BluetoothClient();
            devices = client.DiscoverDevicesInRange();
            updatedUI("Scan Complete");
            updatedUI(devices.Length.ToString() + "  Devise Discovered");
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName);
            }
            updateDeviceList();
        }

        public void updateDeviceList()
        {
            Func<int> del = delegate ()
            {
                listBoxItem.DataSource = items;
                return 0;
            };
            Invoke(del);

        }

        private void buttonClient_Click(object sender, EventArgs e)
        {

        }

        public void updatedUI(string message)
        {
            Func<int> del = delegate ()
            {
                richTextBoxConnection.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);
        }


        private void listBoxItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void textBoxMessage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void listBoxItem_DoubleClick(object sender, EventArgs e)
        {
        }
    }
}
