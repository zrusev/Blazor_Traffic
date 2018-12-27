namespace Blazor_Traffic.Shared
{
    public class Station
    {
        public int Id { get; set; }

        public int Route_id { get; set; }

        public int Code { get; set; }

        public int Point_id { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
