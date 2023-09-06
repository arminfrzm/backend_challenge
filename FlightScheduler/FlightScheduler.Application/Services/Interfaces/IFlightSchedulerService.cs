using FlightScheduler.DTO.DTOs;

namespace FlightScheduler.Application.Services.Interfaces;

public interface IFlightSchedulerService
{
    #region DataInsert

    public Task InsertRoutes();
    public Task InsertFlights();

    #endregion

    public Task<List<FlightDto>> GetFlights(short agencyId,DateTime startDate, DateTime endDate);
}