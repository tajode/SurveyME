using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SurveyME.Models;

namespace SurveyME.ModelViews
{
    public class CompleteSectionViewModel
    {
        public PagedList.IPagedList<Sections> sectionslist { get; set; }
        public List<BinaryChoice> binarychoicelist { get; set; }
    }
}