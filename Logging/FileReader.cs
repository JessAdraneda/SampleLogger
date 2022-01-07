using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Reads and deserializes a text logfile
    /// </summary>
    /// <seealso cref="It.Cec.Xaf.Logging.IEntryReader" />
    public class FileReader : IEntryReader
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        protected internal FileReaderConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FileReader(FileReaderConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Reads the logfile entries.
        /// </summary>
        /// <returns>Array of LogEntries</returns>
        async Task<LogEntry[]> IEntryReader.ReadAsync()
        {
            var entries = new List<LogEntry>();
            var mainDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var filename = Path.Combine(mainDir, Configuration.Filename);
            if (!File.Exists(filename))
            {
                return entries.ToArray();
            }

            using (var streamReader = File.OpenText(filename))
            {
                while (!streamReader.EndOfStream)
                {
                    var logLine = await streamReader.ReadLineAsync();

                    var timestamp = DateTime.Parse(logLine.Substring(0, 20));
                    var containsConfidentialInformation = logLine.Substring(22, 1) == "C";
                    var severity = (Severity)Enum.Parse(typeof(Severity), logLine.Substring(25, 8).Trim());
                    var content = logLine.Substring(32).Trim();

                    entries.Add(new LogEntry(timestamp, severity, content, containsConfidentialInformation));
                }

                return entries.ToArray();
            }
        }
    }
}
