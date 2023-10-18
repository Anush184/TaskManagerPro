using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Application.Contracts.Logging;

namespace TaskManagerPro.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {

            _logger = loggerFactory.CreateLogger<T>();

        }
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWorning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
