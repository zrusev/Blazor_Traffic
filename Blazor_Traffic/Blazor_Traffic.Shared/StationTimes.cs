namespace Blazor_Traffic.Shared
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class StationTimes
    {
        public string Route_1 { get; set; }

        public DateTime[] Route_1_Times => this.Route_1
            .Split(',')
            .Select(e => e.IndexOf("24:") > -1 
                    ? DateTime.ParseExact(e.Replace("24:", "00:"), "HH:mm", CultureInfo.InvariantCulture)
                        .AddDays(1)
                    : DateTime.ParseExact(e, "HH:mm", CultureInfo.InvariantCulture))
            .Where(t => t > DateTime.UtcNow.AddHours(2))
            .Take(5)
            .ToArray();

        public string Route_2 { get; set; }

        public DateTime[] Route_2_Times => this.Route_2
            .Split(',')
            .Select(e => e.IndexOf("24:") > -1
                    ? DateTime.ParseExact(e.Replace("24:", "00:"), "HH:mm", CultureInfo.InvariantCulture)
                        .AddDays(1)
                    : DateTime.ParseExact(e, "HH:mm", CultureInfo.InvariantCulture))
            .Where(t => t > DateTime.UtcNow.AddHours(2))
            .Take(5)
            .ToArray();

        public string Route_1_name { get; set; }

        public string Route_1_Direction => this.Route_1_name.Split(new string[] { " - " }, StringSplitOptions.None)[1];

        public string Route_2_name { get; set; }

        public string Route_2_Direction => this.Route_2_name.Split(new string[] { " - " }, StringSplitOptions.None)[1];    
    }
}
