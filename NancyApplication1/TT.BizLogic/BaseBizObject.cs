using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TT.Data;

namespace TT.BizLogic
{
    public class BaseBizObject
    {
        protected MongoDatabase _mongodb;

        public BaseBizObject()
        {
            _mongodb = new Mongo().Database;
        }

        public BaseBizObject(IMongo mongo)
        {
            _mongodb = mongo.Database;
        }

    }
}
