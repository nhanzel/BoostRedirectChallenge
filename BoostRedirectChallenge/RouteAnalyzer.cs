using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostRedirectChallenge
{
    public interface RouteAnalyzer
    {
        public IEnumerable<string> Process(IEnumerable<string> routes);
    }
}
