using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DTOs
{
    public class EmployeeDTO_List : DTO
    {

        public List<EmployeeDTO> List { get; }

        public EmployeeDTO_List(List<EmployeeDTO> list)
        {
            List = list;
        }
    }
}
