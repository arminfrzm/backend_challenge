namespace FlightScheduler.Data.DTOs
{
    public class CsvFlight
    {
        public string flight_id { get; set; }
        public string route_id { get; set; }
        public string departure_time { get; set; }
        public string arrival_time { get; set; }
        public string airline_id { get; set; }
    }
}
