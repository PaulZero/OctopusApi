using OctopusApi.Consumption;
using System;
using System.Linq;

namespace OctopusApi.Client.Responses
{
    public class GetConsumptionResult
    {
        public bool HasItems => Items.Length > 0;

        public ConsumptionUnit Unit { get; set; }

        public ConsumptionItem[] Items
        {
            get => _items;
            set {
                _items = value ?? Array.Empty<ConsumptionItem>();

                Refresh();
            }
        }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public double TotalConsumption { get; private set; }

        private ConsumptionItem[] _items = Array.Empty<ConsumptionItem>();

        private void Refresh()
        {
            Start = default;
            End = default;
            TotalConsumption = default;

            if (HasItems)
            {
                Start = Items.Min(i => i.IntervalStart);
                End = Items.Max(i => i.IntervalEnd);
                TotalConsumption = Items.Sum(i => i.Consumption);
            }
        }
    }
}
