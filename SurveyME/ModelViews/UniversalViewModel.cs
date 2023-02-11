using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurveyME.Models;

namespace SurveyME.ModelViews
{
    public class UniversalViewModel
    {
        public SurveyForms SurveyForms { get; set; }
        public Professions Professions { get; set; }
        public ResearchAreas ResearchAreas { get; set; }
        public Profile Profile { get; set; }
        public EmployerDetails EmployerDetails { get; set; }
        public MinistryDetails MinistryDetails { get; set; }
        public SurveyQuestionType SurveyQuestionType { get; set; }
        public BinaryChoice BinaryChoice { get; set; }
        public Sections Sections { get; set; }
    }
}