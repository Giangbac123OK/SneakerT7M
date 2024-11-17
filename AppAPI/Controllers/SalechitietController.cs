using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SalechitietController : Controller
	{
		private readonly ISalechitietService _salechitietService;
        public SalechitietController(ISalechitietService salechitietService)
        {
			_salechitietService = salechitietService;

		}
		[HttpPost("AddSalechitiet")]
		public async Task<IActionResult> AddSalechitiet([FromBody] SalechitietDTO salechitietDto)
		{
			var message = await _salechitietService.AddSalechitietAsync(salechitietDto);
			return Ok(new { message });
		}
	}
}
