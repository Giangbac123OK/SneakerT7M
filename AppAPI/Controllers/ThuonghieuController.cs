using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ThuonghieuController : Controller
	{
		private readonly IthuonghieuService _service;

		public ThuonghieuController(IthuonghieuService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var brands = await _service.GetAllAsync();
			return Ok(brands); // Trả về danh sách thương hiệu bao gồm Id và tình trạng
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var brand = await _service.GetByIdAsync(id);
			return Ok(brand);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] ThuonghieuDTO thuonghieuDto)
		{
			await _service.AddAsync(thuonghieuDto);
			return CreatedAtAction(nameof(GetById), new { id = thuonghieuDto.Tenthuonghieu }, thuonghieuDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] ThuonghieuDTO thuonghieuDto)
		{
			await _service.UpdateAsync(id, thuonghieuDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search(string name)
		{
			var result = await _service.SearchByNameAsync(name);
			return Ok(result);
		}
	}
}
