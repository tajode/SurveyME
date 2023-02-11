using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyME.Models
{
    public class Sections
    {
        public int Id { get; set; }
        public int SurveyForm_Id { get; set; }
        public string UserName { get; set; }
        public string Editor { get; set; }
        public DateTime DateofCreation { get; set; }
        public DateTime? DateofModification { get; set; }
        public string IPAddress { get; set; }
        public string SectionTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string SectionDescription { get; set; }
    }
}