using System;

namespace ServeNet.Models
{
    /// <summary>
    ///      The Model for the Account Summary Page
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class AccountSummaryViewModel
    {
        #region properties

        /// <summary>
        ///    Balance
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string Balance { get; set; }

        /// <summary>
        ///     Next Payment Amount
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string NextPaymentAmount { get; set; }

        /// <summary>
        ///     Next Payment Date
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public DateTime NextPaymentDate { get; set; }

        /// <summary>
        ///     Overdue Invoices
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public int OverdueInvoices { get; set; }

        /// <summary>
        ///     Unpaid Invoices
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public int UnpaidInvoices { get; set; }

        #endregion properties
    }
}