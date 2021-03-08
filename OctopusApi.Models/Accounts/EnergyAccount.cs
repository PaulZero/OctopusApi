using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctopusApi.Accounts
{
    public class EnergyAccount
    {
        public string AccountNumber { get; set; }

        public string ApiKey { get; set; }

        public EnergyMeter[] Meters { get; set; }
    }
}
