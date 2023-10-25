using Assignment.DataGateway.MySql;
using Assignment.DTOs;
using Assignment.Library;
using Assignment.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCases;

namespace Controller.Controller
{
    public class PersonalController : AbstractController
    {
        private string employeeName;

        public PersonalController(string employeeName,
            AbstractPresenter presenter) :base(new DataGatewayFacade(), presenter)
        {
            this.employeeName = employeeName;
        }

        public override DTO ExecuteUseCase()
        {
            return new PersonalReport( employeeName, gatewayFacade).Execute();
        }

        public override List<TransactionLogEntry> ExecuteUseCaseFinancial()
        {
            throw new NotImplementedException();
        }

        public override Dictionary<int, ItemDTO> ExecuteUseCaseGrid()
        {
            throw new NotImplementedException();
        }

        public override List<TransactionLogEntry> ExecutePersonalUsage()
        {
            return new PersonalReport(employeeName, gatewayFacade).ExecutePersonal();
        }

        public override List<TransactionLogEntry> TransactionLogs()
        {
            throw new NotImplementedException();
        }
    }
}
