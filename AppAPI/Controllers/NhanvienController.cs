using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class NhanvienController : Controller
	{
		private readonly KhachHang_INhanvienService _KhachHang_service;
		public NhanvienController(KhachHang_INhanvienService service)
		{
			_KhachHang_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _KhachHang_service.GetAllNhanviensAsync();
			return Ok(result.Select(nv => new
			{
				nv.Hoten,
				nv.Ngaysinh,
				nv.Diachi,
				Gioitinh = nv.Gioitinh== true?"Nam":"Nữ",
				nv.Sdt,
				Trangthai = nv.Trangthai == 0 ? "Hoạt động" : "Dừng hoạt động",
				nv.Password,
				Role = nv.Role == 0 ? "Quản lý" : "Nhân viên"
			}));
		}

		[HttpGet("_KhachHang/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var nhanvien = await _KhachHang_service.GetNhanvienByIdAsync(id);
				return Ok(new
				{
					nhanvien.Hoten,
					nhanvien.Ngaysinh,
					nhanvien.Diachi,
					Gioitinh = nhanvien.Gioitinh == false ? "Nam" : "Nữ",
					nhanvien.Sdt,
					Trangthai = nhanvien.Trangthai == 0 ? "Hoạt động" : "Dừng hoạt động",
					nhanvien.Password,
					Role = nhanvien.Role == 0 ? "Quản lý" : "Nhân viên"
				});
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Nhân viên không tồn tại.");
			}


		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] NhanvienDTO nhanvienDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			await _KhachHang_service.AddNhanvienAsync(nhanvienDto);
			return CreatedAtAction(nameof(GetById), new { id = nhanvienDto.Hoten }, nhanvienDto);
		}

		[HttpPut("_KhachHang/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] NhanvienDTO nhanvienDto)
		{
			try
			{
				await _KhachHang_service.UpdateNhanvienAsync(id, nhanvienDto);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Nhân viên không tồn tại.");
			}
		}

		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _KhachHang_service.DeleteNhanvienAsync(id);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Nhân viên không tồn tại.");
			}
		}
	}
}
