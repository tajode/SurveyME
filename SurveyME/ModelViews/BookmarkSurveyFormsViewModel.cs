using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveyME.ModelViews
{
    public class BookmarkSurveyFormsViewModel
    {
        public int Id { get; set; }
        public string SurveyFormID { get; set; }
        public string UserName { get; set; }
        public string BookmarkStatus { get; set; }
        public DateTime DateofCreation { get; set; }
        public DateTime? DateofStatusChange { get; set; }
    }
}