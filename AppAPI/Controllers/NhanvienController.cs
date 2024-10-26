using AppAPI.Dto;
using AppAPI.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly INhanvienService _ser;
        public NhanvienController(INhanvienService ser)
        {
            _ser = ser;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanvienDTO>>> GetAll()
        {
            var result = await _ser.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NhanvienDTO>> GetById(int id)
        {
            var result = await _ser.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<NhanvienDTO>> Create(NhanvienDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _ser.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Hoten}, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NhanvienDTO>> Update(int id, NhanvienDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _ser.UpdateAsync(id, dto);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _ser.DeleteAsync(id);
            return NoContent();
        }
    }
}
