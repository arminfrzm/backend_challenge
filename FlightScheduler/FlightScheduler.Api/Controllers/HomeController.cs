using FlightScheduler.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightScheduler.Api.Controllers
{
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

        [HttpGet("{startDate}/{endDate}/{agencyId}")]
        public IActionResult GetFlights(string startDate,string endDate,string agencyId)
        {
            return Ok(new { start = startDate, end = endDate ,agency=agencyId});
        }

        

    }
}
