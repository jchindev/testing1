using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TT.BizLogic.Dto;

namespace TT.BizLogic
{
    public class ValueLookUp : BaseBizObject
    {
        private readonly MongoCollection<ValueLookUpDto> _colLookups;

        public ValueLookUp()
        {
            _colLookups = _mongodb.GetCollection<ValueLookUpDto>("ValueLookUp");
        }

        public dynamic Get(string key)
        {
            var query = Query.EQ("Name", key);
            var val = _colLookups.FindOne(query);

            return val == null ? null : val.Value;
        }

        public List<ValueLookUpDto> GetAll()
        {
            return _colLookups.FindAll().ToList();
        }

    }
}
