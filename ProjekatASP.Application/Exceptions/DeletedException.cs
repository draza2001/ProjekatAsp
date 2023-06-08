using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Exceptions
{
    public class DeletedException : Exception
    {
        public DeletedException(int id, Type type) : base($"Entity with id {id} and type {type.Name} is already deleted")
        {
        }
    }
}
