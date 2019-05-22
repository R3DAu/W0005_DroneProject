using AR.Drone.Client;
using AR.Drone.Client.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //  Cancellation Token

namespace ConsoleController.src
{
    public partial class Form1 : Form
    {
        Controller _controller = null;
        DroneClient _droneClient = null;
        CancellationTokenSource _cancellationToken = null;

        // value
        const float YAWVAL = 0.25f;
        const float GAZVAL = 0.25f;
        const float ROLLVAL = 0.05f;
        const float PITCHVAL = 0.05f;

        // command

        public Form1()
        {
            _controller = new Controller("192.168.1.1");
            _droneClient = new DroneClient();
            _cancellationToken = new CancellationTokenSource();
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _controller.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _droneClient.Takeoff();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _droneClient.Land();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _droneClient.Hover();
        }

        // pitch ++
        private void button5_Click(object sender, EventArgs e)
        {
            // const float PITCHVAL = 0.05f;
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, pitch: PITCHVAL);
        }


        // pitch --
        private void button6_Click(object sender, EventArgs e)
        {
            // const float PITCHVAL = 0.05f;
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, pitch: - PITCHVAL);
        }

        // yaw ++
        private void button7_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
        }

        // yaw --
        private void button8_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
        }

        // roll left
        private void button9_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, roll: -ROLLVAL);
        }

        // roll right
        private void button10_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, roll: ROLLVAL);
        }

        // pitch left
        private void button11_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, yaw: -YAWVAL);
        }

        // pitch right
        private void button12_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, yaw: YAWVAL);
        }

        // emergency
        private void button13_Click(object sender, EventArgs e)
        {
            _droneClient.Emergency();
        }

        // stop
        private void button14_Click(object sender, EventArgs e)
        {
            _cancellationToken.Cancel();
        }

        // jump
        private void button15_Click(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(450);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(450);
        }

        // Height ++
        private void button16_Click(object sender, EventArgs e)
        {

        }

        // height --
        private void button17_Click(object sender, EventArgs e)
        {

        }

        // fly a circle 
        private void button18_Click(object sender, EventArgs e)
        {
            
        }

        // Figure-8
        private void button20_Click(object sender, EventArgs e)
        {

        }

        // Felix
        private void button19_Click(object sender, EventArgs e)
        {
           
        }

        // Readout screen
        // drone angles and altitude and battery level
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //battery level
            var percentage = _controller.DroneBatteryPercentage;
            txtDisplay.Text = "The battery percentage " + percentage.ToString();           
            //connection
            if(_droneClient.IsConnected)
            {
                txtDisplay.Text = " Drone Connected: " + _droneClient.IsConnected.ToString();
            }
            // drone angles
            // do something here
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
