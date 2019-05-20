using AR.Drone.Client;
using System.Threading;
using System.Threading.Tasks;
using Con = System.Console;
using CKey = System.ConsoleKey;


namespace ConsoleController.src
{
    class Controller
    {
        //Drone and Drone Client variables
        private string _hostname = "192.168.1.1";
        private DroneClient _client;

        //Flightmode Variable.
        private readonly AR.Drone.Client.Command.FlightMode flightMode = AR.Drone.Client.Command.FlightMode.Progressive;

        //Flight float adjustment constants.
        const float YAWVAL = 0.25f;
        const float GAZVAL = 0.25f;
        const float ROLLVAL = 0.05f;
        const float PITCHVAL = 0.05f;

        //task cancellation variable (used for the BusyIndicator)
        private CancellationTokenSource _cancellationToken;

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
        /// Checks to see if the drone is connected to the computer
        /// </summary>
        public bool IsDroneConnected => _client.IsConnected;

        /// <summary>
        /// Returns battery usage information of the drone
        /// </summary>
        public float DroneBatteryPercentage => _client.NavigationData.Battery.Percentage;

        /// <summary>
        /// Returns whether the battery is low.
        /// </summary>
        public bool DroneBatteryLow => _client.NavigationData.Battery.Low;

        /// <summary>
        /// Sets up the basic settings for the drone. 
        /// </summary>
        private void DroneSetup()
        {
            _client = new DroneClient(_hostname);
        }
        
        /// <summary>
        /// Starting Procedure and key listeners for the console application.
        /// </summary>
        public void Start()
        {
            //we need to make sure we have a successful connection to the drone.
            var clientState = _client.IsConnected;
            var flightState = _client.NavigationData.State.HasFlag(AR.Drone.Data.Navigation.NavigationState.Flying);

            /*if (!clientState)
            {
                Con.Clear();
                Con.ForegroundColor = System.ConsoleColor.Red;
                Con.WriteLine("WARNING: The AR Drone is not connected. Please connect to the drone prior to flying.");
                Con.ReadKey();
                Con.ForegroundColor = System.ConsoleColor.White;
                return;
            }*/

            //initiates the client.
            _client.Start();

            //stop the cursor blink glitch.
            Con.CursorVisible = false;

            //start a cancel worker thread to listen for exit events like escape.
            Con.CancelKeyPress += (sender, e) =>
            {
                Con.WriteLine("Exiting...");
                return;
            };

            //now we can just start another worker thread for the application to read keys and control drone.
            var comKeys = new Task(ReadCommandKeys);

            //start the comKeys thread.
            comKeys.Start();

            var tasks = new[] { comKeys };
            Task.WaitAll(tasks);
        }

        /// <summary>
        /// Will wait for the command keys being sent.
        /// </summary>
        private void ReadCommandKeys()
        {
            //reset the cancellation token.
            _cancellationToken = new CancellationTokenSource();
            //update the busy status
            var busyStatus = new Task(BusyIndicator, _cancellationToken.Token);

            //start the status workers.
            busyStatus.Start();

            //this will be our worker thread.
            System.ConsoleKeyInfo cki = new System.ConsoleKeyInfo();
            //Clear the console.
            Con.Clear();

            //make room for the status' on the top of the page.
            Con.WriteLine(" ");
            Con.WriteLine(" ");
            Con.WriteLine(" ");
            Con.WriteLine(" ");

            //Instructions
            Con.WriteLine("Use your keyboard to control the drone, use the ESC key to exit");

            Con.WriteLine(" ");
            Con.ForegroundColor = System.ConsoleColor.Green;
            Con.WriteLine("W - Pitch Forward");
            Con.WriteLine("S - Pitch Back");
            Con.WriteLine("A - Roll Left");
            Con.WriteLine("D - Roll Right");
            Con.WriteLine(" ");

            Con.ForegroundColor = System.ConsoleColor.Blue;
            Con.WriteLine("Up Arrow    - Yaw Upwards");
            Con.WriteLine("Down Arrow  - Yaw Downwards");
            Con.WriteLine("Left Arrow  - Pitch Left");
            Con.WriteLine("Right Arrow - Pitch Right");
            Con.WriteLine(" ");

            Con.ForegroundColor = System.ConsoleColor.Yellow;
            Con.WriteLine("E - Emergency Land");
            Con.WriteLine("H - Hover");
            Con.WriteLine("T - Takeoff");
            Con.WriteLine("L - Land");

            do
            { 
                cki = Con.ReadKey(true);
                //time to check the key that was pressed.

                switch (cki.Key)
                {
                    case CKey.W:
                        _client.Progress(flightMode, pitch: PITCHVAL);
                        break;
                    case CKey.S:
                        _client.Progress(flightMode, pitch: -PITCHVAL);
                        break;
                    case CKey.A:
                        _client.Progress(flightMode, roll: -ROLLVAL);
                        break;
                    case CKey.D:
                        _client.Progress(flightMode, roll: ROLLVAL);
                        break;
                    case CKey.UpArrow:
                        _client.Progress(flightMode, gaz: GAZVAL);
                        break;
                    case CKey.DownArrow:
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        break;
                    case CKey.LeftArrow:
                        _client.Progress(flightMode, yaw: -YAWVAL);
                        break;
                    case CKey.RightArrow:
                        _client.Progress(flightMode, yaw: YAWVAL);
                        break;
                    case CKey.Spacebar:
                        //jump!
                        _client.Progress(flightMode, gaz: GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        Thread.Sleep(450);
                        _client.Progress(flightMode, gaz: -GAZVAL);
                        Thread.Sleep(450);

                        break;
                    case CKey.T:
                        _client.Takeoff();
                        break;
                    case CKey.L:
                        _client.Land();
                        break;
                    case CKey.H:
                        _client.Hover();
                        break;
                    case CKey.E:
                        _client.Emergency();
                        break;
                    case CKey.Escape:
                        break;
                }
            } while (cki.Key != CKey.Escape);
            
            //Tell the busyStatus to cancel and stop.
            _cancellationToken.Cancel();
           
        }

        /// <summary>
        /// Event: Changes the status values on the top of the console.
        /// </summary>
        private void BusyIndicator()
        {
            var busy = new ConsoleBusyIndicator(_cancellationToken.Token, _client);
            busy.UpdateProgress();
        }

        /// <summary>
        /// Internal Class for the status changer.
        /// </summary>
        internal class ConsoleBusyIndicator
        {
            int _currentBusySymbol;
            private CancellationToken _ct;
            private DroneClient _dc;

            public char[] BusySymbols { get; set; }

            public ConsoleBusyIndicator(CancellationToken token, DroneClient dc)
            {
                BusySymbols = new[] { '|', '/', '-', '\\' };
                _ct = token;
                _dc = dc;
            }

            public void UpdateProgress()
            {
                while (true)
                {
                    if (_ct.IsCancellationRequested)
                    {
                        Con.Clear();
                        Thread.Sleep(100);
                        return;
                    }
                    
                    Thread.Sleep(100);
                    var originalX = Con.CursorLeft;
                    var originalY = Con.CursorTop;

                   
                    if (_dc.IsConnected)
                        Con.ForegroundColor = System.ConsoleColor.Green;
                    else
                        Con.ForegroundColor = System.ConsoleColor.Red;

                    Con.SetCursorPosition(0, 0);
                    Con.WriteLine("Drone Connected: {0}", _dc.IsConnected.ToString());

                    Con.ForegroundColor = System.ConsoleColor.White;
                    Con.SetCursorPosition(0, 1);
                    var percentage = _dc.NavigationData.Battery.Percentage;

                    switch (percentage)
                    {
                        case var _ when percentage < 20.00f:
                            System.Console.ForegroundColor = System.ConsoleColor.Red;
                            System.Console.WriteLine("Drone Battery: {0}%", percentage.ToString());
                            break;
                        case var _ when percentage > 20.01f && percentage < 60.00f:
                            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                            System.Console.WriteLine("Drone Battery: {0}%", percentage.ToString());
                            break;
                        case var _ when percentage > 60.01f:
                            System.Console.ForegroundColor = System.ConsoleColor.Green;
                            System.Console.WriteLine("Drone Battery: {0}%", percentage.ToString());
                            break;
                    }
                    System.Console.ForegroundColor = System.ConsoleColor.White;

                    Con.SetCursorPosition(0, 2);
                    Con.WriteLine(BusySymbols[_currentBusySymbol]);

                    if(_dc.NavigationData.State.HasFlag(AR.Drone.Data.Navigation.NavigationState.Flying) || _dc.NavigationData.State.HasFlag(AR.Drone.Data.Navigation.NavigationState.Hovering))
                    _currentBusySymbol++;

                    if (_currentBusySymbol == BusySymbols.Length)
                    {
                        _currentBusySymbol = 0;
                    }

                    Con.SetCursorPosition(originalX, originalY);
                }
            }
        }
    }
}
