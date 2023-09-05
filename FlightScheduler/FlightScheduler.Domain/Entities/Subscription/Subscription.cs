using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightScheduler.Domain.Entities.Subscription;

public class Subscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int SubscriptionId { get; set; }
    public short AgencyId { get; set; }
    public int OriginCityId { get; set; }
    public int DestinationCityId { get; set; }
}
