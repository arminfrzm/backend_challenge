using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using FlightScheduler.Data.DTOs;
using FlightScheduler.Domain.Entities.Subscription;
using FlightScheduler.Domain.Entities.Flight;
using FlightScheduler.Domain.Entities.Route;

namespace FlightScheduler.Data
{
    internal class HardCodeData
    {
        public static Tuple<List<Route>, List<Flight>, List<Subscription>> SeedFlightData()
        {
            var routes = new List<Route>();
            var flights = new List<Flight>();

            //if (File.Exists("wwwroot/data/routes.csv"))
            //{
            //    using var reader = new StreamReader("wwwroot/data/routes.csv");
            //    using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            //    var csvRoutes = csv.GetRecords<CsvRoute>();
            //    const string format = "yyyy-MM-dd";
            //    foreach (var route in csvRoutes)
            //    {
            //        routes.Add(new Route
            //        {
            //            RouteId = Convert.ToInt32(route.route_id),
            //            OriginCityId = Convert.ToInt32(route.origin_city_id),
            //            DestinationCityId = Convert.ToInt32(route.destination_city_id),
            //            DepartureDate = DateTime.ParseExact(route.departure_date, format, CultureInfo.InvariantCulture, DateTimeStyles.None)
            //        });
            //    }
            //    reader.Close();
            //}

            //if (File.Exists("wwwroot/data/flights.csv"))
            //{
            //    using var reader = new StreamReader("wwwroot/data/flights.csv");
            //    using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            //    var csvFlights = csv.GetRecords<CsvFlight>();
            //    const string format = "yyyy-MM-dd HH:mm:ss";
            //    foreach (var flight in csvFlights)
            //    {
            //        flights.Add(new Flight
            //        {
            //            FlightId = Convert.ToInt32(flight.flight_id),
            //            RouteId = Convert.ToInt32(flight.route_id),
            //            DepartureTime = DateTime.ParseExact(flight.departure_time, format, CultureInfo.InvariantCulture, DateTimeStyles.None),
            //            ArrivalTime = DateTime.ParseExact(flight.arrival_time, format, CultureInfo.InvariantCulture, DateTimeStyles.None),
            //            AirlineId = Convert.ToInt16(flight.airline_id)
            //        });
            //    }
            //    reader.Close();
            //}

            var subscriptions = new List<Subscription>();

            if (File.Exists("wwwroot/data/subscriptions.csv"))
            {
                using var reader = new StreamReader("wwwroot/data/subscriptions.csv");
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
                var csvSubscriptions = csv.GetRecords<CsvSubscription>();
                var i = 1;
                foreach (var subscription in csvSubscriptions)
                {
                    subscriptions.Add(new Subscription()
                    {
                        SubscriptionId = i,
                        AgencyId = Convert.ToInt16(subscription.agency_id),
                        OriginCityId = Convert.ToInt32(subscription.origin_city_id),
                        DestinationCityId = Convert.ToInt32(subscription.destination_city_id)
                    });
                    i++;
                }
                reader.Close();
            }

            var result = Tuple.Create(routes, flights, subscriptions);
            return result;
        }
    }
}
