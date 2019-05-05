using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleController.src
{
    class Console
    {
        private Controller _controller;

        public Console()
        {
            _controller = new Controller();
        }

        public void Menu()
        {
            int _controlKey;

            System.Console.WriteLine("Please select from the following menu items:");
            System.Console.WriteLine("1. Start Drone");
            System.Console.WriteLine("2. Land Drone");
            System.Console.WriteLine("3. Fly Control");

            while (!int.TryParse(System.Console.ReadLine(), out _controlKey))
            {
                System.Console.Clear();
                System.Console.WriteLine("Please select from the following menu items:");
                System.Console.WriteLine("1. Start Drone");
                System.Console.WriteLine("2. Land Drone");
                System.Console.WriteLine("3. Fly Control");
            }

            switch (_controlKey)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    _controller.ReadCommandKeys();
                    break;
            }
                
        }
    }
}
