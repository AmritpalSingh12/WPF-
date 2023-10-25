
using System.Collections.Generic;

namespace Server.Entities
{
    public class EmployeeManager
    {
        private Dictionary<string, Employee> employees;

        public EmployeeManager()
        {
            employees = new Dictionary<string, Employee>();
        }

        public void AddEmployee(Employee e)
        {
            employees.Add(e.EmpName, e);
            
        }

        public Employee FindEmployee(string EmpName)
        {
            try
            {
                return employees[EmpName];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}
