using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PhuongthucthanhtoanController : Controller
	{
		private readonly IphuongthucthanhtoanServicee _service;

		public PhuongthucthanhtoanController(IphuongthucthanhtoanServicee service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<PhuongthucthanhtoanDTO>>> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PhuongthucthanhtoanDTO>> GetById(int id)
		{
			var phuongthucthanhtoan = await _service.GetByIdAsync(id);
			if (phuongthucthanhtoan == null) return NotFound();

			return Ok(new
			{
				phuongthucthanhtoan.Tenpttt,
				Trangthai = phuongthucthanhtoan.Trangthai == 0 ? "Đang sử dụng" : "Không sử dụng"
			});
		}

		[HttpPost]
		public async Task<ActionResult> Create(PhuongthucthanhtoanDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			 await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = dto.Tenpttt }, dto);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, PhuongthucthanhtoanDTO dto)
		{
			

			await _service.UpdateAsync(id, dto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
