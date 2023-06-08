using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Exceptions
{
    public class DeleteYourselfException : Exception
    {
        public DeleteYourselfException(int id,Type type):base("You cant't delete yourself")
        {
        }
    }
}
