using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class BlogCategory:Entity
    {
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual Category Category { get; set; }
    }
}
