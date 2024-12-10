using AppData.Dto;
using AppData.IService;
using AppData.Service;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiohangchitietController : ControllerBase
    {
        private readonly IGiohangchitietService _ser;
        public GiohangchitietController(IGiohangchitietService ser)
        {
            _ser = ser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var a = await _ser.GetAllGiohangsAsync();
            return Ok(a);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var a = await _ser.GetGiohangByIdAsync(id);
                return Ok(a);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại.");
            }
        }

        [HttpGet("idghctbygiohangangspct/{idgh}/{idspct}")]
        public async Task<IActionResult> GetByIdspctToGiohangAsync(int idgh, int idspct)
        {
            try
            {
                var result = await _ser.GetByIdspctToGiohangAsync(idgh, idspct);

                if (result == null)
                {
                    return NotFound("Giỏ hàng chi tiết không tồn tại.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
                return StatusCode(500, "Đã xảy ra lỗi khi xử lý yêu cầu.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(GiohangchitietDTO gh)
        {
            try
            {
                var result = await _ser.GetByIdspctToGiohangAsync(gh.Idgh, gh.Idspct);

                if (result == null)
                {
                    await _ser.AddGiohangAsync(gh);
                    return Ok("Thêm thành công!");
                }
                else
                {
                    _ser.UpdateSoLuongGiohangAsync(result.Id, gh);
                    return Ok("Sản phẩm đã tồn tại trong giỏ hàng, cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }

        [HttpGet("giohangchitietbygiohang/{id}")]
        public async Task<IActionResult> GetDiaChiByIdKH(int id)
        {
            try
            {
                var diachiDto = await _ser.GetGHCTByIdGH(id);


                return Ok(diachiDto);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiohangchitietDTO dto)
        {
            try
            {
                var result = await _ser.GetByIdspctToGiohangAsync(dto.Idgh, dto.Idspct);

                if (result == null)
                {
                    await _ser.UpdateGiohangAsync(id, dto);
                    return Ok("Cập Nhật Thành Công!");
                }
                else
                {
                    await _ser.DeleteGiohangAsync(id);
                    _ser.UpdateSoLuongGiohangAsync(result.Id, dto);
                    return Ok("Sản phẩm đã tồn tại trong giỏ hàng, cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Đã xảy ra lỗi: " + ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ser.DeleteGiohangAsync(id);
                return Ok("Xoá giỏ hàng chi tiết thành công."); // Trả về thông báo khi xoá thành công
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại."); // Trả về lỗi nếu không tìm thấy
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}"); // Xử lý lỗi không mong muốn
            }
        }
    }
}

