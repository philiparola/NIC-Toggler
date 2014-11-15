using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIC_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enable VPN or Home (the other will be disabled).");
            string interfaceChoice = Console.ReadLine();
            interfaceChoice = interfaceChoice.ToLower();
            while (interfaceChoice != "vpn" && interfaceChoice != "home")
            {
                Console.WriteLine("Type out the full adapter name.");
                interfaceChoice = Console.ReadLine();
                interfaceChoice = interfaceChoice.ToLower();
            }

            if (interfaceChoice == "VPN")
            {
                Enable(interfaceChoice);
                string altNIC = "Home";
                Disable(altNIC);
            }

            if (interfaceChoice == "Home")
            {
                Enable(interfaceChoice);
                string altNIC = "VPN";
                Disable(altNIC);
            }

        }

        //The following is shamelessly ripped from http://stackoverflow.com/questions/172875/how-to-disable-enable-network-connection-in-c-sharp
        static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                   new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }

        static void Disable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}
