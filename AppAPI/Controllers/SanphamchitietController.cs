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
        private readonly KhachHang_ISanphamchitietService _KhachHang_service;
        public SanphamchitietController(KhachHang_ISanphamchitietService service)
        {
            _KhachHang_service = service;

        }
        // API để lấy tất cả sản phẩm chi tiết
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var SanPhamCTList = await _KhachHang_service.GetAllAsync();
            return Ok(SanPhamCTList);
        }

        // API để lấy sản phẩm chi tiết theo Id
        [HttpGet("_KhachHang/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var SanPhamCT = await _KhachHang_service.GetByIdAsync(id);
            if (SanPhamCT == null) return NotFound(new { message = "Sản phẩm chi tiết không tìm thấy" });
            return Ok(SanPhamCT);
        }

        [HttpGet("_KhachHang/sanpham/{id}")]
        public async Task<IActionResult> GetByIdSPAsync(int id)
        {
            try
            {
                var thuoctinhDto = await _KhachHang_service.GetByIdSPAsync(id);

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

        [HttpGet("_KhachHang/GetSanPhamChiTietByThuocTinh")]
        public async Task<IActionResult> GetSanPhamChiTietByThuocTinh([FromQuery] List<string> tenthuoctinh)
        {
            if (tenthuoctinh == null || !tenthuoctinh.Any())
            {
                return BadRequest(new { error = "Danh sách thuộc tính không được để trống." });
            }

            try
            {
                // Gọi service để lấy danh sách sản phẩm chi tiết
                var sanPhamChiTiet = await _KhachHang_service.GetByISPCTAsync(tenthuoctinh);

                // Kiểm tra nếu không tìm thấy dữ liệu
                if (sanPhamChiTiet == null || !sanPhamChiTiet.Any())
                {
                    return NotFound(new { error = "Không tìm thấy sản phẩm chi tiết với các thuộc tính được cung cấp." });
                }

                // Trả về kết quả dạng JSON
                return Ok(sanPhamChiTiet);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu có hệ thống logging)
                // _logger.LogError(ex, "Lỗi khi xử lý GetSanPhamChiTietByThuocTinh");

                return StatusCode(500, new { error = "Đã xảy ra lỗi khi xử lý yêu cầu.", details = ex.Message });
            }
        }


        [HttpGet("_KhachHang/thuoctinh/{id}")]
        public async Task<IActionResult> GetByIdTTSPCT(int id)
        {
            try
            {
                // Gọi service để lấy dữ liệu thuộc tính sản phẩm chi tiết
                var thuoctinhDto = await _KhachHang_service.GetByIdTTSPCTAsync(id);

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
            await _KhachHang_service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Mota }, dto);
        }
        [HttpPost("_KhachHang/AddThuoctinhsanphamchitiet")]
        public async Task<IActionResult> AddThuoctinhsanphamchitiet(int idsp, int idspct, int idtt, List<string> tenthuoctinhchitietList)
        {
            try
            {
                await _KhachHang_service.AddThuoctinhsanphamchitiet(idsp, idspct, idtt, tenthuoctinhchitietList);
                return Ok("Thêm thuộc tính sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("_KhachHang/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SanphamchitietsDTO dto)
        {
            await _KhachHang_service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("_KhachHang/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _KhachHang_service.DeleteAsync(id);
            return NoContent();
        }
    }
}
