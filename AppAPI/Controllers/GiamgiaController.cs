using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class GiamgiaController : Controller
	{
		private readonly KhachHang_IGiamgiaService _KhachHang_Service;
        public GiamgiaController(KhachHang_IGiamgiaService service)
        {
			_KhachHang_Service = service;

		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _KhachHang_Service.GetAllAsync();
			return Ok(result.Select(gg => new
			{
				gg.Id,
				gg.Mota,
				Donvi = gg.Donvi == 0 ? "VND" : "%",
				gg.Giatri,
				gg.Ngaybatdau,
				gg.Ngayketthuc,
				gg.Soluong,
				Trangthai = gg.Trangthai switch
				{
					0 => "Đang phát hành",
					1 => "Chuẩn bị phát hành",
					2 => "Dừng phát hành",
					_ => "Không xác định"
				}
			}));
		}

		[HttpGet("_KhachHang/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var giamgia = await _KhachHang_Service.GetByIdAsync(id);
				return Ok(new
                {
                    giamgia.Id,
                    giamgia.Mota,
					Donvi = giamgia.Donvi == 0 ? "VND" : "%",
					giamgia.Giatri,
					giamgia.Ngaybatdau,
					giamgia.Ngayketthuc,
                    giamgia.Soluong,
                    Trangthai = giamgia.Trangthai switch
					{
						0 => "Đang phát hành",
						1 => "Chuẩn bị phát hành",
						2 => "Dừng phát hành",
						_ => "Không xác định"
					}
				});
			}
			catch (KeyNotFoundException)
			{
				return NotFound("Không tìm thấy mã giảm giá.");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create(GiamgiaDTO dto)
		{
			await _KhachHang_Service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = dto.Mota }, dto);
		}
		[HttpPost("_KhachHang/AddRankToGiamgia")]
		public async Task<IActionResult> AddRankToGiamgia([FromBody] Giamgia_RankDTO dto)
		{
			try
			{
				await _KhachHang_Service.AddRankToGiamgia(dto);
				return Ok("Rank added to Giảm Giá thành công.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("_KhachHang/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] GiamgiaDTO dto)
		{
		await _KhachHang_Service.UpdateAsync(id, dto);
			return NoContent();
		}

		[HttpDelete("_KhachHang/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _KhachHang_Service.DeleteAsync(id);
			return NoContent();
		}
	}
}
