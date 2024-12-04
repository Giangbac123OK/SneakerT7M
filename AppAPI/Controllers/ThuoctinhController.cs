using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThuoctinhController : ControllerBase
    {
		private readonly IThuoctinhService _service;

		public ThuoctinhController(IThuoctinhService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ThuoctinhDTO>>> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ThuoctinhDTO>> GetById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ThuoctinhDTO>> Create(ThuoctinhDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Tenthuoctinh }, result);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<ThuoctinhDTO>> Update(int id, ThuoctinhDTO dto)
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
		[HttpGet("GetThuocTinh/thuocTinhChiTiet")]
		public async Task<IActionResult> GetThuocTinhsChiTiet()
		{
			var resurl = await _service.GetThuocTinhsChiTiet();
			return Ok(resurl);
		}

	}
}
