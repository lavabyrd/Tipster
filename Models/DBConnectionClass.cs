using System;
using Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Tipster.Models
{
    public static class DBConnectionClass
    {
        public static IMongoCollection<BsonDocument> DBConnectReadWrite()
        {
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["dbRWUser"]);
            IMongoDatabase database = client.GetDatabase("todompreston");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("TestHorseRaceCollection");
            Console.WriteLine("Write Collec working?");
            return collec;
        }


        public static IMongoCollection<BsonDocument> DBConnectRead()
        {
            //MongoClient client = new MongoClient(ConfigurationManager.AppSettings["dbRUser"]);
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["dbRUser"]);
            IMongoDatabase database = client.GetDatabase("todompreston");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("TestHorseRaceCollection");
            Console.WriteLine("Read Collec working?");
            return collec;
        }
    }
}
