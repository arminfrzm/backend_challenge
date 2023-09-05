using FlightScheduler.Domain.Entities.Flight;
using FlightScheduler.Domain.Entities.Route;
using FlightScheduler.Domain.Entities.Subscription;
using Microsoft.EntityFrameworkCore;

namespace FlightScheduler.Data.Context
{
    public class FlightSchedulerContext:DbContext
    {
        public FlightSchedulerContext(DbContextOptions<FlightSchedulerContext> options) : base(options)
        {

        }

        #region DbSets

        public DbSet<Route>? Routes { get; set; }
        public DbSet<Flight>? Flights { get; set; }
        public DbSet<Subscription>? Subscriptions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region DataSeed

            var (_,_, subscriptions) = HardCodeData.SeedFlightData();
            //builder.Entity<Route>().HasData(routes);
            //builder.Entity<Flight>().HasData(flights);
            builder.Entity<Subscription>().HasData(subscriptions);

            #endregion
        }
    }
}
