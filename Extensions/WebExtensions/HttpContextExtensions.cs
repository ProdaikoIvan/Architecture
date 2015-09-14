using System.Web;

namespace Extensions.WebExtensions
{
    public static class HttpContextExtensions
    {
        public static bool IsAuthenticated(this HttpContextBase context)
        {
            return context.User != null && context.User.Identity.IsAuthenticated;
        }
    }
}