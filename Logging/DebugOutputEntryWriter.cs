using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    public class DebugOutputEntryWriter : IEntryWriter
    {
        private readonly DebugOutputConfiguration _configuration;

        public DebugOutputEntryWriter(DebugOutputConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task WriteAsync(LogEntry entry)
        {
            if (entry.Severity > _configuration.MinimumSeverity)
                return Task.FromResult(false);

            Debug.WriteLine(entry.Content.ToString());
            return Task.FromResult(true);
        }
    }
}
