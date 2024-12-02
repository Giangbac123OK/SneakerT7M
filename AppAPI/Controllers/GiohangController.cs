using AppData.Dto;
using AppData.IService;
using AppData.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiohangController : ControllerBase
    {
        private readonly IGiohangService _ser;
        public GiohangController(IGiohangService ser)
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
                return NotFound("Giỏ hàng không tồn tại.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(GiohangDTO gh)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            gh.Soluong = 0;
            await _ser.AddGiohangAsync(gh);
            return Ok("Thêm thành công!");
        }

        [HttpGet("giohangkhachhang/{id}")]
        public async Task<IActionResult> Giohangkhachhang(int id)
        {
            var hoadon = await _ser.GetByIdKHAsync(id);

            if (hoadon == null)
                return Ok(null); 

            return Ok(hoadon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GiohangDTO dto)
        {
            try
            {
                await _ser.UpdateGiohangAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giỏ hàng không tồn tại.");
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
                return NotFound("Giỏ hàng không tồn tại.");
            }
        }
    }
}
