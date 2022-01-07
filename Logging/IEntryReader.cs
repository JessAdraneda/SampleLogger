using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Read log entries
    /// </summary>
    public interface IEntryReader
    {
        Task<LogEntry[]> ReadAsync();
    }
}
