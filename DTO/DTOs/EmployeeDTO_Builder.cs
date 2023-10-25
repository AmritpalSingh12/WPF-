using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class EmployeeDTO_Builder
    {
        public string EmpName;

       

        public EmployeeDTO Build()
        {
            return new EmployeeDTO(EmpName);
        }

        public EmployeeDTO_Builder WithEmployee(string EmpName)
        {
            this.EmpName = EmpName;
            return this;
        }


    }
}
