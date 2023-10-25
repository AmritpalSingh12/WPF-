using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ass.Entities
{
    public class Employee
    {
        public string EmpName { get; }

        public Employee(string empname)
        {
            this.EmpName = empname;
        }
    }
}
