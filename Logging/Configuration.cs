using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    /// <summary>
    /// Base configuration for Logging 
    /// </summary>
    public abstract class Configuration
    {
        /// <summary>
        /// Gets the minimum severity.
        /// </summary>
        public Severity MinimumSeverity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="minimumSeverity">The minimum severity.</param>
        protected Configuration(Severity minimumSeverity)
        {
            MinimumSeverity = minimumSeverity;
        }
    }
}
