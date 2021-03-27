using System;
using System.Collections.Generic;

namespace BN.Models
{
    public interface IResortObject
    {
        string Name { get; }
        int Distance { get; }
        int TopHeight { get; }
        int BottomHeight { get; }
        DateTime StartDate { get; }
        DateTime StopDate { get; }
        bool CanBeUsedInNavigation { get; }
        ResortObjectType Type { get; }
        IList<string> Neighbours { get; }
    }
}