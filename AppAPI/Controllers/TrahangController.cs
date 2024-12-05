using AppData.Dto;
using AppData.IService;
using AppData.Models;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrahangController : ControllerBase
    {
        private readonly ITraHangService _ser;
        public TrahangController(ITraHangService ser)
        {
            _ser = ser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _ser.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var a = await _ser.GetById(id);
                if (a == null) return BadRequest("Không tồn tại");
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(TraHangDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    var a = new TraHangDTO
                    {
                        Tenkhachhang = dto.Tenkhachhang,
                        Idkh = dto.Idkh,
                        Idnv = dto.Idnv != null ? dto.Idnv : null,
                        Sotienhoan = dto.Sotienhoan,
                        Lydotrahang = dto.Lydotrahang != null ? dto.Lydotrahang : null,
                        Trangthai = dto.Trangthai,
                        Phuongthuchoantien = dto.Phuongthuchoantien,
                        Ngaytrahangdukien = dto.Ngaytrahangdukien != null ? dto.Ngaytrahangdukien : null,
                        Ngaytrahangthucte = dto.Ngaytrahangthucte != null ? dto.Ngaytrahangthucte : null,
                        Chuthich = dto.Chuthich != null ? dto.Chuthich : null
                    };
                    await _ser.Add(a);
                    return Ok("Thêm thành công!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TraHangDTO dto)
        {
            try
            {
                await _ser.Update(id, dto);
                return Ok("Sửa thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ser.DeleteById(id);
                return Ok("Xóa thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("tra-hang-qua-han")]
        public async Task<IActionResult> DeleteTrahangQua15Days()
        {
            try
            {
                await _ser.Trahangquahan();
                return NoContent(); // HTTP 204 - Thành công, không trả về nội dung
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message }); // HTTP 404 - Không tìm thấy
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi hệ thống", details = ex.Message }); // HTTP 500 - Lỗi server
            }
        }

    }
}
