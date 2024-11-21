using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamchitietController : Controller
    {
        private readonly ISanphamchitietService _service;
        public SanphamchitietController(ISanphamchitietService service)
        {
            _service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result.Select(gg => new
            {
                gg.Mota,
                gg.Giathoidiemhientai,
                gg.Soluong,
                gg.Idsp,
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var giamgia = await _service.GetByIdAsync(id);
                return Ok(new
                {
                    giamgia.Mota,
                    giamgia.Giathoidiemhientai,
                    giamgia.Soluong,
                    giamgia.Idsp,
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Không tìm thấy sản phẩm chi tiết.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SanphamchitietsDTO dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Mota }, dto);
        }
        [HttpPost("AddThuoctinhsanphamchitiet")]
        public async Task<IActionResult> AddThuoctinhsanphamchitiet([FromBody] ThuoctinhsanphamchitietDTO dto)
        {
            try
            {
                await _service.AddThuoctinhsanphamchitiet(dto);
                return Ok("Thêm thuộc tính sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SanphamchitietsDTO dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
