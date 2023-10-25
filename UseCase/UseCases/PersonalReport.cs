using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public class PersonalReport : AbstractUseCase
    {
        private readonly string employeeName;

        public PersonalReport(string employeeName, IDataGatewayFacade gatewayFacade) : base(gatewayFacade)

        {
            this.employeeName = employeeName;
        }


        public override DTO Execute()
        {

            EmployeeConverter employeeConverter = new EmployeeConverter();
            EmployeeDTO employeeDTO = employeeConverter.ConvertToDTO(gatewayFacade.FindEmployee(this.employeeName));

            Console.WriteLine("\nPersonal Usage Report for {0}", employeeDTO.EmpName);
            Console.WriteLine(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed");

            foreach (TransactionLogEntry entry in gatewayFacade.GetTransactionLog())
            {
                if (entry.TypeOfTransaction.Equals("Quantity Removed") && entry.EmployeeName == employeeName)
                {
                    Console.WriteLine(
                        "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                        entry.DateAdded,
                        entry.ItemID,
                        entry.ItemName,
                        entry.Quantity);

                   
                }

               
            }
            return new MassageDTO("This is Personal Usage Report");

        }


        public List<TransactionLogEntry> ExecutePersonal()
        {
            EmployeeConverter employeeConverter = new EmployeeConverter();
            EmployeeDTO employeeDTO = employeeConverter.ConvertToDTO(gatewayFacade.FindEmployee(this.employeeName));

            Console.WriteLine("\nPersonal Usage Report for {0}", employeeDTO.EmpName);
            Console.WriteLine(
                "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                "Date Taken",
                "ID",
                "Name",
                "Quantity Removed");
            List<TransactionLogEntry> logs = new List<TransactionLogEntry>();

            foreach (TransactionLogEntry entry in gatewayFacade.GetTransactionLog())
            {
                

                if (entry.TypeOfTransaction.Equals("Quantity Removed") && entry.EmployeeName == employeeName)
                {
                    logs.Add(entry);

                    //Console.WriteLine(
                    //    "\t{0, -20} {1, -10} {2, -12} {3, -12}",
                        //entry.DateAdded,
                        //entry.ItemID,
                        //entry.ItemName,
                        //entry.Quantity);


                }
            }
            return logs;
        }


        public override Dictionary<int, ItemDTO> ExecuteGrid()
        {
            throw new NotImplementedException();
        }
    }
}


