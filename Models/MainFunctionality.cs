using System;
using System.Threading.Tasks;


namespace Tipster.Models
{
    public static class TipsterAppBegin
    {
        public static string Test() {
            string letGo = "Can we return this?";
            return letGo;
        }


        public static void Start()
        {
            Console.WriteLine("1: View current stored data [ check ]");
            Console.WriteLine("2: Remove current data from the database");
            Console.WriteLine("3: Re-upload the CSV File again");
            Console.WriteLine("4: Filter by {$placeholder}");
            Console.WriteLine("5: Upload data");
            Console.WriteLine("6: Output data to a text file");
            Console.WriteLine("7: Exit");
            string answer = Console.ReadLine();



            //Selection(answer);
        }

        public static void Selection(string answer)
        {
            try
            {
                int parseAnswer = int.Parse(answer);
                if (parseAnswer < 1 || parseAnswer > 7)
                {
                    Console.WriteLine("Try another Selection");
                    Start();
                }
                else
                {
                    TakeAction(parseAnswer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is " + ex);
                Start();
            }
        }


        public static void TakeAction(int parseAnswer) {
            switch (parseAnswer)
            {
                case 1:
                    Task x = DBInteractionClass.DbQuery();
                    Console.Read();
                    Start();
                    break;
                case 2:
                    Console.WriteLine("Erasing all stored info");
                    DBInteractionClass.DbWipe();
                    Start();
                    break;
                case 3:
                    string outname = FileControl.FileGrab();
                    string fileContents = FileControl.ReadFile(outname);
                    string[] output = FileControl.ParseFile(fileContents);
                    Console.WriteLine("upload done!");
                    Console.WriteLine("back to the start we go!");
                    Start();
                    break;
                case 4:
                    Task filter = DBInteractionClass.DbFilter();
                    Console.Read();
                    Start();
                    break;
                case 5:
                    Upload.EntryUpload();
                    break;
                case 6:
                    // output data from the DB to a text file
                    Console.WriteLine("not currently implemented");
                    break;
                default:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
