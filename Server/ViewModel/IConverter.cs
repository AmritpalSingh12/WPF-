
using Server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DTOs
{
    public interface IConverter<D, E> where D : DTO where E : IEntity
    {
        E ConvertFromDTO(D dto);
        D ConvertToDTO(E entity);
    }
}
