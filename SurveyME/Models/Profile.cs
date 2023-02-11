using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyME.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Editor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofCreation { get; set; }
        public DateTime? DateofModification { get; set; }
        public string IPAddress { get; set; }
        public string Profession { get; set; }
        public string NameofEmployer { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}