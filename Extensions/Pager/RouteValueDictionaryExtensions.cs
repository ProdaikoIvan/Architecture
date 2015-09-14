using System.Collections;
using System.Web.Routing;

namespace Extensions.Pager
{
    public static class RouteValueDictionaryExtensions
    {
        public static RouteValueDictionary FixListRouteDataValues(this RouteValueDictionary routes)
        {
            var newRv = new RouteValueDictionary();
            foreach (var key in routes.Keys)
            {
                var value = routes[key];
                var vals = value as IEnumerable;
                if (vals != null && !(value is string))
                {
                    var index = 0;
                    foreach (var val in vals)
                    {
                        newRv.Add(string.Format("{0}[{1}]", key, index), val);
                        index++;
                    }
                }
                else
                {
                    newRv.Add(key, value);
                }
            }
            return newRv;
        }
    }
}