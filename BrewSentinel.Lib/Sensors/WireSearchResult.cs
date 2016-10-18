using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewSentinel.Lib.Sensors
{
    public class WireSearchResult
    {
        public byte[] id = new byte[8];
        public int lastForkPoint = 0;
    }
}
