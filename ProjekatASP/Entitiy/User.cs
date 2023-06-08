using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserUseCase> UserUseCases { get; set; }
    }
}
