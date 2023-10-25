using Server.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataGateway.MySql
{
    public class InsertEmployee : DatabaseInserter<Employee>
    {

        protected override string GetSQL()
        {
            return
                "insert into Employee ( EmployeeName) values (@employee)";
        }

        protected override int DoInsert(MySqlCommand command, Employee employeeToInsert)
        {
            command.Parameters.AddWithValue("@employee", employeeToInsert.EmpName);


            int NumberofRowAffected = command.ExecuteNonQuery();

            if (NumberofRowAffected != 1)
            {
                throw new Exception("Error Employee Name not inserted");
            }
            return NumberofRowAffected;
        }
            
            
    }
}
    
