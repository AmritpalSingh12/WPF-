
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
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
