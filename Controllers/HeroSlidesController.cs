using FITClothing.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FITClothing.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroSlidesController : ControllerBase
{
	private readonly ApplicationDbContext _context;

	public HeroSlidesController(
		ApplicationDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var slides = await _context.HeroSlides
			.Where(x => x.IsActive)
			.OrderBy(x => x.DisplayOrder)
			.ToListAsync();

		return Ok(slides);
	}
}