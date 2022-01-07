using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    /// <summary>
    /// FileWriter configuration 
    /// </summary>
    public class FileWriterConfiguration : FileConfiguration
    {
        /// <summary>
        /// Gets or sets the maximum filesize per file.
        /// </summary>
        public long MaxFilesize { get; set; }

        /// <summary>
        /// Gets or sets the filecount.
        /// </summary>
        public int Filecount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriterConfiguration"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity.</param>
        public FileWriterConfiguration(Severity minimumSeverity) : base(minimumSeverity)
        {
        }
    }
}
