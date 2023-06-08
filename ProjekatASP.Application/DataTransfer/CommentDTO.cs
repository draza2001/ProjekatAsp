using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransfer
{
    public class CommentDTO
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }
        public string UserName { get; set; }
        public int ArticleId { get; set; }

    }
}
