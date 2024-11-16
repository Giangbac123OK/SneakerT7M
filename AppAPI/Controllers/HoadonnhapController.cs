using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class HoadonnhapController : Controller
	{
		private readonly IHoadonnhapService _service;
        public HoadonnhapController(IHoadonnhapService service)
        {
			_service = service;

		}
		[HttpPost]
		public IActionResult AddHoadonnhap([FromBody] HoadonnhapDTO hoadonnhapDTO, int idnv)
		{ 
			return Ok("OK");
		}
	}
}
