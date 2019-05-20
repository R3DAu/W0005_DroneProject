using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AR.Drone.Client;
using AR.Drone.Data;
using AR.Drone.Data.Navigation;
using AR.Drone.Data.Navigation.Native;

namespace ConsoleController.src
{
    class Navigation
    {
        public NavigationData NavData;
        public NavigationPacket NavPacket;

        private DroneClient _client;

        public Navigation(DroneClient client)
        {
            _client = client;
        }
    }
}
