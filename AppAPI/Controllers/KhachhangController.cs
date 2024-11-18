using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangController : ControllerBase
    {
        private readonly IKhachhangService _ser;
        private readonly ITimKiemService _TKser;
        public KhachhangController(IKhachhangService ser, ITimKiemService TKser)
        {
            _ser = ser;
            _TKser = TKser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _ser.GetAllKhachhangsAsync();
            return Ok(result.Select(kh => new
            {
                kh.Ten,
                kh.Sdt,
                kh.Ngaysinh,
                kh.Tichdiem,
                kh.Email,
                kh.Diachi,
                kh.Password,
                kh.Diemsudung,
                Trangthai = kh.Trangthai == 0 ? "Hoạt động" : "Dừng hoạt động",
                kh.Idrank
            }));
        }
        [HttpGet("{search}")]
        public async Task<IActionResult> TimKiemKhachHang(string search)
        {
            try
            {
                var a = await _TKser.TimKiemKhachHang(search);
                if(a == null)
                {
                    return BadRequest("Không tồn tại!");
                }
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var kh = await _ser.GetKhachhangByIdAsync(id);
                return Ok(new
                {
                    kh.Ten,
                    kh.Sdt,
                    kh.Ngaysinh,
                    kh.Tichdiem,
                    kh.Email,
                    kh.Diachi,
                    kh.Password,
                    kh.Diemsudung,
                    Trangthai = kh.Trangthai == 0 ? "Hoạt động" : "Dừng hoạt động",
                    kh.Idrank
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Khách hàng không tồn tại.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(KhachhangDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ser.AddKhachhangAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Ten }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] KhachhangDTO dto)
        {
            try
            {
                await _ser.UpdateKhachhangAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Nhân viên không tồn tại.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _ser.DeleteKhachhangAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Nhân viên không tồn tại.");
            }
        }
    }
}
