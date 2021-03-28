using BN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BN.Logic.SearchEngines.Tests.Helpers
{
    public class ResortInfoBuiler
    {
        private Dictionary<string, List<string>> _resortInfo { get; set; } = new Dictionary<string, List<string>>();
        

        public ResortInfoBuiler ParseABNRelation(string abRelation)
        {
            var verticies = abRelation.Split("-").Select(x => x.Trim()).ToList();

            for (int i = 0; i < verticies.Count - 1; i++)
            {
                var from = verticies[i];
                var to = verticies[i + 1];

                if (_resortInfo.ContainsKey(from))
                {
                    _resortInfo[from].Add(to);
                }
                else
                {
                    _resortInfo[from] = new List<string> { to };
                }
            }

            _resortInfo[verticies.Last()] = new List<string>();

            return this;
        }

        public ResortInfrastructure Build()
        {
            var result = new ResortInfrastructure();
            result.Objects = new List<IResortObject>();

            foreach(var item in _resortInfo)
            {
                var obj = new ResortObjectTestObject(item.Key, item.Value);
                result.Objects.Add(obj);
            }

            return result;
        }
    }

    public class ResInfo : IResortObject
    {
        public string Name => throw new NotImplementedException();

        public int Distance => throw new NotImplementedException();

        public int TopHeight => throw new NotImplementedException();

        public int BottomHeight => throw new NotImplementedException();

        public DateTime StartDate => throw new NotImplementedException();

        public DateTime StopDate => throw new NotImplementedException();

        public bool CanBeUsedInNavigation => throw new NotImplementedException();

        public ResortObjectType Type => throw new NotImplementedException();

        public IList<string> Neighbours => throw new NotImplementedException();
    }
}
