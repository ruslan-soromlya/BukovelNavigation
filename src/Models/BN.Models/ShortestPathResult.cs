using System;
using System.Collections.Generic;
using System.Text;

namespace BN.Models
{
    public class ShortestPathResult
    {
        public bool IsPathFound { get; set; }
        public IResortObject From { get; set; }
        public IResortObject To { get; set; }
        public IEnumerable<IResortObject> Path { get; set; }
    }
}
