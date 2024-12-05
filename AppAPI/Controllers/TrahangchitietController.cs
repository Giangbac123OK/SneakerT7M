using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrahangchitietController : ControllerBase
    {
        private readonly ITraHangChiTietService _ser;
        public TrahangchitietController(ITraHangChiTietService ser)
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
        [HttpGet("Chi-tiet-ma-hoa-don:{id}")]
        public async Task<IActionResult> GetByMaHD(int id)
        {
            try
            {
                var a = await _ser.GetByMaHD(id);
                if (a == null) return BadRequest("Không tồn tại");
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(TraHangChiTietDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    await _ser.Add(dto);

                    return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TraHangChiTietDTO dto)
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
                await _ser.Delete(id);
                return Ok("Xóa thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
