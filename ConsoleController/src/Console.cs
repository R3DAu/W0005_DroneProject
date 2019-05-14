using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleController.src
{
    class Console
    {
        private Controller _controller;

        public Console()
        {
            System.Console.Title = "[WARDCC] W005 - AR Drone Controller Console";
            _controller = new Controller();
        }

        private void MenuItems()
        {
            System.Console.Clear();

            System.Console.WriteLine("\n");

            //let's do some simple status checks here.
            if (_controller.IsDroneConnected)
            {
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Drone Connection: Active");

                var percentage = _controller.DroneBatteryPercentage;

                switch (percentage)
                {
                    case var _ when percentage < 20.00f:
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Drone Battery: {0}", percentage.ToString());
                        break;
                    case var _ when percentage > 20.01f && percentage < 60.00f:
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.WriteLine("Drone Battery: {0}", percentage.ToString());
                        break;
                    case var _ when percentage > 60.01f:
                        System.Console.WriteLine("Drone Battery: {0}", percentage.ToString());
                        break;
                }
                System.Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Drone Connection: Not found.");
                System.Console.ForegroundColor = ConsoleColor.White;
            }

            System.Console.WriteLine("\n");

            System.Console.WriteLine("Please select from the following menu items:");
            System.Console.WriteLine("1. Fly Control");
            System.Console.WriteLine("2. Exit");
        }

        public void Menu()
        {
            int _controlKey;

            Thread.Sleep(200);
            MenuItems();
           
            while (!int.TryParse(System.Console.ReadLine(), out _controlKey))
                MenuItems();
            

            switch (_controlKey)
            {
                case 1:
                    _controller.Start();
                    break;
                case 2:
                    return;
            }

            //return back to the menu.
            Menu();
        }
    }
}
