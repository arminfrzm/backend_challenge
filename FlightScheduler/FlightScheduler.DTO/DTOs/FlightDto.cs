namespace FlightScheduler.DTO.DTOs;

public class FlightDto
{
    public int FlightId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public short AirlineId { get; set; }
    public FlightStatus FlightStatus { get; set; }
}

public enum FlightStatus
{
    New,
    Discontinued,
    Normal
}