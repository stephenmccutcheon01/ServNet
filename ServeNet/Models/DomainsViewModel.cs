using System.Collections.Generic;

namespace ServeNet.Models
{
    /// <summary>
    ///    Main Model for the Domain Page
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class DomainsViewModel
    {
        #region properties

        /// <summary>
        ///     Page Number
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        ///     Items to Display
        /// </summary>
        public List<DomainItem> Items { get; set; }

        #endregion properties
    }

    /// <summary>
    ///    A LIst of the each top level domain
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class DomainItem
    {
        #region properties

        /// <summary>
        ///    Domain ID
        /// </summary>
        public string DomainId { get; set; }

        /// <summary>
        ///     Min Period
        /// </summary>
        public int MinPeriod { get; set; }

        /// <summary>
        ///      Max Period
        /// </summary>
        public int MaxPeriod { get; set; }

        /// <summary>
        ///      Domain Cost (string to show currency folder)
        /// </summary>
        public string DomainCost { get; set; }

        #endregion properties
    }
}