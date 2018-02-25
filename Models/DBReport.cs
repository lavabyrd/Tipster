using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Tipster.Models
{
    public static class Reports
    {
        public static List<BsonDocument> ReportAll() {
            MongoClient client = new MongoClient("mongodb://HorseTipsRW:G3n3rat3dP4s5write@ds135039.mlab.com:35039/todompreston");
            IMongoDatabase database = client.GetDatabase("todompreston");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("TestHorseRaceCollection");


            var result = collec.Find(_ => true).ToList();


            List<BsonDocument> entries = new List<BsonDocument>();
            foreach (var doc in result)
            {
                entries.Add(doc);
            }

            return result;
        }
    }
}
