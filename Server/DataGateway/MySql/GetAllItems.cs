using Server.DTOs;
using Server.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace Server.DataGateway.MySql
{
    public class GetAllItems : DatabaseSelector<Dictionary<int, ItemDTO>>
    {

        public GetAllItems()
        {

        }

        protected override string GetSQL()
        {
            return
                "select ID, Name, Quantity, DateCreated from item";
        }

        protected override Dictionary<int, ItemDTO> DoSelect(MySqlCommand command)
        {
            Dictionary<int, ItemDTO> items = new Dictionary<int, ItemDTO>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    ItemDTO item = new ItemDTO(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDateTime(3));
                    items.Add(item.ID, item);

                }
                dr.Close();
            }

            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of items failed", e);
            }
            return items;
        }
    }
}


       

            
