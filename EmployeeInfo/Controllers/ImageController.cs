using EmployeeInfo.Repository;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImgRepo _imgRepo;

        public ImageController(IImgRepo imgRepo)
        {
            _imgRepo = imgRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("This is ImgController");
        }
        [HttpPost]
        public async Task<IActionResult> UploadImg(IFormFile file)
        {
            var imageUrl = await _imgRepo.Upload(file);
            if (imageUrl == null)
            {
                return Problem("Image upload failed", null, (int)HttpStatusCode.InternalServerError);
            }
            return new JsonResult(new { link = imageUrl });
        }
    }
}
