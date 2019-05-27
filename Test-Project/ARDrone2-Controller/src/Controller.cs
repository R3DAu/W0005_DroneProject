using AR.Drone.Client;

namespace ATeam_DroneController.src
{
    public class Controller
    {
        private string _hostname = "192.168.1.1";
        private DroneClient _client;

        //Flight float adjustment constants.
        const float YAWVAL = 0.25f;
        const float GAZVAL = 0.25f;
        const float ROLLVAL = 0.05f;
        const float PITCHVAL = 0.05f;

        /// <summary>
        /// Constructor Class
        /// </summary>
        /// <param name="hostname">Requires a hostname parameter default: 192.168.1.1</param>
        public Controller(string hostname)
        {
            _hostname = hostname;

            //setup the drone client.
            DroneSetup();
        }

        /// <summary>
        /// Constructor Class
        /// </summary>
        public Controller()
        {
            //setup the drone client.
            DroneSetup();
        }

        /// <summary>
        /// Sets up the basic settings for the drone. 
        /// </summary>
        private void DroneSetup()
        {
            _client = new DroneClient(_hostname);
        }

        public void Land()
        {
            _client.Land();
        }

        public void TakeOff()
        {
            _client.Takeoff();
        }

    }
}
