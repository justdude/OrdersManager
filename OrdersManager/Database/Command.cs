using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrdersManager.Model;
using System.Data.SQLite;
using System.Data.SQLite.Linq;

namespace OrdersManager.Database
{
    public class Command
    {

        private SQLiteConnection Connection
        { get; set; }

        private SQLiteCommand Comm
        { get; set; }

        public Command(SQLiteConnection connection)
        {
            this.Connection = connection;
            Command = new SQLiteCommand(connection);
        }

        public Command(SQLiteConnection connection, string commangText)
        {
            this.Connection = connection;
            Command = new SQLiteCommand(commangText, connection);
        }

        public SQLiteCommand GetCommand()
        {
            return Comm;
        }

        public void CreateTableCostumer()
        {
            Comm.CommandText = "";
        }

    }
}
