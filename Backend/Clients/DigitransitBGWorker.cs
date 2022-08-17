using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HSLRushHour.Backend.Clients.DigiTransitClient;
using HSLRushHour.Backend.Models;
using HSLRushHour.Backend.Shared.Dtos.Mappers;

namespace HSLRushHour.Backend.Clients;
public class DigitransitBGWorker : IHostedService, IDisposable
{
    private ILogger<DigitransitBGWorker> _logger;
    private IServiceScopeFactory _serviceScopeFactory;
    private Timer? _timer = null;

    public DigitransitBGWorker(ILogger<DigitransitBGWorker> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Digitransit Backgroundworker started");

        _timer = new Timer(
            GoGetData,
            null,
            TimeSpan.Zero,
            TimeSpan.FromSeconds(30)
        );

        return Task.CompletedTask;
    }

    private void GoGetData(object? state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            using var dbContext = scope.ServiceProvider.GetRequiredService<HSLRushHourDbContext>() ?? throw new Exception("HSLRushHourDbContext could not be created in DigitransitBGWorker");
            var dgClient = scope.ServiceProvider.GetRequiredService<IDigiTransitClient>();

            var existingIds = dbContext.Disruptions.Select(x => x.digiTransitId).ToList();
            var disturbancesToAdd = dgClient.getDisturbances(existingIds).Result.Select(x => x.toEntity());

            dbContext.AddRange(disturbancesToAdd);
            dbContext.SaveChanges();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Digitransit Backgroundworker stopped");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
