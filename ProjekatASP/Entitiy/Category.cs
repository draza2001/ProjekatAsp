using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<BlogCategory> BlogsCategory { get; set; } = new HashSet<BlogCategory>();
    }
}
