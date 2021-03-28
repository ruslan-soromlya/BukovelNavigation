using System.Threading;
using System.Threading.Tasks;
using BN.Models;

namespace BN.Logic.Interfaces
{
    public interface IResortInfrastructureProvider
    {
        Task<ResortInfrastructure> GetResortInfrastructure(CancellationToken token = default(CancellationToken));
    }
}