using BN.Logic.Interfaces;
using BN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BN.Logic.SearchEngines.Tests.Helpers
{
    public static class IPathFinderExtension
    {
        public static Task<ShortestPathResult> FindShortestPath(this IPathFinder finder, string from, string to)
        {
            var fromObj = new ResortObjectTestObject(from);
            var toObj = new ResortObjectTestObject(to);

            return finder.FindShortestPath(fromObj, toObj);
        }
    }
}
