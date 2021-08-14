using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerHomework.ConsoleLogger
{
    public class ConsoleLogger : ILogger
    {
        private readonly ConsoleLoggerProvider _provider;

        public ConsoleLogger(ConsoleLoggerProvider provider)
        {
            _provider = provider;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            Console.ForegroundColor = logLevel switch
            {
                LogLevel.Trace => ConsoleColor.Blue,
                LogLevel.Debug => ConsoleColor.Gray,
                LogLevel.Information => ConsoleColor.Green,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Critical => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };

            Console.WriteLine("{0}\t{1}\n{2}", eventId, logLevel, formatter(state, exception));
        }
    }
}
