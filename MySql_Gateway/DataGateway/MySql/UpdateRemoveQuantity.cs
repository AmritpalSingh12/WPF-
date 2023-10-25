using Assignment.DTOs;
using Assignment.Library;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class UpdateRemoveQuantity : DatabaseUpdater<Item>
    {
        protected override string GetSQL()
        {
            return "update item set Quantity = @quantity where ID= @id";
        }

        protected override int DoUpdate(MySqlCommand command, Item itemToUpdate)
        {
            int numRowsAffected = 0;

            try
            {
                // addQuantityToItem.Prepare();
                command.Parameters.AddWithValue("@quantity", itemToUpdate.Quantity);
                command.Parameters.AddWithValue("@id", itemToUpdate.ID);
                 numRowsAffected = command.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: item not ");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            return numRowsAffected;

        }
    }
}
