using System;
using System.Collections.Generic;

namespace ServeNet.Models
{
    /// <summary>
    ///     The main Model for the Server Object
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class ServerViewIndexModel
    {
        #region properties

        /// <summary>
        ///     Servers
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public List<ServerViewIndexItem> Servers { get; set; }

        #endregion properties
    }

    /// <summary>
    ///     A Server object which contains the ID and the Description,
    ///     Used for selecting a severe to view the details
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class ServerViewIndexItem
    {
        #region properties

        /// <summary>
        ///     Server ID
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string ServerId { get; set; }

        /// <summary>
        ///     Server Description
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string ServerDescription { get; set; }

        #endregion properties
    }

    /// <summary>
    ///    The parent Object for the server specific details
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class ServerDetailModel
    {
        #region properties

        /// <summary>
        ///     Server ID
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string ServerId { get; set; }

        /// <summary>
        ///     Server Description
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string ServerDescription { get; set; }

        /// <summary>
        ///     Service Description
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string ServiceDescription { get; set; }

        /// <summary>
        ///     IP Addresses
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string[] IpAddresses { get; set; }

        /// <summary>
        ///      Reverse DNS
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public List<ServerDetailReverseDns> ReverseDns { get; set; }

        /// <summary>
        ///     Has Reverse DNS Entry
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public bool HasReverseDnsEntry { get; set; }

        /// <summary>
        ///     No Reverss DNS Entry Message
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string NoReverseDnsEntryMessage { get; set; }

        /// <summary>
        ///     Bandwith Info
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public BandwithInfo BandWidthInfo { get; set; }

        /// <summary>
        ///     Monitor Status
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public List<MonitorStatusModel> MonitorStatus { get; set; }

        #endregion properties
    }

    /// <summary>
    ///     The reverse dns info for a server
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class ServerDetailReverseDns
    {
        #region properties

        /// <summary>
        ///     HOst Name
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string HostName { get; set; }

        /// <summary>
        ///     IP Address
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string IpAddres { get; set; }

        #endregion properties
    }

    /// <summary>
    ///      The bandiwth info for a server
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class BandwithInfo
    {
        #region properties

        /// <summary>
        ///    Bw24HIn
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long Bw24HIn { get; set; }

        /// <summary>
        ///    Bw24HOutFields
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long Bw24HOutField { get; set; }

        /// <summary>
        ///    bw4HInField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long Bw4HInField { get; set; }

        /// <summary>
        ///    bw4HOutField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long Bw4HOutField { get; set; }

        /// <summary>
        ///    BwPredicted14DInField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwPredicted14DInField { get; set; }

        /// <summary>
        ///    BwPresdivted14DOutField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwPredicted14DOutField { get; set; }

        /// <summary>
        ///    BwPredicted24HInField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwPredicted24HInField { get; set; }

        /// <summary>
        ///    BwPredicted24HOutField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwPredicted24HOutField { get; set; }

        /// <summary>
        ///     BwsofarThisMonthInField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwSofarThisMonthInField { get; set; }

        /// <summary>
        ///     BWSofarThisMonthOutField
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long BwSofarThisMonthOutField { get; set; }

        /// <summary>
        ///     Last Updated Field
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public long LastUpdatedField { get; set; }

        #endregion properties

    }

    /// <summary>
    ///     The monitor info for a server
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class MonitorStatusModel
    {
        #region properties

        /// <summary>
        ///    Test Id
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public int TestId { get; set; }

        /// <summary>
        ///     Test Name
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string TestName { get; set; }

        /// <summary>
        ///     Status Code
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string StatusCode { get; set; }

        /// <summary>
        ///     Monitored IP
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string MonitoredIp { get; set; }

        /// <summary>
        ///      Status Details
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string StatusDetail { get; set; }

        /// <summary>
        ///       Test Type
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string TestType { get; set; }

        /// <summary>
        ///        Last Updated
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        ///     LAst Status Change
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public DateTime LastStatusChange { get; set; }

        #endregion properties
    }
}