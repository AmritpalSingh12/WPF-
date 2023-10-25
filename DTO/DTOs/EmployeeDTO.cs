using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class EmployeeDTO : DTO
    {
        public string EmpName;
        private object employees;

        public EmployeeDTO(string empName)
        {
            this.EmpName = empName;
        }

    }
}
