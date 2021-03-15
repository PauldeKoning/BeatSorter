using BeatSorterDatabase.External;
using BeatSorterDatabase.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BeatSorter.Util.HostedServices
{
    public class CheckBeatSaverAPI : IHostedService, IDisposable
    {
        private Timer _timer;

        private IServiceScopeFactory serviceScopeFactory;

        public CheckBeatSaverAPI(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;    
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var beatmapRepository = scope.ServiceProvider.GetRequiredService<IBeatmapRepository>();
                var  difficultyRepository = scope.ServiceProvider.GetRequiredService<IDifficultyRepository>();
                var uploaderRepository = scope.ServiceProvider.GetRequiredService<IUploaderRepository>();

                var api = new BeatSaverAPI(beatmapRepository, difficultyRepository, uploaderRepository);
                api.RetrieveLatestSongs();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
