using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TT.BizLogic.Dto
{
    public class StrokeDto
    {
        public int UserId { get; set; }
        public StrokeType StrokeType { get; set; }
        public StrokeAngle StrokeAngle { get; set; }
        public Stream StrokeVideo { get; set; }
    }
}
