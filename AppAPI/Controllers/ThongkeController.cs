using AppData.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongkeController : ControllerBase
    {
        private readonly IThongkeService _ser;
        public ThongkeController(IThongkeService ser)
        {
            _ser = ser;
        }
        [HttpGet("{thoigian}")]
        public async Task<IActionResult> GetThongKe(string thoigian)
        {
            var data = await _ser.GetThongke(thoigian);
            if (thoigian == null)
            {
                return BadRequest("Vui lòng chọn thời gian!");
            }
            return Ok(data);
        }
    }
}
