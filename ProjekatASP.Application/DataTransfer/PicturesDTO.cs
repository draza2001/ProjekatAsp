using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransfer
{
    public class PicturesDTO
    {
        public string Src { get; set; }
        public IFormFile Image { get; set; }
    }
}
