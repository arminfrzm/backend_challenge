using CsvHelper.Configuration.Attributes;

namespace FlightScheduler.Data.DTOs
{
    public class CsvRoute
    {
        [Index(0)]
        public string route_id { get; set; }
        [Index(1)]
        public string origin_city_id { get; set; }
        [Index(2)]
        public string destination_city_id { get; set; }
        [Index(3)]
        public string departure_date { get; set; }
    }
}
