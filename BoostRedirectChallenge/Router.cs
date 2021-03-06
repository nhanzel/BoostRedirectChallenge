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
                    routePieces = routePieces.Select(x => x.Trim()).ToArray();
                    paths.Add(new RedirectPath(routePieces.ToList()));
            }

            string[] keys = paths.Where(x => x.Path.Count > 1).Select(x => x.Path[0]).ToArray();

            foreach (var key in keys)
            {
                if (paths.Exists(x => x.Path[x.Path.Count - 1] == key))
                {
                    RedirectPath choppingBlock = paths.First(x => x.Path[0] == key);
                    int appendIndex = paths.FindIndex(x => x.Path[x.Path.Count - 1] == key);
                    if (paths[appendIndex].Path.Contains(choppingBlock.Path[choppingBlock.Path.Count - 1]))
                    {
                        throw new Exception("Infinite redirect");
                    }
                    paths[appendIndex].Path = paths[appendIndex].Path.Concat(choppingBlock.Path.Skip(1)).ToList();
                    paths = paths.Where(x => x.Path[0] != key).ToList();
                }
            }

            string[] result = new string[paths.Count];
            int counter = 0;

            foreach (var path in paths)
            {
                result[counter++] = string.Join(" -> ", path.Path);
            }

            return result;
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
