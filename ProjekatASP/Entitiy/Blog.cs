using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Domain
{
    public class Blog : Entity
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual ICollection<BlogCategory> BlogCategory { get; set; } = new HashSet<BlogCategory>();



        public int? UserId { get; set; }
        public virtual User User { get; set; }


    }
}
