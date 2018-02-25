using System;
using System.IO;
using MongoDB.Bson;

namespace Tipster.Models
{
    public static class FileControl
    {
        public static string FileGrab()
        {
            Console.WriteLine("Please hold, working!");
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "../../data.csv");
            return fileName;
        }
        // should check the file has entries and is valid
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
        // Parse file Method
        public static string[] ParseFile(string contents)
        {
            string splitString = "\n";
            string[] fileLines = contents.Split(new string[] { splitString }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in fileLines)
            {
                string l = line.Replace("(", "").Replace(")", ",").Replace(" ", "");
                string[] entry = l.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                // take each entry and do something
                string CourseName = entry[0];

                // Date comes in year/month/day, parse using DateTime.Parse and then .ToShortDateString().
                string DateRan = entry[1] + "-" + entry[2] + "-" + entry[3];
                string Amount = entry[4];
                string Result = entry[5];


                BsonDocument docu = new BsonDocument{
                    {"CourseName", CourseName},
                    {"DateRan", ParseControl.DateParse(DateRan)},
                    {"Amount", ParseControl.AmountParse(Amount)},
                    {"Result", ParseControl.ResultBoolCheck(Result)}
                };
                DBInteractionClass.DbCSVUpload(docu);
                Console.WriteLine(CourseName + " Added");
            }
            return fileLines;
        }
    }
}
