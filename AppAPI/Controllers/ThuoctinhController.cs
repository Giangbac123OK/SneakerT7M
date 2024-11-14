using AppData.Dto;
using AppData.IService;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ThuoctinhController : Controller
	{
		private readonly IThuoctinhService _service;

		public ThuoctinhController(IThuoctinhService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Thuoctinh>>> GetAll()
		{
			var thuoctinh = await _service.GetAll();
			return Ok(thuoctinh);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Thuoctinh>> GetById(int id)
		{
			var thuoctinh = await _service.GetById(id);
			if (thuoctinh == null)
				return NotFound();

			return Ok(thuoctinh);
		}

		[HttpPost]
		public async Task<ActionResult> Add([FromBody] ThuoctinhDto thuoctinhDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _service.Add(thuoctinhDto);
			return CreatedAtAction(nameof(GetById), new { id = thuoctinhDto.Tenthuoctinh }, thuoctinhDto);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] ThuoctinhDto thuoctinhDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _service.Update(id, thuoctinhDto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _service.Delete(id);
			return NoContent();
		}
	}
}
