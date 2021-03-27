using System;
using System.Collections.Generic;

namespace BN.Models
{
    public class Slope : IResortObject
    {
        public SlopeStatus Status { get; set; }
        public SlopeDifficulty Difficulty { get; set; }
        public IEnumerable<string> Notes { get; set; }
        public string LiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StopDate { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public int TopHeight { get; set; }
        public int BottomHeight { get; set; }
        public bool CanBeUsedInNavigation => Status == SlopeStatus.Open;
        public ResortObjectType Type => ResortObjectType.Slope;
        public IList<string> Neighbours { get; } = new List<string>();
    }
}