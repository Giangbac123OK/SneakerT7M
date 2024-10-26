using AppAPI.Dto;
using AppAPI.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PhuongthucthanhtoanController : ControllerBase
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
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<PhuongthucthanhtoanDTO>> Create(PhuongthucthanhtoanDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Tenpttt }, result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<PhuongthucthanhtoanDTO>> Update(int id, PhuongthucthanhtoanDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.UpdateAsync(id, dto);
			if (result == null) return NotFound();

			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteAsync(id);
			if (!result) return NotFound();

			return NoContent();
		}
	}
}
