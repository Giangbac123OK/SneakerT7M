using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Mvc;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongthucthanhtoanController : Controller
    {
        private readonly KhachHang_IphuongthucthanhtoanServicee _KhachHang_service;

        public PhuongthucthanhtoanController(KhachHang_IphuongthucthanhtoanServicee service)
        {
            _KhachHang_service = service;
        }

        //sửa lại
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhuongthucthanhtoanDTO>>> GetAll()
        {
            // Lấy toàn bộ danh sách hiện có từ cơ sở dữ liệu
            var existingItems = await _KhachHang_service.GetAllAsync();

            // Dữ liệu mặc định cần kiểm tra hoặc tạo
            var defaultItems = new List<PhuongthucthanhtoanDTO>
            {
                new PhuongthucthanhtoanDTO { Id = 1, Tenpttt = "Thanh toán khi nhận hàng", Trangthai = 0 },
                new PhuongthucthanhtoanDTO { Id = 2, Tenpttt = "Chuyển khoản ngân hàng", Trangthai = 0 }
            };

            // Danh sách item cần tạo mới
            var itemsToCreate = new List<PhuongthucthanhtoanDTO>();

            foreach (var defaultItem in defaultItems)
            {
                // Kiểm tra xem item mặc định có tồn tại trong danh sách không
                var existingItem = existingItems.FirstOrDefault(e => e.Tenpttt.Equals(defaultItem.Tenpttt, StringComparison.OrdinalIgnoreCase));

                if (existingItem == null)
                {
                    // Nếu không tồn tại, thêm vào danh sách cần tạo
                    itemsToCreate.Add(defaultItem);
                }
            }

            // Tạo mới các item cần tạo
            if (itemsToCreate.Any())
            {
                foreach (var item in itemsToCreate)
                {
                    await _KhachHang_service.AddAsync(item);
                }
            }

            // Trả về danh sách đầy đủ sau khi xử lý
            var result = await _KhachHang_service.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("_KhachHang/{id}")]
        public async Task<ActionResult<PhuongthucthanhtoanDTO>> GetById(int id)
        {
            var phuongthucthanhtoan = await _KhachHang_service.GetByIdAsync(id);
            if (phuongthucthanhtoan == null) return NotFound();

            return Ok(new
            {
                phuongthucthanhtoan.Id,
                phuongthucthanhtoan.Tenpttt,
                Trangthai = phuongthucthanhtoan.Trangthai == 0 ? "Đang sử dụng" : "Không sử dụng"
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create(PhuongthucthanhtoanDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Kiểm tra trùng lặp
            var existingItems = await _KhachHang_service.GetAllAsync();
            if (existingItems.Any(e => e.Tenpttt == dto.Tenpttt && e.Trangthai == dto.Trangthai))
            {
                return BadRequest("Phương thức thanh toán này đã tồn tại.");
            }

            await _KhachHang_service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("_KhachHang/{id}")]
        public async Task<ActionResult> Update(int id, PhuongthucthanhtoanDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingItem = await _KhachHang_service.GetByIdAsync(id);
            if (existingItem == null) return NotFound();

            await _KhachHang_service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("_KhachHang/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _KhachHang_service.DeleteAsync(id);
            return NoContent();
        }
    }
}
