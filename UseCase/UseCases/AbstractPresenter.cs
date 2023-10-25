using System;
using System.Collections.Generic;
using System.Text;
using Assignment.DTOs;


namespace Assignment.UseCases
{
    public abstract class AbstractPresenter
    {
        public DTO DataToPresent { get; set; }

        public abstract ViewData ViewData { get; }


    }
}
