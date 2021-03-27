using System.Threading.Tasks;
using BN.Logic.Interfaces;

namespace BN.UI.Console.App
{
    public class AppInstance
    {
        private readonly IResortInfrastructureProvider _resortInfrastructureProvider;

        public AppInstance(IResortInfrastructureProvider resortInfrastructureProvider)
        {
            _resortInfrastructureProvider = resortInfrastructureProvider;
        }

        public async Task Start()
        {
            var resortInfo = await _resortInfrastructureProvider.GetResortInfrastructure();
            System.Console.WriteLine("Loaded resort objects number: " + resortInfo.Objects.Count);
        }
    }
}