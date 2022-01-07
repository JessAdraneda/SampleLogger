using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    public abstract class FileConfiguration : Configuration
    {
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfiguration"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity.</param>
        protected FileConfiguration(Severity minimumSeverity) : base(minimumSeverity)
        {
        }
    }
}
