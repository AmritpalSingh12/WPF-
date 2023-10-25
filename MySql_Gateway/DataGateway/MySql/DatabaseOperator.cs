using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public abstract class DatabaseOperator
    {
        protected MySqlConnection GetConnection()
        {
            return DatabaseConnectionPool.GetInstance().AcquireConnection();
        }

        protected MySqlCommand GetCommand(MySqlConnection conn)
        {
            return new MySqlCommand
            {
                Connection = conn,
                CommandText = GetSQL(),
                CommandType = CommandType.Text
            };
        }

        protected abstract string GetSQL();

        protected void ReleaseConnection(MySqlConnection conn)
        {
            DatabaseConnectionPool.GetInstance().ReleaseConnection(conn);
        }
    }
}
