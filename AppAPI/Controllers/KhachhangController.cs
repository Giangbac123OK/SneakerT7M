using AppData;
using AppData.Dto;
using AppData.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangController : ControllerBase
    {
        private readonly IKhachhangService _ser;
        private readonly MyDbContext _context;
        public KhachhangController(IKhachhangService ser, MyDbContext context)
        {
            _ser = ser;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _ser.GetAllKhachhangsAsync();
            return Ok(result.Select(kh => new
            {
                kh.Id,
                kh.Ten,
                kh.Sdt,
                kh.Ngaysinh,
                kh.Tichdiem,
                kh.Email,
                kh.Diachi,
                kh.Password,
                kh.Diemsudung,
                Trangthai = kh.Trangthai == 0 ? "Hoạt động" : "Tài khoản bị khoá",
                kh.Idrank
            }));
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
                    Trangthai = kh.Trangthai == 0 ? "Hoạt động" : "Tài khoản bị khoá",
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
               
                if (dto.Trangthai == 1)
                {
                    return Ok(new { message = "Tài khoản đã bị khóa." });
                }
                return Ok(new { message = "Cập nhật thông tin thành công." });
            }

            catch (KeyNotFoundException)
            {
                return NotFound("Khách hàng không tồn tại.");
            }
        }
        
        [HttpPut("UpdateThongTinKhachhangAsync/{id}")]
        public async Task<IActionResult> UpdateThongTinKhachhangAsync(int id, [FromBody] KhachhangDTO dto)
        {
            try
            {
                await _ser.UpdateThongTinKhachhangAsync(id, dto);

                if (dto.Trangthai == 1)
                {
                    return Ok(new { message = "Tài khoản đã bị khóa." });
                }
                return Ok(new { message = "Cập nhật thông tin thành công." });
            }

            catch (KeyNotFoundException)
            {
                return NotFound("Khách hàng không tồn tại.");
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
                return NotFound("Khách hàng không tồn tại.");
            }
        }
        [HttpGet("find-khachhang")]
        public async Task<IActionResult> FindByEmailAsync(string email)
        {
            var nhanVien = await _ser.FindByEmailAsync(email);
            if (nhanVien == null)
                return NotFound("Khách hàng không tồn tại.");

            return Ok(nhanVien);
        }
        // API gửi mã OTP cho quên mật khẩu
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtpAsync(ForgotPasswordRequestKHDto dto)
        {
            var (isSent, otp) = await _ser.SendOtpAsync(dto.Email); // Nhận kết quả và OTP từ service

            if (!isSent)
                return BadRequest("Gửi OTP không thành công.");

            return Ok(new { success = true, message = "Mã OTP đã được gửi.", otp }); // Trả OTP cho client (chỉ khi cần, thường dùng trong môi trường phát triển)
        }
		[HttpPost("doimatkhau")]
		public async Task<IActionResult> ChangePassword([FromBody] DoimkKhachhang changePasswordDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var khachHang = await _context.khachhangs.FirstOrDefaultAsync(kh => kh.Email == changePasswordDto.Email);
				if (khachHang == null)
				{
					return NotFound(new { message = "Tài khoản không tồn tại" });
				}

				// Kiểm tra mật khẩu cũ
				bool isOldPasswordValid = BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, khachHang.Password);
				if (!isOldPasswordValid)
				{
					return Unauthorized(new { message = "Mật khẩu cũ không chính xác" });
				}

				// Hash mật khẩu mới
				khachHang.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);

				_context.khachhangs.Update(khachHang);
				await _context.SaveChangesAsync();

				return Ok(new { message = "Đổi mật khẩu thành công" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình đổi mật khẩu", error = ex.Message });
			}
		}
        [HttpPost("quenmatkhau")]
        public async Task<IActionResult> quenmatkhau([FromBody] DoimkKhachhang changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var khachHang = await _context.khachhangs.FirstOrDefaultAsync(kh => kh.Email == changePasswordDto.Email);
                if (khachHang == null)
                {
                    return NotFound(new { message = "Tài khoản không tồn tại" });
                }

                // Kiểm tra mật khẩu cũ
                var isOldPasswordValid = khachHang.Password;

                // Hash mật khẩu mới
                khachHang.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);

                _context.khachhangs.Update(khachHang);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Đổi mật khẩu thành công" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình đổi mật khẩu", error = ex.Message });
            }
        }

    }
}
