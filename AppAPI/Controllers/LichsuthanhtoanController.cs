using AppData.Dto;
using AppData.IService;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LichsuthanhtoanController : ControllerBase
    {
        private readonly ILichsuthanhtoanService _service;

        public LichsuthanhtoanController(ILichsuthanhtoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hoadonList = await _service.GetAllAsync();
            return Ok(hoadonList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hoadon = await _service.GetByIdAsync(id);
            if (hoadon == null) return NotFound(new { message = "Hoá đơn không tìm thấy" });
            return Ok(hoadon);
        }

        [HttpGet("list/{id}")]
        public async Task<IActionResult> GetByIdHDAsync(int id)
        {
            try
            {
                var licsuthanhtoanDto = await _service.GetByIdHDAsync(id);

                if (licsuthanhtoanDto == null || !licsuthanhtoanDto.Any())
                {
                    return NotFound(new { Message = "Không tìm thấy hoá đơn trong lịch sử thanh toán với ID: " + id });
                }

                return Ok(licsuthanhtoanDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(lichsuthanhtoanDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = dto.idHd }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm lịch sử thanh toán", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, lichsuthanhtoanDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Lịch sử thanh toán không tìm thấy" });
            }

            try
            {
                await _service.UpdateAsync(dto, id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật lịch sử thanh toán", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Lịch sử thanh toán không tìm thấy" });
            }

            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa lịch sử thanh toán", error = ex.Message });
            }
        }
    }
}
