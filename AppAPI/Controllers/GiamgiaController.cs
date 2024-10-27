using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class GiamgiaController : Controller
	{
		private readonly IGiamgiaService _service;
        public GiamgiaController(IGiamgiaService service)
        {
			_service = service;

		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result.Select(gg => new
			{
				gg.Mota,
				Donvi = gg.Donvi == 0 ? "VND" : "%",
				gg.Giatri,
				gg.Ngaybatdau,
				gg.Ngayketthuc,
				Trangthai = gg.Trangthai switch
				{
					0 => "Đang phát hành",
					1 => "Chuẩn bị phát hành",
					2 => "Dừng phát hành",
					_ => "Không xác định"
				}
			}));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var giamgia = await _service.GetByIdAsync(id);
				return Ok(new
				{
					giamgia.Mota,
					Donvi = giamgia.Donvi == 0 ? "VND" : "%",
					giamgia.Giatri,
					giamgia.Ngaybatdau,
					giamgia.Ngayketthuc,
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
			await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = dto.Mota }, dto);
		}
		[HttpPost("AddRankToGiamgia")]
		public async Task<IActionResult> AddRankToGiamgia([FromBody] Giamgia_RankDTO dto)
		{
			try
			{
				await _service.AddRankToGiamgia(dto);
				return Ok("Rank added to Giảm Giá thành công.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] GiamgiaDTO dto)
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
