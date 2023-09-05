namespace FlightScheduler.Application.Services.Interfaces;

public interface IFlightSchedulerService
{
    #region DataInsert

    public Task InsertRoutes();
    public Task InsertFlights();

    #endregion
}