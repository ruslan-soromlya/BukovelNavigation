using System.Collections.Generic;

namespace BN.Models
{
    public class ResortInfrastructure
    {
        public IList<IResortObject> Objects { get; set; } = new List<IResortObject>();
    }
}