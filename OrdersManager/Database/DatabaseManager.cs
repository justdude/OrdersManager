using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.SQLite.Linq;


namespace OrdersManager.Database
{
    public class DatabaseManager
    {
        private static DatabaseManager inst;
        public static DatabaseManager Instance
        {
            get 
            {
                if (inst == null)
                    inst = new DatabaseManager();
                return inst;
            }
        }
        public SQLiteConnection Connection
        {
            get;
            private set;
        }

        public const string ConnectionString = @"Data Source=DataBase.db;Version=3;";

        public DatabaseManager()
        {
            this.Connection = new SQLiteConnection();
        }

        public void Connect()
        {
            this.Connection = new SQLiteConnection(ConnectionString);
            Connection.Open();
        }

        public SQLiteCommand CreateCommand()
        {
            SQLiteCommand command = Connection.CreateCommand();
            return command;
        }

        public void Close()
        {
            this.Connection.Close();
        }


    }
}
