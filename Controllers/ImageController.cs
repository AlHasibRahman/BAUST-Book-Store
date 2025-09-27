using AutoMapper;
using BAUST_Book_Store.Models.Domain;
using BAUST_Book_Store.Models.Dtos;
using BAUST_Book_Store.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAUST_Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;
        public ImageController(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] UploadImageRequestDto newImage)
        {
            validateFile(newImage);
            if (ModelState.IsValid is false)
            {
                return BadRequest(ModelState);
            }
            if (newImage.File == null || newImage.File.Length == 0)
                return BadRequest("No file uploaded");

            var image = await imageRepository.UploadImageAsync(newImage.File);

            return Ok(image);
        }


        private void validateFile(UploadImageRequestDto newImage)
        {
            var extensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (extensions.Contains(Path.GetExtension(newImage.File.FileName).ToLowerInvariant()) is false)
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }

            // if (newImage.File.Length > 10485760)
            // {
            //     ModelState.AddModelError("File", "File size is more than 10mb");
            // }
        }
    }
}
