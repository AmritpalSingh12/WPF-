using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class InitialisationGateway 

    {

        private MySqlCommand createEmployeeTable = new MySqlCommand
        {
            CommandText = "create table Employee(EmployeeName varchar(20) not null)",
            CommandType = CommandType.Text
        };

        private MySqlCommand createItemTable = new MySqlCommand
        {
            CommandText = "create table Item(ID int primary key, Name varchar(20) not null, Quantity int not null, DateCreated datetime not null)",
            CommandType = CommandType.Text
        };

        private MySqlCommand createTransactionLogEntryTable = new MySqlCommand
        {
            CommandText = "create table TransactionLogEntry(TypeOfTransaction varchar(50) not null, ItemID int not null, ItemName varchar(25) not null,ItemPrice double not null, Quantity int not null, EmployeeName varchar(25) not null, DateCreated datetime not null)",
            CommandType = CommandType.Text
        };

        private MySqlCommand dropEmployeeTable = new MySqlCommand
        {
            CommandText = "DROP TABLE Employee",
            CommandType = CommandType.Text
        };
        private MySqlCommand dropItemTable = new MySqlCommand
        {
            CommandText = "DROP TABLE Item",
            CommandType = CommandType.Text
        };
        private MySqlCommand dropTransactionLogEntryTable = new MySqlCommand
        {
            CommandText = "DROP TABLE TransactionLogEntry",
            CommandType = CommandType.Text
        };




        private List<MySqlCommand> commandSequence;
        public InitialisationGateway()
        {
            commandSequence = new List<MySqlCommand>()
            {
                     dropEmployeeTable,
              
                dropItemTable,
                dropTransactionLogEntryTable,

              createEmployeeTable,
              createItemTable,
              createTransactionLogEntryTable,



            };
        }

        public void InitialiseMySqlDatabase()
        {
            DatabaseConnectionPool connectionPool = DatabaseConnectionPool.GetInstance();
            MySqlConnection conn = connectionPool.AcquireConnection();

            foreach (MySqlCommand c in commandSequence)
            {
                try
                {
                    c.Connection = conn;
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: SQL command failed\n" + e.StackTrace, e);
                }
            }

            connectionPool.ReleaseConnection(conn);
        }
    }
}

