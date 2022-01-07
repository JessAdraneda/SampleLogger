using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Manages writing log entries
    /// </summary>
    /// <seealso cref="It.Cec.Xaf.Logging.ILogger" />
    /// <seealso cref="System.IDisposable" />
    public sealed class Log : ILogger, IDisposable
    {
        private readonly ConcurrentBag<IEntryWriter> _writer = new ConcurrentBag<IEntryWriter>();

        static Log()
        {
            Current = new Log();
        }

        /// <summary>
        ///     Get the current ILogger instance
        /// </summary>
        public static ILogger Current { get; }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        public async Task Write(LogEntry entry)
        {
            foreach (var writer in _writer)
                await writer.WriteAsync(entry);
        }

        private static readonly Object obj = new Object();

        public async Task<LogEntry> Write(Severity severity, object content, bool containsConfidentialInformation = true)
        {
            var entry = new LogEntry(severity, content, containsConfidentialInformation);
            await Write(entry);
            return entry;
        }

        /// <summary>
        ///     Logs an error
        /// </summary>
        /// <param name="content" />
        /// <param name="containsConfidentialInformation" />
        /// <returns>LogEntry</returns>
        public static async Task<LogEntry> Error(object content, bool containsConfidentialInformation = false)
        {
            return await Current.Write(Severity.Error, content, containsConfidentialInformation);
        }

        public static async Task<LogEntry> Critical(object content, bool containsConfidentialInformation = false)
        {
            return await Current.Write(Severity.Critical, content, containsConfidentialInformation);
        }

        public static async Task<LogEntry> Warning(object content, bool containsConfidentialInformation = false)
        {
            return await Current.Write(Severity.Warning, content, containsConfidentialInformation);
        }

        public static async Task<LogEntry> Info(object content, bool containsConfidentialInformation = false)
        {
            return await Current.Write(Severity.Info, content, containsConfidentialInformation);
        }

        public static async Task<LogEntry> Verbose(object content, bool containsConfidentialInformation = false)
        {
            return await Current.Write(Severity.Verbose, content, containsConfidentialInformation);
        }

        public void Register(IEntryWriter writer)
        {
            _writer.Add(writer);
        }

        public void Dispose(bool disposing)
        {
        }
    }
}
