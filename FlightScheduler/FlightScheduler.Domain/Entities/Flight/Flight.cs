using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightScheduler.Domain.Entities.Flight;

public class Flight
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int FlightId { get; set; }
    public int RouteId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public short AirlineId { get; set; }

    #region Navigation

    public Route.Route Route { get; set; } = null!;

    #endregion
}

