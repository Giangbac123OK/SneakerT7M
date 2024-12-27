using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThuonghieuController : ControllerBase
    {
		private readonly KhachHang_IThuongHieuService _service;

		public ThuonghieuController(KhachHang_IThuongHieuService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ThuonghieuDTO>>> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("_KhachHang/{id}")]
		public async Task<ActionResult<ThuonghieuDTO>> GetById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ThuonghieuDTO>> Create(ThuonghieuDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Tenthuonghieu }, result);
		}

		[HttpPut("_KhachHang/{id}")]
		public async Task<ActionResult<ThuonghieuDTO>> Update(int id, ThuonghieuDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _service.UpdateAsync(id, dto);
			if (result == null) return NotFound();

			return Ok(result);
		}

		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteAsync(id);
			if (!result) return NotFound();

			return NoContent();
		}
	}
}
