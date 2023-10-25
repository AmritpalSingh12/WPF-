using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public abstract class DatabaseSelector<T> : DatabaseOperator, ISelector<T>
    {


        public T Select()
        {
            T item;

            MySqlConnection conn = GetConnection();

            MySqlCommand command = GetCommand(conn);

            try
            {
                item = DoSelect(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            ReleaseConnection(conn);
            return item;
        }

        protected abstract T DoSelect(MySqlCommand command);
        protected override abstract string GetSQL();
    }
}
