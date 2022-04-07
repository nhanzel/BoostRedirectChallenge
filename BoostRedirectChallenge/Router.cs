using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostRedirectChallenge
{
    public class Router : RouteAnalyzer
    {
        public IEnumerable<string> Process(IEnumerable<string> routes)
        {

        }
    }

    public class RedirectPath
    {
        public List<string> Path { get; set; } = new List<string>();
    }
}
