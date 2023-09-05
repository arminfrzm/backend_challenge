using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using FlightScheduler.Data.Context;
using FlightScheduler.Data.DTOs;
using FlightScheduler.Domain.Entities.Route;
using FlightScheduler.Domain.Repositories;

namespace FlightScheduler.Data.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly FlightSchedulerContext _context;
    public RouteRepository(FlightSchedulerContext context)
    {
        _context = context;
    }

    public async Task InsertRoutesDataFromCsv()
    {
        if (File.Exists("wwwroot/data/routes.csv"))
        {
            using var reader = new StreamReader("wwwroot/data/routes.csv");
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            var csvRoutes = csv.GetRecords<CsvRoute>();
            const string format = "yyyy-MM-dd";
            foreach (var route in csvRoutes)
            {
                _context.Routes!.Add(new Route
                {
                    RouteId = Convert.ToInt32(route.route_id),
                    OriginCityId = Convert.ToInt32(route.origin_city_id),
                    DestinationCityId = Convert.ToInt32(route.destination_city_id),
                    DepartureDate = DateTime.ParseExact(route.departure_date, format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None)
                });
            }
            reader.Close();
            await _context.SaveChangesAsync();
        }
    }
}