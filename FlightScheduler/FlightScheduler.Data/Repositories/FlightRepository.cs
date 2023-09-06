using CsvHelper;
using CsvHelper.Configuration;
using FlightScheduler.Data.Context;
using FlightScheduler.Domain.Entities.Flight;
using FlightScheduler.Domain.Entities.Route;
using FlightScheduler.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using FlightScheduler.DTO.DTOs.Csv;

namespace FlightScheduler.Data.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly FlightSchedulerContext _context;
    public FlightRepository(FlightSchedulerContext context)
    {
        _context = context;
    }

    public async Task<List<Flight>> GetFlightsByRouteIds(List<int> routeIds)
    {
        var flights = await _context.Flights!.Where(f => routeIds.Contains(f.RouteId)).ToListAsync();
        return flights;
    }

    public async Task InsertFlightsDataFromCsv()
    {
        if (File.Exists("wwwroot/data/flights.csv"))
        {
            using var reader = new StreamReader("wwwroot/data/flights.csv");
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            var csvFlights = csv.GetRecords<CsvFlight>();
            const string format = "yyyy-MM-dd HH:mm:ss";
            foreach (var flight in csvFlights)
            {
                _context.Flights!.Add(new Flight
                {
                    FlightId = Convert.ToInt32(flight.flight_id),
                    RouteId = Convert.ToInt32(flight.route_id),
                    DepartureTime = DateTime.ParseExact(flight.departure_time, format, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    ArrivalTime = DateTime.ParseExact(flight.arrival_time, format, CultureInfo.InvariantCulture, DateTimeStyles.None),
                    AirlineId = Convert.ToInt16(flight.airline_id)
                });
            }
            reader.Close();
            await _context.SaveChangesAsync();
        }
    }
}