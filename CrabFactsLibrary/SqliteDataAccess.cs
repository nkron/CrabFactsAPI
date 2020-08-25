using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CrabFactsLibrary.Models;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace CrabFactsLibrary
{
    public class SqliteDataAccess: ISqliteDataAccess
    {
        public SqliteDataAccess()
        {

        }
        public List<Fact> LoadFacts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var facts = cnn.Query<Fact>("select * from Fact", new DynamicParameters());
                return facts.ToList();
            }
        }

        public void AddFact(Fact fact)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Fact (Description) values (@Description)", fact);
            }
        }

        private string LoadConnectionString(string id = "APIDB")
        {
            var a = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
