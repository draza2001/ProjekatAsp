using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class UserUseCase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserUseCaseId { get; set; }
        public virtual User User { get; set; }
    }
}
