using FITClothing.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadsController : ControllerBase
{
    private readonly CloudinaryService _cloudinary;

    public UploadsController(
        CloudinaryService cloudinary)
    {
        _cloudinary = cloudinary;
    }

    [HttpPost]
    public async Task<IActionResult> Upload(
        IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var url =
            await _cloudinary.UploadImageAsync(
                file,
                "fitclothing/user-artwork");

        return Ok(new { Url = url });
    }
}