using AppAPI.Dto;
using AppAPI.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThuoctinhsanphamchitietController : ControllerBase
    {
		private readonly IThuoctinhsanphamchitietService _service;

		public ThuoctinhsanphamchitietController(IThuoctinhsanphamchitietService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ThuoctinhsanphamchitietDTO>>> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ThuoctinhsanphamchitietDTO>> GetById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ThuoctinhsanphamchitietDTO>> Create(ThuoctinhsanphamchitietDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Tenthuoctinhchitiet }, result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<ThuoctinhsanphamchitietDTO>> Update(int id, ThuoctinhsanphamchitietDTO dto)
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
