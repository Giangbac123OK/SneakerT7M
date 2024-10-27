using AppData.Dto;
using AppData.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class NhanvienController : Controller
	{
		private readonly INhanvienService _service;
		public NhanvienController(INhanvienService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllNhanviensAsync();
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

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var nhanvien = await _service.GetNhanvienByIdAsync(id);
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

			await _service.AddNhanvienAsync(nhanvienDto);
			return CreatedAtAction(nameof(GetById), new { id = nhanvienDto.Hoten }, nhanvienDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] NhanvienDTO nhanvienDto)
		{
			try
			{
				await _service.UpdateNhanvienAsync(id, nhanvienDto);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Nhân viên không tồn tại.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeleteNhanvienAsync(id);
				return NoContent();
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Nhân viên không tồn tại.");
			}
		}
	}
}
