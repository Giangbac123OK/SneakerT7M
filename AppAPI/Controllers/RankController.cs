using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RankController : ControllerBase
	{
		private readonly KhachHang_IRankServiece _KhachHang_service;
		public RankController(KhachHang_IRankServiece service)
		{
			_KhachHang_service = service;

		}
		[HttpGet("_KhachHang/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var x = await _KhachHang_service.GetRankByIdAsync(id);
			if (x == null) return NotFound();

			return Ok(new
			{
				x.TenRank,
				x.MaxMoney,
				x.MinMoney,
				Trangthai = x.trangthai == 0 ? "Đang hoạt động" : "Dừng hoạt động"
			});
		}
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] RankDTO rankDTO)
		{


			try
			{
				await _KhachHang_service.AddRankDTOAsync(rankDTO);
				return CreatedAtAction(nameof(GetById), new { id = rankDTO.TenRank }, rankDTO); // Trả về trạng thái 201 Created
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Có lỗi xảy ra: " + ex.Message }); // Trả về thông điệp lỗi chung
			}
		}

		// Cập nhật nhà cung cấp theo ID
		[HttpPut("_KhachHang/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] RankDTO rankDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState); // Trả về lỗi nếu model không hợp lệ

			try
			{
				await _KhachHang_service.UpdateRankAsync(id, rankDTO);
				return NoContent(); // Trả về trạng thái 204 No Content nếu cập nhật thành công
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Có lỗi xảy ra: " + ex.Message }); // Trả về thông điệp lỗi chung
			}
		}

		// Xóa nhà cung cấp theo ID
		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _KhachHang_service.DeleteRankAsync(id);
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
			var result = await _KhachHang_service.GetAllRanksAsync();
			return Ok(result);
		}
	}
}
