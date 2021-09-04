using BN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BN.Logic.SearchEngines.Tests.Helpers
{
    public class ResortInfoBuilder
    {
        private Dictionary<string, List<string>> ResortInfo { get; } = new Dictionary<string, List<string>>();
        

        // ReSharper disable once InconsistentNaming
        public ResortInfoBuilder ParseABNRelation(string abRelation)
        {
            var vertices = abRelation.Split("-").Select(x => x.Trim()).ToList();

            for (var i = 0; i < vertices.Count - 1; i++)
            {
                var from = vertices[i];
                var to = vertices[i + 1];

                if (ResortInfo.ContainsKey(from))
                {
                    ResortInfo[from].Add(to);
                }
                else
                {
                    ResortInfo[from] = new List<string> { to };
                }
            }

            ResortInfo[vertices.Last()] = new List<string>();

            return this;
        }

        public void AddVertices(params string[] vertices)
        {
            foreach (var vertex in vertices)
            {
                if (ResortInfo.ContainsKey(vertex))
                {
                    continue;
                }
                
                ResortInfo.Add(vertex, new List<string>());
            }
        }

        public ResortInfrastructure Build()
        {
            var result = new ResortInfrastructure {Objects = new List<IResortObject>()};

            foreach(var (key, value) in ResortInfo)
            {
                var obj = new ResortObjectTestObject(key, value);
                result.Objects.Add(obj);
            }

            return result;
        }
    }
}
