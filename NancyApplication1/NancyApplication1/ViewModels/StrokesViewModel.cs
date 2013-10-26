using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.BizLogic;

namespace TT.Web.ViewModels
{
    public class StrokesViewModel : BaseViewModel
    {
        public bool IsSuccessfulUpload { get; set; }
        public string UserStrokeUrl { get; set; }
        public string ProfessionStrokeUrl { get; set; }
    }
}