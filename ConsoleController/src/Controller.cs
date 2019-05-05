using AR.Drone.Client;

namespace ConsoleController.src
{
    class Controller
    {
        private string _hostname = "192.168.1.1";
        private DroneClient _client;

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


        public void ReadCommandKeys()
        {
            System.ConsoleKeyInfo cki;
            System.Console.TreatControlCAsInput = true;

            System.Console.Clear();
            System.Console.WriteLine("Use your WSAD keys to control the drone, use the ESC key to exit");

            do
            {
                cki = System.Console.ReadKey();
                System.Console.Clear();

                System.Console.WriteLine("Use your WSAD keys to control the drone, use the ESC key to exit");

                string ckey = cki.Key.ToString();

                switch (ckey)
                {
                    case "W":
                        System.Console.WriteLine("You moved the drone up");
                        break;
                    case "A":
                        System.Console.WriteLine("You moved the drone left");
                        break;
                    case "S":
                        System.Console.WriteLine("You moved the drone down");
                        break;
                    case "D":
                        System.Console.WriteLine("You moved the drone right");
                        break;
                    case "Escape":
                        break;
                    default:
                        System.Console.WriteLine(ckey);
                        System.Console.WriteLine("I don't understand that command!");
                        break;
                }
            } while (cki.Key != System.ConsoleKey.Escape);

            System.Console.TreatControlCAsInput = false;
        }

    }
}
