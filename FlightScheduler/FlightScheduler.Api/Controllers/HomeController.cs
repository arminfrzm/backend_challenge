using System.Diagnostics;
using FlightScheduler.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FlightScheduler.Domain.Entities.Flight;

namespace FlightScheduler.Api.Controllers;

[Route("api/[controller]/[action]/")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IFlightSchedulerService _flightSchedulerService;
    public HomeController(IFlightSchedulerService flightSchedulerService)
    {
        _flightSchedulerService = flightSchedulerService;
    }

    #region InsertData

    //[HttpGet]
    //public async Task<IActionResult> InsertRoutes()
    //{
    //    try
    //    {
    //        await _flightSchedulerService.InsertRoutes();
    //        return Ok("Success");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex);
    //        throw;
    //    }
    //}

    //[HttpGet]
    //public async Task<IActionResult> InsertFlights()
    //{
    //    try
    //    {
    //        await _flightSchedulerService.InsertFlights();
    //        return Ok("Success");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex);
    //        throw;
    //    }
    //}

    #endregion

    [HttpGet("{agencyId:int}/{startDate:datetime}/{endDate:datetime}/")]
    public async Task<IActionResult> GetFlights(int agencyId,DateTime startDate,DateTime endDate)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var flights = await _flightSchedulerService.GetFlights((short)agencyId, startDate, endDate);
        var csv = new StringBuilder();
        csv.AppendLine("FlightId,DepartureTime,ArrivalTime,AirlineId,FlightStatus");
        foreach (var flight in flights)
        {
            csv.AppendLine($"{flight.FlightId},{flight.DepartureTime.ToString("G")},{flight.ArrivalTime.ToString("G")},{flight.AirlineId},{flight.FlightStatus}");
        }
        stopwatch.Stop();
        var elapsedTime = (float)stopwatch.ElapsedMilliseconds / 1000;
        csv.AppendLine($"Execution Time , {elapsedTime}");
        var csvBytes = Encoding.UTF8.GetBytes(csv.ToString());
        Console.WriteLine("Execution Time : {0}",elapsedTime);
        return File(csvBytes, "text/csv", "FlightsSchedule.csv");
    }
}