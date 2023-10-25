using System;
using System.Collections.Generic;
using System.Text;
using Server.DTOs;


namespace Server.UseCases
{
    public abstract class AbstractPresenter
    {
        public DTO DataToPresent { get; set; }

        public abstract ViewData ViewData { get; }


    }
}
