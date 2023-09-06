﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using FlightScheduler.Data.Context;
using FlightScheduler.Domain.Entities.Route;
using FlightScheduler.Domain.Repositories;
using FlightScheduler.DTO.DTOs;
using FlightScheduler.DTO.DTOs.Csv;
using Microsoft.EntityFrameworkCore;

namespace FlightScheduler.Data.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly FlightSchedulerContext _context;
    public RouteRepository(FlightSchedulerContext context)
    {
        _context = context;
    }

    public async Task<List<int>> GetRoutesIdsForCitiesInTimeInterval(List<RouteCitiesDto> routeCities, DateTime startDate, DateTime endDate)
    {
        var routes = new List<Route>();
        foreach (var routeCitiesItem in routeCities)
        {
            var route = await _context.Routes!.FirstOrDefaultAsync(r =>
                r.OriginCityId == routeCitiesItem.OriginCityId &&
                r.DestinationCityId == routeCitiesItem.DestinationCityId && r.DepartureDate>=startDate&& r.DepartureDate<=endDate);
            if (route != null) routes.Add(route);
        }
        var routeIds = routes.Select(r => r.RouteId).ToList();
        return routeIds;
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