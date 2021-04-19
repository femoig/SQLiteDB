using ClassLibrary.Models;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ClassLibrary.DataAccess
{
    public class SQLiteDataAccess
    {
        public static List<Person> Get()
        {
            using (IDbConnection c = new SQLiteConnection(LoadConnectionString()))
            {
                var output = c.Query<Person>("select * from Person");
                return output.ToList();
            }
        }    

        public static void Save(Person p)
        {
            using (IDbConnection c = new SQLiteConnection(LoadConnectionString()))
            {
                var output = c.Query<Person>("insert into Person (FirstName, LastName) values (@FirstName, @LastName)", p);                
            }
        }

        public static void DeteleAll()
        {
            using (IDbConnection c = new SQLiteConnection(LoadConnectionString()))
            {
                var output = c.Query<Person>("delete from Person");
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }    
}
