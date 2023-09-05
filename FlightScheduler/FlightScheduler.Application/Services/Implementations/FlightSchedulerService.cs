using FlightScheduler.Application.Services.Interfaces;
using FlightScheduler.Domain.Repositories;

namespace FlightScheduler.Application.Services.Implementations;

public class FlightSchedulerService : IFlightSchedulerService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IFlightRepository _flightRepository;
    public FlightSchedulerService(IRouteRepository routeRepository, IFlightRepository flightRepository)
    {
        _routeRepository = routeRepository;
        _flightRepository = flightRepository;
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