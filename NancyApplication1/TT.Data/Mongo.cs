using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TT.Data
{
    public interface IMongo
    {
        MongoDatabase Database { get; }
    }

    public class Mongo : IMongo
    {
        public MongoDatabase Database
        {
            get
            {
                return MongoDatabase.Create(GetMongoDbConnectionString());
            }
        }

        private string GetMongoDbConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MONGOLAB_URI");
        }
    }
}
