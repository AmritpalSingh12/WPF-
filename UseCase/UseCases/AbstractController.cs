using Assignment.DTOs;
using Assignment.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.UseCases
{
    public abstract class AbstractController
    {
        protected readonly IDataGatewayFacade gatewayFacade;
        protected AbstractPresenter presenter;

        public AbstractController(IDataGatewayFacade database, AbstractPresenter presenter)
        {
            this.gatewayFacade = database;
            this.presenter = presenter;
        }

        public ViewData Execute()
        {
            presenter.DataToPresent = ExecuteUseCase();
            return presenter.ViewData;
        }

        public abstract DTO ExecuteUseCase();
        public abstract Dictionary<int, ItemDTO> ExecuteUseCaseGrid();
        public abstract List<TransactionLogEntry> ExecuteUseCaseFinancial();

        public abstract List<TransactionLogEntry> ExecutePersonalUsage();

        public abstract List<TransactionLogEntry> TransactionLogs();


        public List<ItemGridDTO> ExecuteGrid()
        {
            Dictionary<int, ItemDTO> dictionaryitems = ExecuteUseCaseGrid();
            // return items;
            List<ItemGridDTO> itemGridlist = new List<ItemGridDTO>();
            foreach (var item in dictionaryitems)
            {
                ItemGridDTO itemGrid = new ItemGridDTO();



                itemGrid.ItemId = item.Value.ID;
                itemGrid.ItemName = item.Value.Name;
                itemGrid.ItemQuantity = item.Value.Quantity;
                itemGrid.Addeddate = item.Value.DateCreated;

                itemGridlist.Add(itemGrid); 
            }
            return itemGridlist;
        }



    }
}
