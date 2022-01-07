using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    public class MobileCenterConfiguration : FileConfiguration
    {
        /// <summary>
        /// Gets or sets IosKey for MobileCenter.
        /// </summary>
        public string IosKey { get; set; }

        /// <summary>
        /// Gets or sets UwpKey for MobileCenter.
        /// </summary>
        public string UwpKey { get; set; }

        /// <summary>
        /// Gets or sets AndroidKey for MobileCenter.
        /// </summary>
        public string AndroidKey { get; set; }

        public MobileCenterConfiguration(Severity minimumSeverity) : base(minimumSeverity)
        {
            AndroidKey = "";
            IosKey = "";
            UwpKey = "";
        }
    }
}
