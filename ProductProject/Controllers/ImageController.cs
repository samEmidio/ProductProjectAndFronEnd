using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ProductProject.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment iWebHostEnvironment;
        public ImageController(IWebHostEnvironment iWebHostEnvironment)
        {
            this.iWebHostEnvironment = iWebHostEnvironment;
        }

        [HttpGet("{image}")]
        public async Task<IActionResult> getImage(string image)
        {
            string path = this.iWebHostEnvironment.WebRootPath + Path.DirectorySeparatorChar.ToString()
            +"Resources"+Path.DirectorySeparatorChar.ToString() + image;

            var img = System.IO.File.OpenRead(@path);
            return File(img, "image/"+image.Split('.').ToList().Last());
        }


    }
}