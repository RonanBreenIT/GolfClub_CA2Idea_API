using System.Web;
using System.Web.Mvc;

namespace GolfClub_CA2Idea_API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
