using FlightScheduler.Application.Services.Interfaces;
using FlightScheduler.Domain.Entities.Flight;
using FlightScheduler.Domain.Repositories;
using FlightScheduler.DTO.DTOs;

namespace FlightScheduler.Application.Services.Implementations;

public class FlightSchedulerService : IFlightSchedulerService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IFlightRepository _flightRepository;
    private readonly ISubscriptionRepository _subscriptionRepository;
    public FlightSchedulerService(IRouteRepository routeRepository, IFlightRepository flightRepository, ISubscriptionRepository subscriptionRepository)
    {
        _routeRepository = routeRepository;
        _flightRepository = flightRepository;
        _subscriptionRepository = subscriptionRepository;
    }

    public async Task<List<FlightDto>> GetFlights(short agencyId, DateTime startDate, DateTime endDate)
    {
        try
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionByAgencyId(agencyId);
            var routeCities = subscriptions.Select(s => new RouteCitiesDto()
            {
                OriginCityId = s.OriginCityId,
                DestinationCityId = s.DestinationCityId,
            }).ToList();
            var routeIds = await _routeRepository.GetRoutesIdsForCitiesInTimeInterval(routeCities, startDate, endDate);
            var flights = await _flightRepository.GetFlightsByRouteIds(routeIds);
            return flights.OrderBy(f => f.DepartureTime).Select(f => new FlightDto()
            {
                FlightId = f.FlightId,
                DepartureTime = f.DepartureTime,
                ArrivalTime = f.ArrivalTime,
                AirlineId = f.AirlineId,
                FlightStatus = CalculateFlightStatus(f,flights)
            }).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static FlightStatus CalculateFlightStatus(Flight flight, List<Flight> allFlights)
    {
        var departureTimeMinus7Days = flight.DepartureTime.AddDays(-7).AddMinutes(-30);
        var departureTimePlus7Days = flight.DepartureTime.AddDays(7).AddMinutes(30);
        var isNew = allFlights.Any(f =>
            f.AirlineId == flight.AirlineId &&
            f.DepartureTime >= departureTimeMinus7Days &&
            f.DepartureTime <= flight.DepartureTime);
        var isDiscontinued = allFlights.Any(f =>
            f.AirlineId == flight.AirlineId &&
            f.DepartureTime >= flight.DepartureTime &&
            f.DepartureTime <= departureTimePlus7Days);
        if (isNew)
        {
            return FlightStatus.New;
        }
        return isDiscontinued ? FlightStatus.Discontinued : FlightStatus.Normal;
    }

    #region DataInsert

    public async Task InsertRoutes()
    {
        await _routeRepository.InsertRoutesDataFromCsv();
    }

    public async Task InsertFlights()
    {
        await _flightRepository.InsertFlightsDataFromCsv();
    }

    #endregion
}