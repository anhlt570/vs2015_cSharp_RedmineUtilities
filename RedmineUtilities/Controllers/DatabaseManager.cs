using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedmineUtilities.Controllers
{
    class DatabaseManager
    {
        private static DatabaseManager instance = null;
        public static DatabaseManager getInstance()
        {
            if (instance == null) instance = new DatabaseManager();
            return instance;
        }

        SQLiteConnection dbConnection;

        DatabaseManager()
        {
            if (!File.Exists("MyDatabase.sqlite"))
            {
                SQLiteConnection.CreateFile("MyDatabase.sqlite");
            }
            dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            dbConnection.Open();
        }

        void initDatabase()
        {
        }

    }
}
