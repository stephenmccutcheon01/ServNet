using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServeNet.Models;
using ServeNet.MySerciceAPIService;
using ServeNet.Properties;

namespace ServeNet.Controllers
{
    /// <summary>
    ///     This is the controller which gets the top level domains information
    ///     Back from the web api
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    [Authorize]
    public class DomainsController : Controller
    {
        
        /// <summary>
        ///    This loads teh view from the model and implements paging so
        ///    not all rows are returend on 10 at a time
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Index(int? pageNumber)
        {
            using (var apiClient = new MyServersApiClient())
            {
                var authInfo = new AuthInfo
                {
                    Username = Settings.Default.APIUserName,
                    Password = Settings.Default.APIPassword
                };

                //Gets all the Top Level Domains Details
                var topLevelDomains = apiClient.GetAllTLDs(authInfo);


                //Page checks to ensure the page number does not go off the
                //end of pages. Basically if you try and access a page before or after
                //itdefaults back to the first or last page accordingly
                int startPos;
                var viewModels = SetMaxAndMinPagesViewModels(pageNumber, topLevelDomains, out startPos);

                //Set the apprioprate values in the Modl
                foreach (var domain in topLevelDomains.Skip(startPos).Take(10))
                {
                    var domainItem = new DomainItem
                    {
                        DomainId = domain.TLD,
                        DomainCost = domain.Cost.ToString("C"),
                        MaxPeriod = domain.MaxPeriod,
                        MinPeriod = domain.MinPeriod
                    };

                    viewModels.Items.Add(domainItem);
                }

                return View(viewModels);
            }
        }

        #region private methods

        /// <summary>
        ///     Keeps the page number within a valid range, it defaults back to the first page
        ///     or last page if a page is referenced outwith that rand
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="topLevelDomains"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static DomainsViewModel SetMaxAndMinPagesViewModels(int? pageNumber, TopLevelDomain[] topLevelDomains,
            out int startPos)
        {
            if (pageNumber == null) pageNumber = 0;

            if (pageNumber < 0) pageNumber = 0;

            var viewModels = new DomainsViewModel
            {
                PageNumber = pageNumber,
                Items = new List<DomainItem>()
            };

            startPos = 0;


            startPos = pageNumber.Value * 10;

            if (startPos > topLevelDomains.Length)
            {
                viewModels.PageNumber = topLevelDomains.Length / 10;
                startPos = viewModels.PageNumber.Value * 10;
            }

            return viewModels;
        }

        #endregion private methods
    }
}