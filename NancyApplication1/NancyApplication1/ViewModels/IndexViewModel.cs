using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TT.BizLogic;

namespace TT.Web.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        public string BlogBaseURl { get; set; }
        public string EspnNewsURl { get; set; }
        public List<VideoResult> VideoResults { get; set; }
    }
}