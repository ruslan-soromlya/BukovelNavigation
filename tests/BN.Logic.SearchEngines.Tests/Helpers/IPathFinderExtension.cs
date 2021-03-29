using BN.Logic.Interfaces;
using BN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BN.Logic.SearchEngines.Tests.Helpers
{
    public static class PathFinderExtension
    {
        public static Task<ShortestPathResult> FindShortestPath(this IPathFinder finder, string from, string to)
        {
            var fromObj = new ResortObjectTestObject(from);
            var toObj = new ResortObjectTestObject(to);

            return finder.FindShortestPath(fromObj, toObj);
        }

        public static string ToStringPath(this ShortestPathResult pathResult)
        {
            if (!pathResult.IsPathFound)
            {
                return string.Empty;
            }

            var result = string.Join("-", pathResult.Path.Select(x => x.Name));
            return result;
        }
    }
}
