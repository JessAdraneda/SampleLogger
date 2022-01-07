using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        Task Write(LogEntry entry);

        /// <summary>
        /// Writes the specified severity.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="content">The content.</param>
        /// <param name="containsConfidentialInformation">if set to <c>true</c> [contains confidential information].</param>
        /// <returns>new LogEntry</returns>
        Task<LogEntry> Write(Severity severity, object content, bool containsConfidentialInformation = true);

        /// <summary>
        /// Registers the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        void Register(IEntryWriter writer);
    }
}
