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
            List<RedirectPath> paths = new List<RedirectPath>();

            List<KeyValuePair<string, string>> redirects = new List<KeyValuePair<string, string>>();
            foreach (var route in routes)
            {
                var routePieces = route.Split("->");
                paths.Add(new RedirectPath(routePieces.ToList()));
            }
            return new List<string>();
        }
    }

    public class RedirectPath
    {
        public RedirectPath(List<string> _path)
        {
            Path = _path;
        }
        public List<string> Path { get; set; } = new List<string>();
    }
}
