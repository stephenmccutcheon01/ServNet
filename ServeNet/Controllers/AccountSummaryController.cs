using System.Web.Mvc;
using ServeNet.Models;
using ServeNet.MySerciceAPIService;
using ServeNet.Properties;

namespace ServeNet.Controllers
{
    /// <summary>
    ///     This is the controller which Gets the Financial accounts Summary from
    ///     The web api and displays it back to the User
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    [Authorize]
    public class AccountSummaryController : Controller
    {
        /// <summary>
        ///    Loads the Model with Information on ONload of the Page
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Index()
        {
           
            using (var apiClient = new MyServersApiClient())
            {
                var authInfo = new AuthInfo
                {
                    Username = Settings.Default.APIUserName,
                    Password = Settings.Default.APIPassword
                };

                //Calls the Web api to Get the Account Summary
                var accountSummary = apiClient.GetAccountSummary(authInfo);

                //Populates the apprioprate data into the View Model
                var viewModels = new AccountSummaryViewModel
                {
                    Balance = accountSummary.Balance.ToString("C"),
                    NextPaymentAmount = accountSummary.NextPaymentAmount.ToString("C"),
                    NextPaymentDate = accountSummary.NextPaymentDate,
                    OverdueInvoices = accountSummary.OverdueInvoices,
                    UnpaidInvoices = accountSummary.UnpaidInvoices
                };

                //Returns the model to the View
                return View(viewModels);
            }
        }
    }
}