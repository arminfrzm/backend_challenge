using FlightScheduler.Application.Services.Implementations;
using FlightScheduler.Application.Services.Interfaces;
using FlightScheduler.Data.Repositories;
using FlightScheduler.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FlightScheduler.IoC;

public static class DependencyContainer
{
    public static IServiceCollection UseIoC(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRouteRepository, RouteRepository>();
        serviceCollection.AddScoped<IFlightRepository, FlightRepository>();
        serviceCollection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        serviceCollection.AddScoped<IFlightSchedulerService, FlightSchedulerService>();
        return serviceCollection;
    }
}