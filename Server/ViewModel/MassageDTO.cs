using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
{ 
    public class MassageDTO : DTO
    {
        public string Message { get; }

        public MassageDTO(string msg)
        {
            this.Message = msg;
        }
    }
}
