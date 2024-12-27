using AppData.Dto;
using AppData.IService;
using AppData.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Sanphamcontroller : Controller
	{
		private readonly KhachHang_ISanPhamservice _KhachHang_service;

        public Sanphamcontroller(KhachHang_ISanPhamservice service)
        {
			_KhachHang_service = service;

		}
		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _KhachHang_service.GetAllAsync());

		[HttpGet("_KhachHang/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
            var sanpham = await _KhachHang_service.GetByIdAsync(id);
            return sanpham != null ? Ok(sanpham) : NotFound();
        }

		[HttpPost]
		public async Task<IActionResult> Add(SanphamDTO sanphamDto)
		{
			await _KhachHang_service.AddAsync(sanphamDto);
			return CreatedAtAction(nameof(GetById), new { id = sanphamDto.Idth }, sanphamDto);
		}

		[HttpPut("_KhachHang/{id}")]
		public async Task<IActionResult> Update(int id, SanphamDTO sanphamDto)
		{
			await _KhachHang_service.UpdateAsync(id, sanphamDto);
			return NoContent();
		}

        [HttpPut("_KhachHang/{id}/cancel")]
		public async Task<IActionResult> UpdateStatusToCancelled(int id)
		{
			try
			{
				await _KhachHang_service.UpdateStatusToCancelled(id);
				return NoContent(); // Thành công mà không cần trả về nội dung
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPut("_KhachHang/{id}/update-status-load")]
		public async Task<IActionResult> UpdateStatusload(int id)
		{
			try
			{
				await _KhachHang_service.UpdateStatusLoad(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _KhachHang_service.DeleteAsync(id);
			return NoContent();
		}

		[HttpGet("_KhachHang/search")]
		public async Task<IActionResult> SearchByName(string name) => Ok(await _KhachHang_service.SearchByNameAsync(name));

        [HttpGet("_KhachHang/GetALLSanPham")]
        public async Task<IActionResult> GetAllSanphams()
        {
            try
            {
                var sanphamViewModels = await _KhachHang_service.GetAllSanphamViewModels();
                return Ok(sanphamViewModels);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ chung nếu có lỗi khác
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("_KhachHang/GetALLSanPham/{id}")]
        public async Task<IActionResult> GetAllSanphamsByIdSP(int id)
        {
            try
            {
                var sanphamViewModels = await _KhachHang_service.GetAllSanphamViewModelsByIdSP(id);
                return Ok(sanphamViewModels);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("_KhachHang/GetALLSanPhamGiamGia")]
        public async Task<IActionResult> GetAllSanphamsGiamGia()
        {
            try
            {
                var sanphamViewModels = await _KhachHang_service.GetAllSanphamGiamGiaViewModels();
                return Ok(sanphamViewModels);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ chung nếu có lỗi khác
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("_KhachHang/GetALLSanPhamByThuongHieu/{id}")]
        public async Task<IActionResult> GetAllSanphamsByThuongHieu(int id)
        {
            try
            {
                var sanphamViewModels = await _KhachHang_service.GetAllSanphamByThuongHieu(id);
                return Ok(sanphamViewModels);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("_KhachHang/SanPhamChiTiet/search")]
        public async Task<IActionResult> SearchSanphams(
             [FromQuery] List<string> tenThuocTinhs,
            [FromQuery] decimal? giaMin = null,
             [FromQuery] decimal? giaMax = null,
            [FromQuery] int? idThuongHieu = null)
            {
            try
            {
                tenThuocTinhs ??= new List<string>();

                 var sanphams = await _KhachHang_service.GetSanphamByThuocTinh(tenThuocTinhs, giaMin, giaMax, idThuongHieu);
                if (sanphams == null || !sanphams.Any())
                {
                    return NotFound(new { message = "Không tìm thấy sản phẩm nào thỏa mãn tiêu chí. thanh" });
                }

                return Ok(sanphams);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Có lỗi xảy ra", error = ex.Message });
            }
        }
    }

}

