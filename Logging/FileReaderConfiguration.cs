using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    /// <summary>
    /// FileReader configuration 
    /// </summary>
    public class FileReaderConfiguration : FileConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileReaderConfiguration"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity.</param>
        public FileReaderConfiguration(Severity minimumSeverity) : base(minimumSeverity)
        {
        }
    }
}
