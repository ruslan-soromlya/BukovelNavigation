using BN.UI.Mob.Core;
using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace BN.UI.Mob.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}