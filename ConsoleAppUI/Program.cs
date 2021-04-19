using ClassLibrary.DataAccess;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App start...");


            //save
            for (int i = 0; i < 100; i++)
            {
                Person p2 = new Person { FirstName = $"App{i}", LastName = "Carlitos" };
                SQLiteDataAccess.Save(p2);
            }


            // get
            var people = SQLiteDataAccess.Get();
            foreach (var p in people)
            {
                Console.WriteLine($"Id:{p.Id} - Name:{p.FirstName} {p.LastName}");
            }

            // delete all
            SQLiteDataAccess.DeteleAll();

            Console.WriteLine("Ended...");
            Console.ReadKey();
        }
    }
}
