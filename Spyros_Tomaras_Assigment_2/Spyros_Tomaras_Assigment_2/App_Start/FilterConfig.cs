using System.Web;
using System.Web.Mvc;

namespace Spyros_Tomaras_Assigment_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
