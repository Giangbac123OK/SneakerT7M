﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData;
using AppData.Models;
using AppData.IService;
using AppData.Dto;
using AppData.Service;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhgiasController : ControllerBase
    {
        private readonly IDanhGiaServices _services;

        public DanhgiasController(IDanhGiaServices services)
        {
            _services = services;
        }

        // GET: api/Danhgias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DanhGiaDTO>>> Getdanhgias()
        {
            try
            {
                if (await _services.GetAll() == null)
                {
                    return NotFound();
                }
                return await _services.GetAll();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Danhgias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DanhGiaDTO>> GetDanhgia(int id)
        {
            try
            {

                if (await _services.GetAll() == null)
                {
                    return NotFound();
                }
                var danhgia = await _services.GetById(id);

                if (danhgia == null)
                {
                    return NotFound();
                }

                return danhgia;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byIDhdct/{id}")]
        public async Task<ActionResult<DanhGiaDTO>> GetDanhgiaByidHDCT(int id)
        {
            try
            {

                if (await _services.GetAll() == null)
                {
                    return NotFound();
                }
                var danhgia = await _services.getByidHDCT(id);

                if (danhgia == null)
                {
                    return NotFound();
                }

                return danhgia;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Danhgias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhgia(int id, DanhGiaDTO danhgia)
        {
            if (id != danhgia.Id)
            {
                return BadRequest("ID trong URL không khớp với ID trong dữ liệu.");
            }

            try
            {
                // Kiểm tra xem đánh giá có tồn tại không
                var existingDanhGia = await _services.GetById(id);
                if (existingDanhGia == null)
                {
                    return NotFound($"Không tìm thấy đánh giá với ID = {id}.");
                }

                // Xử lý ảnh nếu có cập nhật
                string updatedImageUrl = existingDanhGia.UrlHinhanh; // Giữ lại URL ảnh cũ
                if (!string.IsNullOrEmpty(danhgia.UrlHinhanh))
                {
                    // Giải mã chuỗi Base64 của ảnh mới
                    var imageBytes = Convert.FromBase64String(danhgia.UrlHinhanh);

                    // Tạo tên file mới và đường dẫn
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

                    // Đảm bảo thư mục tồn tại
                    var directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    // Lưu file ảnh mới
                    await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                    // Nếu ảnh cũ tồn tại, xóa nó
                    if (!string.IsNullOrEmpty(existingDanhGia.UrlHinhanh))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), existingDanhGia.UrlHinhanh.TrimStart('/'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Cập nhật URL ảnh
                    updatedImageUrl = "/uploads/" + fileName;
                }

                // Cập nhật thông tin đánh giá
                danhgia.UrlHinhanh = updatedImageUrl;
                await _services.Update(id, danhgia);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Đã xảy ra lỗi: {ex.Message}");
            }
        }


        // POST: api/Danhgias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DanhGiaDTO>> PostDanhgia(DanhGiaDTO danhgia)
        {
            if (await _services.GetAll() == null)
            {
                return Problem("Entity set 'MyDbContext.danhgias' is null.");
            }

            try
            {
                string savedImageUrl = null;

                if (!string.IsNullOrEmpty(danhgia.UrlHinhanh))
                {
                    // Giải mã chuỗi Base64 và lưu ảnh vào thư mục uploads
                    var imageBytes = Convert.FromBase64String(danhgia.UrlHinhanh);
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    // Đảm bảo thư mục tồn tại
                    var directory = Path.GetDirectoryName(filePath);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                    // Cập nhật URL đầy đủ
                    var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
                    savedImageUrl = $"{baseUrl}/uploads/{fileName}";
                }

                danhgia.UrlHinhanh = savedImageUrl;

                await _services.Create(danhgia);

                return CreatedAtAction("GetDanhgia", new { id = danhgia.Id }, danhgia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Danhgias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhgia(int id)
        {
            if (await _services.GetAll() == null)
            {
                return NotFound();
            }

            try
            {
               await _services.Delete(id);
                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("LichSuMuaHang/{idkh}")]
        public async Task<IActionResult> GetLichSuMuaHang(int idkh)
        {
            if(idkh <= 0)
            {
                return BadRequest(new { message = "ID khách hàng không hợp lệ." });
            }
            try
            {
                var resurl = await _services.lichSuMuaHangDTOs(idkh);
                if(resurl == null || !resurl.Any())
                {
                    return NotFound(new { message = "Không tìm thấy lịch sử mua hàng." });
                }
                return Ok(resurl);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetByIdSPCT/{id}")]
        public async Task<IActionResult> GetByIdSPCT(int id)
        {
            // Kiểm tra ID
            if (id <= 0)
            {
                return BadRequest(new { message = "ID sản phẩm chi tiết không hợp lệ." });
            }

            // Gọi dịch vụ với danh sách chỉ chứa một ID
            var result = await _services.GetByidSP(id);

            // Kiểm tra kết quả trả về
            if (result == null || !result.Any())
            {
                return NotFound(new { message = "Không tìm thấy đánh giá nào cho sản phẩm chi tiết này." });
            }

            return Ok(result);
        }





    }
}
