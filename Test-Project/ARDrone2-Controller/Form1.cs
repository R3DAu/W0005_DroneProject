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

namespace ARDrone2_Controller
{
    public partial class Form1 : Form
    {

        DroneClient _droneClient = null;

        // value
        const float YAWVAL = 0.25f;
        const float GAZVAL = 0.25f;
        const float ROLLVAL = 0.05f;
        const float PITCHVAL = 0.05f;

        // public Controller
        public Form1()
        {
            _droneClient = new DroneClient();

            InitializeComponent();
        }

        private string Start(object sender, EventArgs e)
        {
            return execute("Start");
        }

        private void TakeOff(object sender, EventArgs e)
        {
            _droneClient.Takeoff();
        }

        private void Land(object sender, EventArgs e)
        {
            _droneClient.Land();
        }

        private void Hover(object sender, EventArgs e)
        {
            _droneClient.Hover();
        }

        // pitch ++
        private void PitchUp(object sender, EventArgs e)
        {
            // const float PITCHVAL = 0.05f;
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, pitch: PITCHVAL);
        }


        // pitch --
        private void PitchDown(object sender, EventArgs e)
        {
            // const float PITCHVAL = 0.05f;
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, pitch: -PITCHVAL);
        }

        // yaw ++
        private void YawUp(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
        }

        // yaw --
        private void YawDown(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
        }

        // roll left
        private void RollLeft(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, roll: -ROLLVAL);
        }

        // roll right
        private void RollRight(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, roll: ROLLVAL);
        }

        // pitch left
        private void PitchLeft(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, yaw: -YAWVAL);
        }

        // pitch right
        private void PitchRight(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, yaw: YAWVAL);
        }

        // emergency
        private void Emergency(object sender, EventArgs e)
        {
            _droneClient.Emergency();
        }

        // stop
        private void Stop(object sender, EventArgs e)
        {

        }

        // jump
        private void Jump(object sender, EventArgs e)
        {
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: GAZVAL);
            Thread.Sleep(4000);
            _droneClient.Progress(AR.Drone.Client.Command.FlightMode.Progressive, gaz: -GAZVAL);
            Thread.Sleep(4000);
            _droneClient.Hover();
        }

        // Height ++
        private void HeightUp(object sender, EventArgs e)
        {

        }

        // height --
        private void HeightDown(object sender, EventArgs e)
        {

        }

        // fly a circle 
        private void Circle(object sender, EventArgs e)
        {

        }

        // Figure-8
        private void Figure8(object sender, EventArgs e)
        {

        }

        // Helix
        private void Helix(object sender, EventArgs e)
        {

        }

        // Readout screen
        // drone angles and altitude and battery level
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //battery level
            var percentage = _droneClient.NavigationData.Battery.Percentage;
            txtDisplay.Text = "The battery percentage " + percentage.ToString();
            //connection
            if (_droneClient.IsConnected)
            {
                txtDisplay.Text = " Drone Connected: " + _droneClient.IsConnected.ToString();
            }
            // drone angles
            // do something here
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private string execute(string command)
        {
            string actions = "";

            switch (command)
            {
                case "Start":
                    _droneClient.Start();
                    actions += command + " ";
                    break;
            }

            return "Failed";
        }
    }
}
