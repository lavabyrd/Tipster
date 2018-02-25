using System;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Configuration;
using System.Linq;

namespace Tipster.Models
{
    public static class DBInteractionClass
    {
        
        // looks after the uploading of the CSV File. If files aleady exist, deletes all and then uploads the file
        public static void DbCSVUpload(BsonDocument docu)
        {
            IMongoCollection<BsonDocument> collec = DBConnectionClass.DBConnectReadWrite();

            collec.InsertOne(docu);
        }
        // checks the count of items in the collection
        public static void DbWipe()
        {
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["dbRWUser"]);
            IMongoDatabase database = client.GetDatabase("todompreston");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("TestHorseRaceCollection");
            long count = collec.Count(new BsonDocument());
            if (count > 1)
            {
                database.DropCollection("TestHorseRaceCollection");
                Console.WriteLine("deleting");
                Console.Read();
            }

        }
        // queries the collect and returns all item writing just the coursename
        public static async Task DbQuery() {
            IMongoCollection<BsonDocument> collec = DBConnectionClass.DBConnectRead();
            using (IAsyncCursor<BsonDocument> cursor = await collec.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;

                    foreach (BsonDocument document in batch)
                    {
                        // needs to check if nothing found
                        Console.WriteLine(document["CourseName"]);
                    }
                }
            }
        }

        public static async Task<List<BsonDocument>> DBAll()
        {
            IMongoCollection<BsonDocument> collec = DBConnectionClass.DBConnectRead();

            List<BsonDocument> documents = await collec.Find(_ => true).ToListAsync();


            //var ehh = collec.AsQueryable();


            return documents;



        }

        public static async Task DbFilter() {
            IMongoCollection<BsonDocument> collec = DBConnectionClass.DBConnectRead();

            BsonDocument filter = new BsonDocument("Result", "true");

            await collec.Find(filter)
                .ForEachAsync(document => Console.WriteLine(document["CourseName"]));

        }

        // report to show years , Total Won and Total Lost
        //public static async Task DbFilterYear() {
        //    IMongoCollection<BsonDocument> collec = DBConnectionClass.DBConnectRead();

            
        //}

    }
}
