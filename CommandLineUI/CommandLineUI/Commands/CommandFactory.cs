using Assignment.CommandLineUI.Menu;
using Assignment.UI_commands;
using Assignment.UseCases;
using CommandLineUI.CommandLineUI.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.CommandLineUI.Commands
{
    class CommandFactory
    {

       public CommandFactory()
        {

        }

        public Command CreateCommand(int commandCode)
        {
            switch (commandCode)
            {
                case RequestUseCase.ADD_ITEM_TO_STOCK:
                    return new AddItemToStockCommand();

                case RequestUseCase.ADD_QUANTITY_TO_ITEM:
                    return new AddQuantityToItem();

                case RequestUseCase.TAKE_QUANTITY_FROM_ITEM:
                    return new TakeQuantityFromItemCommand();

                case RequestUseCase.VIEW_INVENTORY_REPORT:
                    return new ViewInventoryReportCommand();

                case RequestUseCase.VIEW_FINANCIAL_REPORT:
                    return new ViewFinancialReportCommand();

                case RequestUseCase.VIEW_TRANSACTION_LOG:
                    return new ViewTransactionLogCommand();

                case RequestUseCase.VIEW_PERSONAL_USAGE_REPORT:
                    return new ViewPersonalUsageReportCommand_cs();
                case RequestUseCase.INITIALISE_DATABASE:
                    return new InitialiseDatabaseCommand();

                default:
                    return new NullCommand();
            }
        }

    }
}