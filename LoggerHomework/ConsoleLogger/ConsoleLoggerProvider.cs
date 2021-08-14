using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerHomework.ConsoleLogger
{
    [ProviderAlias("ConsoleLogger")]
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger(this);
        }

        public void Dispose()
        {
            
        }
    }
}
