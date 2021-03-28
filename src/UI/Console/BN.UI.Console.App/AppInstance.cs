using System.Linq;
using System.Threading.Tasks;
using BN.Logic.Interfaces;

namespace BN.UI.Console.App
{
    public class AppInstance
    {
        private readonly IResortInfrastructureProvider _resortInfrastructureProvider;
        private readonly IPathFinder _pathFinder;

        public AppInstance(IResortInfrastructureProvider resortInfrastructureProvider, IPathFinder pathFinder)
        {
            _resortInfrastructureProvider = resortInfrastructureProvider;
            _pathFinder = pathFinder;
        }

        public async Task Start()
        {
            var resortInfo = await _resortInfrastructureProvider.GetResortInfrastructure();

            var r = resortInfo.Objects.ToDictionary(x => x.Name, x => x);

            System.Console.WriteLine("Loaded resort objects number: " + resortInfo.Objects.Count);
            await _pathFinder.Initialize();
            var path = await _pathFinder.FindShortestPath(r["L15"], r["L13"]);

            System.Console.WriteLine($"Path from {r["L15"].Name} to {r["L13"].Name} " + string.Join(" - ", path.Select(x => x.Name)));
            
            
        }
    }
}