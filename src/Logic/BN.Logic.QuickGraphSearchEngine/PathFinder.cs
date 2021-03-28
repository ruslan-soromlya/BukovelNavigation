using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BN.Logic.Interfaces;
using BN.Models;
using QuickGraph;
using QuickGraph.Algorithms;

namespace BN.Logic.QuickGraphSearchEngine
{
    public class PathFinder : IPathFinder
    {
        private readonly IResortInfrastructureProvider _resortInfrastructureProvider;

        private Task _initializeTask;
        private ResortInfrastructure _resortInfrastructure;
        private BidirectionalGraph<string, Edge<string>> _graph;

        public PathFinder(IResortInfrastructureProvider resortInfrastructureProvider)
        {
            _resortInfrastructureProvider = resortInfrastructureProvider;
        }

        public Task Initialize(CancellationToken token = default(CancellationToken))
        {
            if (_initializeTask != null) return _initializeTask;

            _initializeTask = InitializeInternal(token);
            return _initializeTask;
        }

        public async Task<ShortestPathResult> FindShortestPath(IResortObject @from, IResortObject to)
        {
            await EnsureInitialized();

            var result = new ShortestPathResult
            {
                From = from,
                To = to
            };

            static double EdgeCost(Edge<string> e) => 1;

            var tryGetPaths = _graph.ShortestPathsDijkstra(EdgeCost, from.Name);

            if (tryGetPaths(to.Name, out var tmp))
            {
                result.IsPathFound = true;

                var path = new List<string>();
                path.Add(tmp.First().Source);
                path.AddRange(tmp.Select(x => x.Target));
                result.Path = path.Select(x => _resortInfrastructure.Objects.Single(y => y.Name == x));
            }

            return result;
        }

        private async Task InitializeInternal(CancellationToken token)
        {
            _resortInfrastructure = await _resortInfrastructureProvider.GetResortInfrastructure(token);

            _graph = new BidirectionalGraph<string, Edge<string>>();
            _graph.AddVertexRange(this._resortInfrastructure.Objects.Select(x => x.Name));

            foreach (var obj in this._resortInfrastructure.Objects)
            {
                _graph.AddEdgeRange(obj.Neighbours.Select(x => new Edge<string>(obj.Name, x)));
            }
        }

        private async Task EnsureInitialized()
        {
            if (_initializeTask == null)
            {
                throw new Exception("Please call Initialize before executing any other operations");
            }

            await _initializeTask;
        }
    }
}