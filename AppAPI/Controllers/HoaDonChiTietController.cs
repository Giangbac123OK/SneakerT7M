﻿using AppData;
using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IHoaDonChiTietService _service;
        private readonly MyDbContext _context;

        public HoaDonChiTietController(IHoaDonChiTietService service, MyDbContext context)
        {
            _service = service;
            _context = context;
        }

        // API để lấy tất cả hoá đơn chi tiết
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var hoadonctList = await _service.GetAllAsync();
                return Ok(hoadonctList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách hoá đơn chi tiết", error = ex.Message });
            }
        }

        // API để lấy hoá đơn chi tiết theo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var hoadonct = await _service.GetByIdAsync(id);
                if (hoadonct == null)
                    return NotFound(new { message = "Hoá đơn chi tiết không tìm thấy" });

                return Ok(hoadonct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin hoá đơn chi tiết", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HoaDonchitietDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _service.AddAsync(dto); // Chỉ gọi hàm
                return CreatedAtAction(nameof(GetById), new { id = dto.Idhd }, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm hoá đơn chi tiết", error = ex.Message });
            }
        }

        [HttpPost("ReturnProduct/{hoadonId}")]
        public async Task<IActionResult> ReturnProductAsync(int hoadonId)
        {
            try
            {
                await _service.ReturnProductAsync(hoadonId);
                return Ok(new { success = true, message = "Hoàn trả sản phẩm thành công!" });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Đã xảy ra lỗi khi xử lý!" });
            }
        }

        [HttpPost("salespct/{idsale}")]
        public async Task<IActionResult> salespct(int idsale)
        {
            try
            {
                // Kiểm tra giá trị đầu vào
                if (idsale <= 0)
                {
                    return BadRequest(new { success = false, message = "ID sale không hợp lệ." });
                }

                // Truy vấn dữ liệu
                var sale = await _context.salechitiets.FirstOrDefaultAsync(id => id.Id == idsale);

                // Kiểm tra dữ liệu tồn tại
                if (sale == null)
                {
                    return NotFound(new { success = false, message = "Sale không tìm thấy." });
                }

                // Cập nhật số lượng
                sale.Soluong -= 1;
                _context.salechitiets.Update(sale);

                // Lưu thay đổi vào DB
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Hoàn trả sale thành công!" });
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(500, new { success = false, message = "Lỗi khi cập nhật cơ sở dữ liệu.", detail = dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Đã xảy ra lỗi khi xử lý.", detail = ex.Message });
            }
        }

        // API để cập nhật hoá đơn chi tiết
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HoaDonchitietDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Trả về lỗi nếu DTO không hợp lệ

            try
            {
                var existingHoadonCT = await _service.GetByIdAsync(id);
                if (existingHoadonCT == null)
                    return NotFound(new { message = "Hoá đơn chi tiết không tìm thấy" });

                await _service.UpdateAsync(dto, id);
                return NoContent(); // Trả về status code 204 nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật hoá đơn chi tiết", error = ex.Message });
            }
        }

        // API để xóa hoá đơn chi tiết
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingHoadonCT = await _service.GetByIdAsync(id);
                if (existingHoadonCT == null)
                    return NotFound(new { message = "Hoá đơn chi tiết không tìm thấy" });

                await _service.DeleteAsync(id);
                return NoContent(); // Trả về status code 204 nếu xóa thành công
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa hoá đơn chi tiết", error = ex.Message });
            }
        }
        [HttpGet("Hoa-don-chi-tiet-Theo-Ma-HD-{id}")]
        public async Task<IActionResult> HoadoncttheoMaHD(int id)
        {
            try
            {
                return Ok(await _service.HoadonchitietTheoMaHD(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin hoá đơn chi tiết", error = ex.Message });
            }
        }
        [HttpGet("Check-so-luong:{id}")]
        public async Task<IActionResult> Checksoluong(int id)
        {
            try
            {
                return Ok(await _service.Checksoluong(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin hoá đơn chi tiết", error = ex.Message });
            }
        }
    }
}
