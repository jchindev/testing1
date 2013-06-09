using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.BizLogic.Dto
{
    public class ValueLookUpDto : EntityDto
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }

    }
}
