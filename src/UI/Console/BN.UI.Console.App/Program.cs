using System.Threading.Tasks;
using BN.UI.Console.App.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BN.UI.Console.App
{
    internal class Program
    {
        private static Task Main(string[] args)
        {
            var serviceProvider = DiConfiguration.Configure();
            var instance = serviceProvider.GetService<AppInstance>();

            return instance.Start();
        }
    }
}