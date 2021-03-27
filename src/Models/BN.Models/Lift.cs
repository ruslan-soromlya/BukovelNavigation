using System;
using System.Collections.Generic;

namespace BN.Models
{
    public class Lift : IResortObject
    {
        public bool IsOpen { get; set; }
        public int Traffic { get; set; }
        public LiftType Type { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public int Distance { get; set; }
        public int TopHeight { get; set; }
        public int BottomHeight { get; set; }
        public bool CanBeUsedInNavigation => IsOpen;
        public IList<string> Neighbours { get; } = new List<string>();
        ResortObjectType IResortObject.Type => ResortObjectType.Lift;
    }
}