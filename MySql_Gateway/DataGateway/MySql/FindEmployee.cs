using Assignment.Library;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway.MySql
{
    public class FindEmployee : DatabaseSelector<Employee>
    {

        private string Employee;

        public FindEmployee(string EmpName)
        {
            this.Employee = EmpName;
        }

        protected override string GetSQL()
        {
            return
                "select * from employee where EmployeeName= @employee";
        }
        protected override Employee DoSelect(MySqlCommand command)
        {
            Employee employee = null;

            try
            {
                command.Parameters.AddWithValue("@employee", this.Employee);
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    employee = new Employee(dr.GetString(0));

                }
                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of Employee Name failed", e); ;
            }

            return employee;
        }
    }
}
