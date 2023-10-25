using Server.DTOs;
using Server.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class FindItembyID : DatabaseSelector<Item>
    { 
        private int id;

    
        public FindItembyID(int ID)
        {
            this.id = ID;
        }

        protected override string GetSQL()
        {
            return "select * from item where ID= @id";
        }

        protected override Item DoSelect(MySqlCommand command)
        {
            Item ItemId = null;

            try
            {
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    ItemId = new Item(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDateTime(3));

                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item ID failed", e);
            }
            return ItemId;
        }

    }
}
