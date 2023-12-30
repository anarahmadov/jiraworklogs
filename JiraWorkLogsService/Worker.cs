using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Utils.Messaging;

namespace JiraWorkLogsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly MessageReceiver messageReceiver;

        public Worker(ILogger<Worker> logger, MessageReceiver messageReceiver)
        {
            this.logger = logger;
            this.messageReceiver = messageReceiver;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (logger.IsEnabled(LogLevel.Information))
            //    {
            //        logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    }
            //    await Task.Delay(1000, stoppingToken);
            //}
            stoppingToken.ThrowIfCancellationRequested();

            this.messageReceiver.StartConsumer();
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
