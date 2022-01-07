using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Writes logentries
    /// </summary>
    public interface IEntryWriter
    {
        /// <summary>
        /// WriteAsync Log
        /// </summary>
        /// <param name="entry"></param>
        Task WriteAsync(LogEntry entry);
    }
}
