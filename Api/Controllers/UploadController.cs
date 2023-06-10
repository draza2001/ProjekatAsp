using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly Context context;

        public UploadController(Context context)
        {
            this.context = context;
        }



        // POST api/<UploadController>
        [HttpPost("{blogId}")]
        public IActionResult Post([FromBody] PicturesDTO dto, int blogId)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }
            var picture = new Picture
            {
                BlogId = blogId,
                Src = newFileName
            };

            context.Pictures.Add(picture);
            context.SaveChanges();

            return NoContent();
        }


    }
}
