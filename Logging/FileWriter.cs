using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Writes logentries into a file
    /// </summary>
    /// <seealso cref="It.Cec.Xaf.Logging.IEntryWriter" />
    /// <seealso cref="System.IDisposable" />
    public class FileWriter : IEntryWriter, IDisposable
    {
        private SemaphoreSlim _writerSemaphore = new SemaphoreSlim(1, 1);
        private StreamWriter _writer;


        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FileWriter(FileWriterConfiguration configuration)
        {
            Configuration = configuration;
            Filename = configuration.Filename ?? "log";
            InitializeLogfile();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        protected internal FileWriterConfiguration Configuration { get; }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        protected internal string Filename { get; }


        /// <summary>
        /// Writes the specified entry.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <exception cref="System.Exception">Unable to write logentries</exception>
        public async Task WriteAsync(LogEntry entry)
        {
            if (entry.Severity > Configuration.MinimumSeverity)
                return;

            try
            {
                await _writerSemaphore.WaitAsync();
                var confidentialIndicator = entry.ContainsConfidentialInformation ? "C" : "A";
                var prefix = $"{entry.Timestamp:u}  {confidentialIndicator}  {entry.Severity.ToString().PadRight(8)} ";
                var entryText = $"{prefix}{entry.Content.ToString().Replace("\n", "\n".PadRight(prefix.Length + 1))}";

                await _writer.WriteLineAsync(entryText);
            }
            catch (Exception inner)
            {
                throw new Exception("Unable to write logentries", inner);
            }
            finally
            {
                _writerSemaphore.Release();
            }
        }

        private void InitializeLogfile()
        {
            var mainDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var filename = Path.Combine(mainDir, Configuration.Filename);
            if (!File.Exists(filename))
            {
                _writer = File.CreateText(filename);
            }
            else
            {
                try
                {
                    var stream = File.OpenWrite(filename);
                    stream.Seek(0, SeekOrigin.End);
                    _writer = new StreamWriter(stream) { AutoFlush = true };
                }
                catch(Exception ex)
                {
                    var message = ex.Message;
                    _writer = File.CreateText(filename);
                }
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        ~FileWriter()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writer?.Dispose();
            }
        }
    }
}
