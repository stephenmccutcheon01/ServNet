using System.Collections.Generic;
using System.Web.Mvc;

namespace ServeNet.Models
{
    /// <summary>
    ///     The main model for the FAQ Page
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class FaqModelView
    {
        #region properties

        /// <summary>
        ///     Header Text
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string HeaderText { get; set; }

        /// <summary>
        ///    Footer Text
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string FooterText { get; set; }

        /// <summary>
        ///     Sections
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public List<FaqSectionItem> Sections { get; set; }

        /// <summary>
        ///     Selected Section ID
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public int SelectedSectionId { get; set; }

        /// <summary>
        ///    Selected Section
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public FaqSectionItem SelectedSection { get; set; }

        /// <summary>
        ///     Sections Drop Down
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public IEnumerable<SelectListItem> SectionsDropDown { get; set; }

        #endregion properties
    }

    /// <summary>
    ///     The Section Object in the FAQ Model
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class FaqSectionItem
    {
        #region properties

        /// <summary>
        ///     Scetion ID
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string SectionId { get; set; }

        /// <summary>
        ///     Section ID Data Source
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string SectionIdDataSource { get; set; }

        /// <summary>
        ///     Section
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string Section { get; set; }

        /// <summary>
        ///      Questions
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public List<FaqQuestionItem> Questions { get; set; }

        #endregion properties
    }

    /// <summary>
    ///    The Question Object in the FAQ Model
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    public class FaqQuestionItem
    {
        #region properties

        /// <summary>
        ///    Question ID
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string QuestionId { get; set; }

        /// <summary>
        ///     Question ID Data Source
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string QuestionIdDataSource { get; set; }

        /// <summary>
        ///     Question
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string Question { get; set; }

        /// <summary>
        ///     Answer
        /// </summary>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public string Answer { get; set; }

        #endregion properties
    }
}