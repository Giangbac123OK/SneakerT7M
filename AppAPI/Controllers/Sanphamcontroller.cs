﻿using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class Sanphamcontroller : Controller
	{
		private readonly ISanPhamservice _service;

        public Sanphamcontroller(ISanPhamservice service)
        {
			_service = service;

		}
		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var sanpham = await _service.GetByIdAsync(id);
			return sanpham != null ? Ok(sanpham) : NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Add(SanphamDTO sanphamDto)
		{
			await _service.AddAsync(sanphamDto);
			return CreatedAtAction(nameof(GetById), new { id = sanphamDto.Idth }, sanphamDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, SanphamDTO sanphamDto)
		{
			await _service.UpdateAsync(id, sanphamDto);
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

		[HttpGet("search")]
		public async Task<IActionResult> SearchByName(string name) => Ok(await _service.SearchByNameAsync(name));
	}
}
