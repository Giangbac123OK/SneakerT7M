using AppData.Dto;
using AppData.IService;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoadonController : ControllerBase
    {
        private readonly IHoadonService _service;

        public HoadonController(IHoadonService service)
        {
            _service = service;
        }

        // API để lấy tất cả hoá đơn
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hoadonList = await _service.GetAllAsync();
            return Ok(hoadonList);
        }

        // API để lấy hoá đơn theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hoadon = await _service.GetByIdAsync(id);
            if (hoadon == null) return NotFound(new { message = "Hoá đơn không tìm thấy" });
            return Ok(hoadon);
        }

        // API để thêm hoá đơn
        [HttpPost]
        public async Task<IActionResult> Add(HoaDonDTO dto)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về lỗi nếu DTO không hợp lệ
            }

            try
            {
                await _service.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.Idkh }, dto);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi thêm hoá đơn
                return StatusCode(500, new { message = "Lỗi khi thêm hoá đơn", error = ex.Message });
            }
        }

        // API để cập nhật hoá đơn
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HoaDonDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về lỗi nếu DTO không hợp lệ
            }

            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Hoá đơn không tìm thấy" });
            }

            try
            {
                await _service.UpdateAsync(dto, id);
                return NoContent(); // Trả về status code 204 nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi cập nhật hoá đơn
                return StatusCode(500, new { message = "Lỗi khi cập nhật hoá đơn", error = ex.Message });
            }
        }

        // API để xóa hoá đơn
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Hoá đơn không tìm thấy" });
            }

            try
            {
                await _service.DeleteAsync(id);
                return NoContent(); // Trả về status code 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi xóa hoá đơn
                return StatusCode(500, new { message = "Lỗi khi xóa hoá đơn", error = ex.Message });
            }
        }
    }
}
