using AppData.Dto;
using AppData.IService;
using AppData.Service;
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
        [HttpPost]
        public async Task<IActionResult> Create(GiohangchitietDTO gh)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                await _ser.AddGiohangAsync(gh);
            return Ok("Thêm thành công!");
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
                await _ser.UpdateGiohangAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ser.DeleteGiohangAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giỏ hàng chi tiết không tồn tại.");
            }
        }
    }
}

