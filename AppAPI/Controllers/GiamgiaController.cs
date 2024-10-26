using AppAPI.Dto;
using AppAPI.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GiamgiaController : ControllerBase
    {
		private readonly IGiamgiaService _service;
        public GiamgiaController(IGiamgiaService service)
        {
			_service = service;

		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var result = await _service.GetByIdAsync(id);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create(GiamgiaDTO dto)
		{
			var result = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = result.Mota }, result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, GiamgiaDTO dto)
		{
			var result = await _service.UpdateAsync(id, dto);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
