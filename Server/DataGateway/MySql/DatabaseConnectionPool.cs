

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace Server.DataGateway.MySql
{
    public class DatabaseConnectionPool
    {
        private static string DATABASE_USERNAME = "root";
        private static string DATABASE_PASSWORD = "Parmjit123.";

        private static DatabaseConnectionPool instance = new DatabaseConnectionPool(1);

        private List<MySqlConnection> availableConnections;
        private List<MySqlConnection> busyConnections;

        public static DatabaseConnectionPool GetInstance()
        {
            return instance;
        }

        private DatabaseConnectionPool(int sizeOfPool)
        {
            availableConnections = new List<MySqlConnection>(sizeOfPool);
            busyConnections = new List<MySqlConnection>(sizeOfPool);

            if (DATABASE_USERNAME == null || DATABASE_USERNAME.Equals(""))
            {
                LoadDatabaseCredentialsFromFile();
            }

            for (int i = 0; i < sizeOfPool; i++)
            {
                availableConnections.Add(CreateMySqlConnection());
            }
        }

        ~DatabaseConnectionPool()
        {
            foreach (MySqlConnection conn in availableConnections)
            {
                CloseMySqlConnection(conn);
            }
            availableConnections.Clear();

            foreach (MySqlConnection conn in busyConnections)
            {
                CloseMySqlConnection(conn);
            }
            busyConnections.Clear();
        }

        public MySqlConnection AcquireConnection()
        {
            if (availableConnections.Count > 0)
            {
                MySqlConnection conn = availableConnections[0];
                availableConnections.RemoveAt(0);
                busyConnections.Add(conn);
                return conn;
            }

            return null;
        }

        private void CloseMySqlConnection(MySqlConnection conn)
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: closure of database connection failed", e);
                }
            }
        }

        private MySqlConnection CreateMySqlConnection()
        {
            string DB_CONNECTION_STRING
                = "Data Source=localhost;port=3306;Initial Catalog=Assignment;User Id=" + DATABASE_USERNAME + ";password=" + DATABASE_PASSWORD;

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(DB_CONNECTION_STRING);
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: connection to database failed", e);
            }

            return conn;
        }

        private void LoadDatabaseCredentialsFromFile()
        {
            Console.Write("Oracle database username: > ");
            DATABASE_USERNAME = Console.ReadLine();
            Console.Write("Oracle database_ password: > ");
            DATABASE_PASSWORD = Console.ReadLine();

            //FileInfo dbCredsFile = new FileInfo("db_creds.txt");
            //FileStream dbCredsStream = dbCredsFile.OpenRead();
            //StreamReader dbCredsReader = new StreamReader(dbCredsStream);

            //dbCredsReader.ReadLine(); //disregard comment line

            //string[] parts = dbCredsReader.ReadLine().Split(':'); //read credentials line
            //DATABASE_USERNAME = parts[0];
            //DATABASE_PASSWORD = parts[1];

            //dbCredsReader.Close();
        }

        public void ReleaseConnection(MySqlConnection conn)
        {
            if (busyConnections.Contains(conn))
            {
                busyConnections.Remove(conn);
                availableConnections.Add(conn);
            }
        }
    }
}
