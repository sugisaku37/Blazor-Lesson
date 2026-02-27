using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp5
{
    public class ExceptionFileLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, ExceptionFileLogger> _loggers = new();

        public ExceptionFileLoggerProvider()
        {
            // initialization code
        }
        public ILogger CreateLogger(string categoryName)
        {
            var logger = _loggers.GetOrAdd(categoryName, new ExceptionFileLogger());
            return logger;
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}