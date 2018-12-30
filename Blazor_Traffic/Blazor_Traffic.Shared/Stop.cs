namespace Blazor_Traffic.Shared
{
    public class Stop
    {
        public int StopCode { get; set; }

        public int[] LineTypes { get; set; }

        public string StopName { get; set; }

        public decimal[] Coordinates { get; set; }
    }
}
