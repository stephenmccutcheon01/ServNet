using System.Collections.Generic;
using System.Web.Mvc;
using ServeNet.Models;
using ServeNet.MySerciceAPIService;
using ServeNet.Properties;

namespace ServeNet.Controllers
{
    /// <summary>
    ///     Controller for the server section
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    [Authorize]
    public class ServersController : Controller
    {
        /// <summary>
        ///     This displays a list of serveres on the view
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
                
                //Get all the server details
                var servers = apiClient.GetAllServerDetails(authInfo);

                //populate the server details into the model
                var viewModels = new ServerViewIndexModel()
                {
                    Servers = new List<ServerViewIndexItem>()
                };
              
                foreach (var server in servers)
                {
                    var serverViewModel1 = new ServerViewIndexItem()
                    {
                        ServerDescription = server.YourReference,
                        ServerId = server.ServiceID
                    };
                    
                    viewModels.Servers.Add(serverViewModel1);
                }

                return View(viewModels);
            }
        }

        /// <summary>
        ///     On Selecting a server, this retuens the details to the model
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Details(string serverId)
        {
            using (var apiClient = new MyServersApiClient())
            {
                var authInfo = new AuthInfo
                {
                    Username = Settings.Default.APIUserName,
                    Password = Settings.Default.APIPassword
                };

                ServerDetailModel detailsModel;
                var serversDetails = GetServerDetails(serverId, apiClient, authInfo, out detailsModel);


                GetReversDnsDetails(serversDetails, detailsModel);

                GetBandWidthInfo(apiClient, authInfo, serversDetails, detailsModel);

                GetMonitoringInfo(apiClient, authInfo, serversDetails, detailsModel);

                return View(detailsModel);
            }
        }


        #region private methods

        /// <summary>
        ///     Gets the Monitoring Info for the Server and populates it into the model
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="authInfo"></param>
        /// <param name="serversDetails"></param>
        /// <param name="detailsModel"></param>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static void GetMonitoringInfo(MyServersApiClient apiClient, AuthInfo authInfo, ServerInfo serversDetails,
            ServerDetailModel detailsModel)
        {
            var monitorReport = apiClient.GetServerStatus(authInfo, serversDetails.ServiceID);

            detailsModel.MonitorStatus = new List<MonitorStatusModel>();

            if (monitorReport != null)
                foreach (var mon in monitorReport)
                {
                    var monitormodel = new MonitorStatusModel
                    {
                        TestId = mon.TestId,
                        TestName = mon.TestName,
                        TestType = mon.TestType,
                        StatusCode = mon.StatusCode,
                        MonitoredIp = mon.MonitoredIp,
                        StatusDetail = mon.StatusDetail,
                        LastUpdated = mon.LastUpdated,
                        LastStatusChange = mon.LastStatusChange
                    };

                    detailsModel.MonitorStatus.Add(monitormodel);
                }
        }

        /// <summary>
        ///     Gets the bandwith width info from the server and populautes it into the model
        /// </summary>
        /// <param name="apiClient"></param>
        /// <param name="authInfo"></param>
        /// <param name="serversDetails"></param>
        /// <param name="detailsModel"></param>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static void GetBandWidthInfo(MyServersApiClient apiClient, AuthInfo authInfo, ServerInfo serversDetails,
            ServerDetailModel detailsModel)
        {
            var bandwithReport = apiClient.GetServerBandwidthReport(authInfo, serversDetails.ServiceID, true);


            detailsModel.BandWidthInfo = new BandwithInfo
            {
                Bw24HIn = bandwithReport.BW24hIn,
                Bw24HOutField = bandwithReport.BW24hOut,
                Bw4HInField = bandwithReport.BW4hIn,
                Bw4HOutField = bandwithReport.BW4hOut,
                BwPredicted14DInField = bandwithReport.BWPredicted14dIn,
                BwPredicted14DOutField = bandwithReport.BWPredicted14dOut,
                BwPredicted24HInField = bandwithReport.BWPredicted24hIn,
                BwPredicted24HOutField = bandwithReport.BWPredicted24hOut,
                BwSofarThisMonthInField = bandwithReport.BWSofarThisMonthIn,
                BwSofarThisMonthOutField = bandwithReport.BWSofarThisMonthOut
            };
        }

        /// <summary>
        ///    Gets the Revers DNS Details Info
        /// </summary>
        /// <param name="serversDetails"></param>
        /// <param name="detailsModel"></param>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static void GetReversDnsDetails(ServerInfo serversDetails, ServerDetailModel detailsModel)
        {
            if (serversDetails.ReverseDnsEntries != null &&
                serversDetails.ReverseDnsEntries.Length > 0)
            {
                detailsModel.HasReverseDnsEntry = true;
                foreach (var reverseDns in serversDetails.ReverseDnsEntries)
                {
                    var serverRevDns = new ServerDetailReverseDns
                    {
                        HostName = reverseDns.HostName,
                        IpAddres = reverseDns.IPAddress
                    };

                    detailsModel.ReverseDns.Add(serverRevDns);
                }
            }
        }

        /// <summary>
        ///     Gets the Server Details
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="apiClient"></param>
        /// <param name="authInfo"></param>
        /// <param name="detailsModel"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static ServerInfo GetServerDetails(string serverId, MyServersApiClient apiClient, AuthInfo authInfo,
            out ServerDetailModel detailsModel)
        {
            var serversDetails = apiClient.GetServerDetails(authInfo, serverId);

            detailsModel = new ServerDetailModel()
            {
                ServerId = serversDetails.ServiceID,
                ServerDescription = serversDetails.YourReference,
                ServiceDescription = serversDetails.ServiceDescription,
                IpAddresses = serversDetails.IPAddresses,
                ReverseDns = new List<ServerDetailReverseDns>(),
                HasReverseDnsEntry = false,
                NoReverseDnsEntryMessage = Settings.Default.NoDNSInfo
            };
            return serversDetails;
        }

        #endregion private methods
    }
}