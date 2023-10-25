using Assignment.DTOs;
using Assignment.Library;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class InsertItem : DatabaseInserter<Item>

    {
        protected override string GetSQL()
        {
            return "insert into Item  (ID, Name, Quantity, DateCreated) values (@id, @name, @quantity, @datecreated)";
        }

        protected override int DoInsert(MySqlCommand command, Item itemToInsert)
        {
            command.Parameters.AddWithValue("@id", itemToInsert.ID);
            command.Parameters.AddWithValue("@name", itemToInsert.Name);
            command.Parameters.AddWithValue("@quantity", itemToInsert.Quantity);
            command.Parameters.AddWithValue("@datecreated", itemToInsert.DateCreated);
            int NumberOfRowsAffected = command.ExecuteNonQuery();
            if (NumberOfRowsAffected != 1)
            {
                throw new Exception("ERROR: Item not inserted");
            }
    
            return NumberOfRowsAffected;
        }
    }
}
