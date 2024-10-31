using AppData.Dto;
using AppData.IService;
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
        public async Task<IActionResult> Index()
        {
            var a = await _ser.GetAllGiohangsAsync();
            return Ok(a);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var a = await _ser.GetGiohangByIdAsync(id);
            return Ok(a);
        }
        [HttpPost]
        public async Task<IActionResult> Create(GiohangchitietDTO gh)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            gh.Soluong = 0;
            await _ser.AddGiohangAsync(gh);
            return Ok("Thêm thành công!");
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
