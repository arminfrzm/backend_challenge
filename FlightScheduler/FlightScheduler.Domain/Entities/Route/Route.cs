using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightScheduler.Domain.Entities.Route;

public class Route
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RouteId { get; set; }
    public int OriginCityId { get; set; }
    public int DestinationCityId { get; set; }
    public DateTime DepartureDate { get; set; }

    #region Navigation

    public List<Flight.Flight> Flights { get; set; } = null!;

    #endregion
}

