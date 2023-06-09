using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Picture:Entity
    {
        public string Src { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
