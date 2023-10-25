using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class EmployeeBuilder
    {
        public string EmpName;

        public EmployeeBuilder()
        {
            this.EmpName = null;
        }

        public Employee Build()
        {
            return new Employee(EmpName);
        }

        public EmployeeBuilder WithEmployee( string EmpName)
        {
            this.EmpName= EmpName;
            return this;
        }
    }
}
