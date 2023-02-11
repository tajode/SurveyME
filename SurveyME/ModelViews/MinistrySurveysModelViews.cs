using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SurveyME.ModelViews
{
    public class MinistrySurveysModelViews
    {
        public string Ministry { get; set; }
        public int SurveyCount { get; set; }
    }
}