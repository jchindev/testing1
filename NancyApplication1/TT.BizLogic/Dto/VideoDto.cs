using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.BizLogic.Dto
{
    public class VideoDto : EntityDto
    {
        public string Title { get; set; }
        public string Tournament { get; set; }
        public string Description { get; set; }
        public string Stroke { get; set; }
        public string Angle { get; set; }
        public string Player { get; set; }
        public string YoutubeId { get; set; }
    }
}
