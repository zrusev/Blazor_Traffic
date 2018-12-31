namespace Blazor_Traffic.Shared
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class StopTimes
    {
        public string Timing { get; set; }

        public DateTime[] Times => this.Timing
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(e => e.IndexOf("24:") > -1
                    ? DateTime.ParseExact(e.Replace("24:", "00:"), "HH:mm:ss", CultureInfo.InvariantCulture)
                        .AddDays(1)
                    : DateTime.ParseExact(e, "HH:mm:ss", CultureInfo.InvariantCulture))
            .Where(t => t > DateTime.UtcNow.AddHours(2))
            .ToArray();

        public int RouteId { get; set; }

        public int Type { get; set; }

        public string TransportType
        {
            get
            {
                switch (this.Type)
                {
                    case 0: return "Трамвай";
                    case 1: return "Автобус";
                    case 2: return "Тролейбус";
                    default: return string.Empty;
                }
            }
        }

        public int LineId { get; set; }

        public string LineName { get; set; }
    }
}
