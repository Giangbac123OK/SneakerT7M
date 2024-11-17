using AppData.Dto;
using AppData.IService;
using AppData.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SaleController : Controller
	{
		private readonly ISaleService _service;

		public SaleController(ISaleService service)
		{
			_service = service;
		}
		/*	[HttpGet]
			public async Task<IActionResult> GetAll()
			{
				var sales = await _service.GetAllAsync();
				return Ok(sales.Select(s => new
				{

					s.Ten,
					s.Mota,
					Trangthai = s.Trangthai switch
					{
						0 => "Đang diễn ra",
						1 => "Chuẩn bị diễn ra",
						2 => "Đã diễn ra",
						3 => "Dừng phát hành",
						_ => "Không xác định"
					},
					s.Ngaybatdau,
					s.Ngayketthuc
				}));
			}*/
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var sales = await _service.GetAllWithIdAsync();
			return Ok(sales.Select(s => new
			{
				s.Id, // Thêm Id vào kết quả trả về
				s.Ten,
				s.Mota,
				Trangthai = s.Trangthai switch
				{
					0 => "Đang diễn ra",
					1 => "Chuẩn bị diễn ra",
					2 => "Đã diễn ra",
					3 => "Dừng phát hành",
					_ => "Không xác định"
				},
				s.Ngaybatdau,
				s.Ngayketthuc
			}));
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var sale = await _service.GetByIdAsync(id);
			if (sale == null) return NotFound();

			return Ok(new
			{
				sale.Ten,
				sale.Mota,
				Trangthai = sale.Trangthai switch
				{
					0 => "Đang diễn ra",
					1 => "Chuẩn bị diễn ra",
					2 => "Đã diễn ra",
					3 => "Dừng phát hành",
					_ => "Không xác định"
				},
				sale.Ngaybatdau,
				sale.Ngayketthuc
			});
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] SaleDto saleDto)
		{
			/*await _service.AddAsync(saleDto);
			//var x = a _service.AddAsync(saleDto);
			return CreatedAtAction(nameof(GetById), new { id = saleDto.Ten }, saleDto);*/
			try
			{
				

				await _service.AddAsync(saleDto);
				return Ok();
			}
			catch (ArgumentException ex)
			{
				// Chỉ trả ra thông báo lỗi đơn giản
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				// Xử lý lỗi chung (nếu cần), có thể ghi log hoặc xử lý khác
				return StatusCode(500, "Đã xảy ra lỗi, vui lòng thử lại sau.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] SaleDto saleDto)
		{
			await _service.UpdateAsync(id, saleDto);
			return NoContent();
		}

		[HttpPut("{id}/cancel")]
		public async Task<IActionResult> UpdateStatusToCancelled(int id)
		{
			try
			{
				await _service.UpdateStatusToCancelled(id);
				return NoContent(); // Thành công mà không cần trả về nội dung
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpPut("{id}/update-status")]
		public async Task<IActionResult> UpdateStatusBasedOnDates(int id)
		{
			try
			{
				await _service.UpdateStatusBasedOnDates(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
		[HttpPut("{id}/update-status-load")]
		public async Task<IActionResult> UpdateStatusload(int id)
		{
			try
			{
				await _service.UpdateStatusLoad(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
