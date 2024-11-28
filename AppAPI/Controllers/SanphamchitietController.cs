using AppData.Dto;
using AppData.IService;
using AppData.Service;
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
        // API để lấy tất cả sản phẩm chi tiết
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SanPhamCTList = await _service.GetAllAsync();
            return Ok(SanPhamCTList);
        }

        // API để lấy sản phẩm chi tiết theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var SanPhamCT = await _service.GetByIdAsync(id);
            if (SanPhamCT == null) return NotFound(new { message = "Sản phẩm chi tiết không tìm thấy" });
            return Ok(SanPhamCT);
        }

        [HttpGet("sanpham/{id}")]
        public async Task<IActionResult> GetByIdSPAsync(int id)
        {
            try
            {
                var thuoctinhDto = await _service.GetByIdSPAsync(id);

                if (thuoctinhDto == null || !thuoctinhDto.Any())
                {
                    return NotFound(new { Message = "Không tìm thấy sản phẩm trong sản phẩm chi tiết với ID: " + id });
                }

                return Ok(thuoctinhDto);
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

        [HttpGet("GetSanPhamChiTietByThuocTinh")]
        public async Task<IActionResult> GetSanPhamChiTietByThuocTinh([FromQuery] List<string> tenthuoctinh)
        {
            try
            {
                var sanPhamChiTiet = await _service.GetByISPCTAsync(tenthuoctinh);
                return Json(sanPhamChiTiet);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("thuoctinh/{id}")]
        public async Task<IActionResult> GetByIdTTSPCT(int id)
        {
            try
            {
                // Gọi service để lấy dữ liệu thuộc tính sản phẩm chi tiết
                var thuoctinhDto = await _service.GetByIdTTSPCTAsync(id);

                // Kiểm tra nếu danh sách trả về là null hoặc rỗng
                if (thuoctinhDto == null || !thuoctinhDto.Any())
                {
                    return NotFound(new { Message = "Không tìm thấy thuộc tính sản phẩm chi tiết với ID: " + id });
                }

                // Trả về kết quả thành công với mã 200 OK
                return Ok(thuoctinhDto);
            }
            catch (KeyNotFoundException ex)
            {
                // Trường hợp không tìm thấy, trả về lỗi 404 với thông báo
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Trường hợp có lỗi không xác định, trả về lỗi 500 với thông báo
                return StatusCode(500, new { Message = "Đã xảy ra lỗi: " + ex.Message });
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
