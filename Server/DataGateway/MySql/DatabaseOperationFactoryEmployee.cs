using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class DatabaseOperationFactoryEmployee
    {
        public const int SELECT_ALL = 1;

        public DatabaseInserter<Employee>CreateInserter()
        {
            return new InsertEmployee();
        }

        public ISelector<Employee> CreateSelector( int typeOfSelection, string i )
        {
            switch (typeOfSelection)
            {
                case SELECT_ALL:
                    return new FindEmployee(i);
                default:
                    return new NullSelector<Employee>();
            }
        }

    }
}
