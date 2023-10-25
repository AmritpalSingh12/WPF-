using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public abstract class DatabaseInserter<T> : DatabaseOperator, IInserter<T>
    {

      
        public int Insert(T itemToInsert)
        {
            int numRowsInserted = 0;

            MySqlConnection conn = GetConnection();

            MySqlCommand command = GetCommand(conn);

            try
            {
                numRowsInserted = DoInsert(command, itemToInsert);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            ReleaseConnection(conn);
            return numRowsInserted;
        }

       

        protected abstract int DoInsert(MySqlCommand command, T itemToInsert);
        protected override abstract string GetSQL();
    }
}
