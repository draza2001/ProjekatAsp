using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, Type type)
            : base($"Entity {type.Name} with id of {id} was not found.")
        {
        }
    }
}
