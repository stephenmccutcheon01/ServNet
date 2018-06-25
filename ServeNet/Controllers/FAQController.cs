using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ServeNet.Models;
using ServeNet.MySerciceAPIService;
using ServeNet.Properties;

namespace ServeNet.Controllers
{
    /// <summary>
    ///     The controllere for the frequeently asked questions Page
    ///     it filters teh questions by the section and displays them to the user
    /// </summary>
    /// <remarks>
    ///      Date:   24/06/2018
    ///      Author: Stephen McCutcheon
    /// </remarks>
    [Authorize]
    public class FaqController : Controller
    {
        /// <summary>
        ///     On Post, Refreshs the model with the new selected Section 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        [HttpPost]
        public ActionResult Index(FaqModelView model)
        {
            return Index(Convert.ToInt32(model.SelectedSectionId));
        }

        /// <summary>
        ///     On Loading the FAQ Page, get all the sections, questions and answers
        /// </summary>
        /// <param name="selectedSectionId"></param>
        /// <returns></returns>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        public ActionResult Index(int? selectedSectionId)
        {
            using (var apiClient = new MyServersApiClient())
            {
                var authInfo = new AuthInfo
                {
                    Username = Settings.Default.APIUserName,
                    Password = Settings.Default.APIPassword
                };
                
                //Get the FAQ Data rom the WEB API
                var faq = apiClient.GetFAQ(authInfo);


                //Initiate the Model for the View
                var faqModels = new FaqModelView
                {
                    HeaderText = faq.HeaderText,
                    FooterText = faq.FooterText,
                    Sections = new List<FaqSectionItem>()
                };

                //Determine what section to show
                if (selectedSectionId != null)
                {
                    faqModels.SelectedSectionId = selectedSectionId.Value;
                }
                else
                {
                    var firstSection = faq.Sections.FirstOrDefault();

                    if (firstSection != null) faqModels.SelectedSectionId = firstSection.SectionID;
                }


                //Load the selected section into the View Model
                LoadQuestionsIntoViewModel(faq, faqModels, apiClient, authInfo);

                //Populate the section drop down with all the sections in the FAQ
                faqModels.SectionsDropDown = (from x in faq.Sections
                    select new SelectListItem
                    {
                        Text = x.Section,
                        Value = x.SectionID.ToString()
                    }).ToList();

                return View(faqModels);
            }
        }


        #region private methods

        /// <summary>
        ///    Loads the Questions for each section into the FAQ Model
        /// </summary>
        /// <param name="faq"></param>
        /// <param name="faqModels"></param>
        /// <param name="apiClient"></param>
        /// <param name="authInfo"></param>
        /// <remarks>
        ///      Date:   24/06/2018
        ///      Author: Stephen McCutcheon
        /// </remarks>
        private static void LoadQuestionsIntoViewModel(FAQ faq, FaqModelView faqModels, MyServersApiClient apiClient,
            AuthInfo authInfo)
        {
            var sectioncounter = 0;
            var questionCounter = 0;

            //Loads in all the sections and Questions for the selected section
            var section = (from x in faq.Sections
                where x.SectionID == faqModels.SelectedSectionId
                select x).FirstOrDefault();

            if (section != null)
            {
                var sectionModel = new FaqSectionItem
                {
                    SectionId = "Section" + sectioncounter,
                    SectionIdDataSource = "#Section" + sectioncounter,
                    Section = section.Section,
                    Questions = new List<FaqQuestionItem>()
                };

                var quest1 = apiClient.GetAllQuestions(authInfo, section.SectionID);

                foreach (var question in quest1)
                {
                    var questionModel = new FaqQuestionItem
                    {
                        QuestionId = "Question" + questionCounter,
                        QuestionIdDataSource = "#Question" + questionCounter,
                        Question = question.Question,
                        Answer = question.Answer
                    };

                    sectionModel.Questions.Add(questionModel);
                    questionCounter = questionCounter + 1;
                }

                faqModels.SelectedSection = sectionModel;
                faqModels.Sections.Add(sectionModel);
            }
        }

        #endregion private methods
    }
}