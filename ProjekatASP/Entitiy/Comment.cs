using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public int? UserId { get; set; }
        public int? BlogId { get; set; }
        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
