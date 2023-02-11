using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyME.Models
{
    public class SurveyForms
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Editor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofCreation { get; set; }
        public DateTime? DateofModification { get; set; }
        public string IPAddress { get; set; }
        public string ProjectName { get; set; }
        public string MinistryName { get; set; }
        public string SurveyTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string SurveyDescription { get; set; }

        public string MainResearchArea { get; set; }
        public string ResearchArea { get; set; }
        public bool Male_gender { get; set; }
        public bool Female_gender { get; set; }
        public bool Non_binary_gender { get; set; }
        public bool Age_group_A { get; set; }
        public bool Age_group_B { get; set; }
        public bool Age_group_C { get; set; }
        public bool Age_group_D { get; set; }
        public bool Age_group_E { get; set; }
        public bool Target_PWDs { get; set; }
        public bool Status_Single { get; set; }
        public bool Status_Married { get; set; }
        public bool Academic_Level_Primary { get; set; }
        public bool Academic_Level_Secondary { get; set; }
        public bool Academic_Level_Diploma { get; set; }
        public bool Academic_Level_Degree { get; set; }
        public bool Academic_Level_Masters { get; set; }
        public bool Academic_Level_PhD { get; set; }
    }
}