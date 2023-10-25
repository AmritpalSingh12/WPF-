using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ass.Entities
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

