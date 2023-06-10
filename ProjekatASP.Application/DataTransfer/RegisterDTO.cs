using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransfer
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public HashSet<int> UseCaseId { get; set; } = new HashSet<int> {6,9,10,13,16,17,18,19,20};
    }
}
