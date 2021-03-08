using OctopusApi.Enums;

namespace OctopusApi.Accounts
{
    public class EnergyMeter
    {
        public string Identifier { get; set; }

        public string SerialNumber { get; set; }

        public EnergyType Type { get; set; }
    }
}
