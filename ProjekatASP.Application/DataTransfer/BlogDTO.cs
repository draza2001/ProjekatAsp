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
        public List<int> CategoryIds { get; set; }
        public List<string> Images { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
        public ICollection<PicturesDTO> PictureDtos { get; set; }

    }
}
