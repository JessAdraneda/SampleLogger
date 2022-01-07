using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleLogger.Logging
{
    public class MobileCenterEntryWriter : IEntryWriter
    {
        private readonly MobileCenterConfiguration _configuration;
        private readonly string _identifier;


        public MobileCenterEntryWriter(MobileCenterConfiguration configuration)
        {
            _configuration = configuration;
            _identifier = Guid.NewGuid().ToString();

            //AppCenter.Start("android=" + _configuration.AndroidKey + ";" +
            //                "uwp=" + _configuration.UwpKey + ";" +
            //                "ios=" + _configuration.IosKey,
            //                typeof(Analytics), typeof(Crashes));

            //Crashes.SetEnabledAsync(true);
        }

        /// <summary>
        /// Send Track event to MobileCenter
        /// </summary>
        /// <param name="entry"></param>
        public async Task WriteAsync(LogEntry entry)
        {
            if (entry.Severity > _configuration.MinimumSeverity || entry.ContainsConfidentialInformation)
                return;

            if(entry.Content is Exception)
            {
                var properties = new Dictionary<string, string> {
                { "ID", _identifier },
                { "Severity", entry.Severity.ToString() }
              };
              //Crashes.TrackError(entry.Content as Exception, properties);
            }
            else
            {
                var text = entry.Content.ToString();
                //Analytics.TrackEvent($"ID {_identifier}", new Dictionary<string, string>
                //{
                //    {entry.Severity.ToString(), text }
                //});
            }
        }
    }
}
