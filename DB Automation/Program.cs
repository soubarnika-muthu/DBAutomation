using System;

namespace DB_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Spotify DB automation");
            DBOperations db = new DBOperations();
           // db.Connect();
            
            Console.ReadLine();
        }
    }
}
