using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public abstract class DatabaseUpdater<T> : DatabaseOperator, IUpdater<T>
    {
        public int Update(T itemToUpdate)
    {
        int numRowsUpdated = 0;

        MySqlConnection conn = GetConnection();

        MySqlCommand command = GetCommand(conn);

        try
        {
            numRowsUpdated = DoUpdate(command, itemToUpdate);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }

        ReleaseConnection(conn);
        return numRowsUpdated;
    }

    protected abstract int DoUpdate(MySqlCommand command, T itemToUpdate);
    protected override abstract string GetSQL();
}
}
