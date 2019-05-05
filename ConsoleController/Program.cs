using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleController.src;

namespace ConsoleController
{
    class Program
    {
        static void Main(string[] args)
        {
            src.Console console = new src.Console();
            console.Menu();


            System.Console.WriteLine("This application is shit so far!");
            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadLine();
        }
    }
}
