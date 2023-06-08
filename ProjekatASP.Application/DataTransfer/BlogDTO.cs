using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransfer
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int? PicturesId { get; set; }
        public virtual PicturesDTO Pictures { get; set; }
        public int? UserId { get; set; }
        public virtual UserDTO User { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public float ProsecnaOcena { get; set; }

    }
}
