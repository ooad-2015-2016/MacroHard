using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShEM.BazaPodataka.Static_variables
{
    public class StaticVariablesClass
    {
        private static int port = 3000;
        private static string ipAddress = "192.168.0.106";

        public string getIP
        {
            get { return ipAddress; }
        } 

        public int getPort
        {
            get
            {
                return port;
            }
        }
    }
}
