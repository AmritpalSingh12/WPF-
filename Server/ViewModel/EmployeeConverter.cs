
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
{
    public class EmployeeConverter : IConverter<EmployeeDTO, Employee>
    {
        public Employee ConvertFromDTO(EmployeeDTO employeeDTO)
        {
            return
                new EmployeeBuilder()
                    .WithEmployee(employeeDTO.EmpName)
                    .Build();

        }

        public EmployeeDTO ConvertToDTO(Employee employee)

        {
            return new EmployeeDTO_Builder()
                .WithEmployee(employee.EmpName)
                .Build();




        }

    }
}
