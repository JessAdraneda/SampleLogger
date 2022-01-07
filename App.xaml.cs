
using SampleLogger.Logging;
using System.Windows;

namespace SampleLogger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Log.Current.Register(new DebugOutputEntryWriter(new DebugOutputConfiguration(Severity.Verbose)));
        }

    }
}
