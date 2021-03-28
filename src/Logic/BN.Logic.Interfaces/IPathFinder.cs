using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BN.Models;

namespace BN.Logic.Interfaces
{
    public interface IPathFinder
    {
        Task Initialize(CancellationToken cancellationToken = default(CancellationToken));
        Task<ShortestPathResult> FindShortestPath(IResortObject from, IResortObject to);
    }
}