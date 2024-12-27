using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ThuoctinhController : ControllerBase
    {
		private readonly KhachHang_IThuoctinhService _KhachHang_service;

		public ThuoctinhController(KhachHang_IThuoctinhService service)
		{
			_KhachHang_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ThuoctinhDTO>>> GetAll()
		{
			var result = await _KhachHang_service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("_KhachHang/{id}")]
		public async Task<ActionResult<ThuoctinhDTO>> GetById(int id)
		{
			var result = await _KhachHang_service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<ThuoctinhDTO>> Create(ThuoctinhDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _KhachHang_service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Tenthuoctinh }, result);
		}

		[HttpPut("_KhachHang/{id}")]
		public async Task<ActionResult<ThuoctinhDTO>> Update(int id, ThuoctinhDTO dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _KhachHang_service.UpdateAsync(id, dto);
			if (result == null) return NotFound();

			return Ok(result);
		}

		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _KhachHang_service.DeleteAsync(id);
			if (!result) return NotFound();

			return NoContent();
		}
		[HttpGet("_KhachHang/GetThuocTinh/thuocTinhChiTiet")]
		public async Task<IActionResult> GetThuocTinhsChiTiet()
		{
			var resurl = await _KhachHang_service.GetThuocTinhsChiTiet();
			return Ok(resurl);
		}

	}
}
