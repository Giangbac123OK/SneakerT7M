using AppData.Dto;
using AppData.IService;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HinhanhController : ControllerBase
    {
        private readonly IHinhanhService _service;

        public HinhanhController(IHinhanhService service)
        {
            _service = service;
        }

        // API để lấy tất cả Hình ảnh trả hàng
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hoadonList = await _service.GetAllAsync();
            return Ok(hoadonList);
        }

        // API để lấy Hình ảnh trả hàng theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hoadon = await _service.GetByIdAsync(id);
            if (hoadon == null) return NotFound(new { message = "Hình ảnh trả hàng không tìm thấy" });
            return Ok(hoadon);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HinhanhDTO dto)
        {
            // Kiểm tra tính hợp lệ của dữ liệu
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về lỗi nếu DTO không hợp lệ
            }
            try
            {
                // Thêm hình ảnh (hoặc Hình ảnh trả hàng tùy theo context)
                 await _service.AddAsync(dto);

                // Trả về ID của hình ảnh vừa được thêm
                return CreatedAtAction(nameof(GetById), new { id = dto.id }, dto);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi thêm hình ảnh
                return StatusCode(500, new { message = "Lỗi khi thêm hình ảnh", error = ex.Message });
            }
        }


        // API để cập nhật Hình ảnh trả hàng
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HinhanhDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Trả về lỗi nếu DTO không hợp lệ
            }

            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Hình ảnh trả hàng không tìm thấy" });
            }

            try
            {
                await _service.UpdateAsync(dto, id);
                return NoContent(); // Trả về status code 204 nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi cập nhật Hình ảnh trả hàng
                return StatusCode(500, new { message = "Lỗi khi cập nhật Hình ảnh trả hàng", error = ex.Message });
            }
        }

        // API để xóa Hình ảnh trả hàng
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingHoadon = await _service.GetByIdAsync(id);
            if (existingHoadon == null)
            {
                return NotFound(new { message = "Hình ảnh trả hàng không tìm thấy" });
            }

            try
            {
                await _service.DeleteAsync(id);
                return NoContent(); // Trả về status code 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có khi xóa Hình ảnh trả hàng
                return StatusCode(500, new { message = "Lỗi khi xóa Hình ảnh trả hàng", error = ex.Message });
            }
        }
    }
}

