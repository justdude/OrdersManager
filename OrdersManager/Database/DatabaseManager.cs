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

        public const string ConnectionString = @"Data Source=Orders.db3;Version=3;";


        public DatabaseManager()
        {
            Connect();
        }

        private void Connect()
        {
            if (!System.IO.File.Exists("Orders.db3"))
                SQLiteConnection.CreateFile("Orders.db3");

            this.Connection = new SQLiteConnection(ConnectionString);
            Connection.Open();
        }


        public void Close()
        {
            this.Connection.Close();
        }


    }
}
