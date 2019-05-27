using AR.Drone.Client;
using System;
using System.Windows.Forms;
using System.Threading; 

namespace ARDrone2_Controller
{
    public partial class Form1 : Form
    {

        DroneClient _droneClient = null;

        // public Controller
        public Form1()
        {
            _droneClient = new DroneClient();

            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            
        }

        private void TakeOff(object sender, EventArgs e)
        {
            
        }

        private void Land(object sender, EventArgs e)
        {
            
        }

        private void Hover(object sender, EventArgs e)
        {
        }

        // pitch ++
        private void PitchUp(object sender, EventArgs e)
        {
            
        }


        // pitch --
        private void PitchDown(object sender, EventArgs e)
        {
           
        }

        // yaw ++
        private void YawUp(object sender, EventArgs e)
        {
          
        }

        // yaw --
        private void YawDown(object sender, EventArgs e)
        {
           
        }

        // roll left
        private void RollLeft(object sender, EventArgs e)
        {
            
        }

        // roll right
        private void RollRight(object sender, EventArgs e)
        {
            
        }

        // pitch left
        private void PitchLeft(object sender, EventArgs e)
        {
            
        }

        // pitch right
        private void PitchRight(object sender, EventArgs e)
        {
            
        }

        // emergency
        private void Emergency(object sender, EventArgs e)
        {
            
        }

        // stop
        private void Stop(object sender, EventArgs e)
        {

        }

        // jump
        private void Jump(object sender, EventArgs e)
        {
            
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
