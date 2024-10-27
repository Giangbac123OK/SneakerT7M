using AppData.Dto;
using AppData.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NhacungcapController : Controller
	{
		private readonly InhacungcapService _service;
		public NhacungcapController(InhacungcapService service)
        {
			_service = service;

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var nhacungcap = await _service.GetByIdAsync(id);
			if (nhacungcap == null) return NotFound();

			return Ok(new
			{
				nhacungcap.Tennhacungcap,
				nhacungcap.Sdt,
				nhacungcap.Diachi,
				nhacungcap.Email,
				Trangthai = nhacungcap.Trangthai == 0 ? "Đang hoạt động" : "Dừng hoạt động"
			});
		}
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] NhacungcapDto nhaCungCapDto)
		{
			

			try
			{
				await _service.AddAsync(nhaCungCapDto);
				return CreatedAtAction(nameof(GetById), new { id = nhaCungCapDto.Tennhacungcap }, nhaCungCapDto); // Trả về trạng thái 201 Created
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Có lỗi xảy ra: " + ex.Message }); // Trả về thông điệp lỗi chung
			}
		}

		// Cập nhật nhà cung cấp theo ID
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] NhacungcapDto nhaCungCapDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState); // Trả về lỗi nếu model không hợp lệ

			try
			{
				await _service.UpdateAsync(id, nhaCungCapDto);
				return NoContent(); // Trả về trạng thái 204 No Content nếu cập nhật thành công
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Có lỗi xảy ra: " + ex.Message }); // Trả về thông điệp lỗi chung
			}
		}

		// Xóa nhà cung cấp theo ID
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeleteAsync(id);
				return NoContent(); // Trả về trạng thái 204 No Content nếu xóa thành công
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Có lỗi xảy ra: " + ex.Message }); // Trả về thông điệp lỗi chung
			}
		}

		// Lấy tất cả nhà cung cấp
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

	}
}
