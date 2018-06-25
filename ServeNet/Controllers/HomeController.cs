using System.Web.Mvc;

namespace ServeNet.Controllers
{
    /// <summary>
    ///     Initial Main Controller For Landing page, about and contact
    /// </summary>
    /// <remarks>
    ///     Date:   24/06/2018
    ///     Author: Stephen McCutcheon
    /// </remarks>
    public class HomeController : Controller
    {
        /// <summary>
        ///     Landing Page
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     Date:   24/06/2018
        ///     Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     About Page
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     Date:   24/06/2018
        ///     Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        ///     Contact Page
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     Date:   24/06/2018
        ///     Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Contact()
        {
            return View();
        }
    }
}