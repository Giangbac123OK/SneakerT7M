using AppData.Dto;
using AppData.IService;
using AppData.Models;
using AppData.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SanphamchitietController : Controller
	{
		private readonly ISanphamchitietService _service;

		public SanphamchitietController(ISanphamchitietService service)
		{
			_service = service;
		}

		// API để lấy tất cả sản phẩm chi tiết
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var sanphamchitiets = await _service.GetAllAsync();
			return Ok(sanphamchitiets);
		}

		// API để lấy sản phẩm chi tiết theo Id
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var sanphamchitiet = await _service.GetByIdAsync(id);
			if (sanphamchitiet == null) return NotFound();
			return Ok(sanphamchitiet);
		}

		// API để thêm sản phẩm chi tiết
		[HttpPost]
		public async Task<IActionResult> Add(SanphamchitietDto dto)
		{
			await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = dto.Mota }, dto);
		}

		// API để cập nhật sản phẩm chi tiết
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, SanphamchitietDto dto)
		{
			await _service.UpdateAsync(dto, id);
			return NoContent();
		}

		// API để xóa sản phẩm chi tiết
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}

}
