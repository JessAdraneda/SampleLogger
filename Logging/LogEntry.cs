using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Logentry
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// Gets the content.
        /// </summary>
        public object Content { get; }

        /// <summary>
        /// Gets the severity.
        /// </summary>
        public Severity Severity { get; }

        /// <summary>
        /// Gets a value indicating whether [contains confidential information].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [contains confidential information]; otherwise, <c>false</c>.
        /// </value>
        public bool ContainsConfidentialInformation { get; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <param name="severity">The severity.</param>
        /// <param name="content">The content.</param>
        /// <param name="containsConfidentialInformation">if set to <c>true</c> [contains confidential information].</param>
        public LogEntry(Severity severity, object content, bool containsConfidentialInformation)
        {
            Timestamp = DateTime.UtcNow;
            Severity = severity;
            Content = content;
            ContainsConfidentialInformation = containsConfidentialInformation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="severity">The severity.</param>
        /// <param name="content">The content.</param>
        /// <param name="containsConfidentialInformation">if set to <c>true</c> [contains confidential information].</param>
        internal LogEntry(DateTime timestamp, Severity severity, object content, bool containsConfidentialInformation) : this(severity, content, containsConfidentialInformation)
        {
            Timestamp = timestamp;
        }
    }
}
