using AudioGuide.Model.Dtos;
using AudioGuide.Service;
using Microsoft.AspNetCore.Mvc;

namespace AudioGuide.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LanguagesController : ControllerBase
{
	private readonly ILanguageService _service;

	public LanguagesController(ILanguageService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<ActionResult<List<LanguageDto>>> GetAll()
	{
		return Ok(await _service.GetActiveLanguagesAsync());
	}
}