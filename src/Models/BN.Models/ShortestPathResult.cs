using System;
using System.Collections.Generic;
using System.Text;

namespace BN.Models
{
    public class ShortestPathResult
    {
        public bool IsPathFound { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public IEnumerable<string> Path { get; set; }
    }
}
