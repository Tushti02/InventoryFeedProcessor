using InventoryFeedProcessor.FileProcessors;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryFeedProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerOptions _options;
        private readonly IProcessFileDispatcher _facadeFileProcessor;

        public Worker(ILogger<Worker> logger, WorkerOptions options, IProcessFileDispatcher facadeFileProcessor)
        {
            _logger = logger;
            _options = options;
            _facadeFileProcessor = facadeFileProcessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var folderPath = _options.FolderPath;
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    foreach (string file in Directory.EnumerateFiles(folderPath, "*"))
                    {
                        _facadeFileProcessor.Process(file,file.Split(".").Last());
                    }
                    await Task.Delay(1000, stoppingToken);
                }
                catch(Exception ex)
                {
                    _logger.LogInformation("Exception : ", ex);
                }
            }
        }
    }
}
