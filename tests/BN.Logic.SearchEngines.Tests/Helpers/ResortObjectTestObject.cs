using BN.Models;
using System;
using System.Collections.Generic;

namespace BN.Logic.SearchEngines.Tests.Helpers
{
    public class ResortObjectTestObject : IResortObject
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int Distance { get; set; }
        public int TopHeight { get; set; }
        public int BottomHeight { get; set; }
        public bool CanBeUsedInNavigation => true;
        public IList<string> Neighbours { get; }
        ResortObjectType IResortObject.Type => ResortObjectType.Lift;

        public ResortObjectTestObject(string name)
            : this(name, new List<string>())
        {

        }

        public ResortObjectTestObject(string name, List<string> neighbours)
        {
            Name = name;
            Neighbours = neighbours;
        }
    }
}
