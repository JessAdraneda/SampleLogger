using System;
using System.Collections.Generic;
using System.Text;

namespace SampleLogger.Logging
{
    public class DebugOutputConfiguration : Configuration
    {
        public DebugOutputConfiguration(Severity minimumSeverity) : base(minimumSeverity)
        {
        }
    }
}
