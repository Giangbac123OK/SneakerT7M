using AppData;
using AppData.Dto;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly MyDbContext _context;
		private readonly ILogger<LoginController> _logger;
			public LoginController(MyDbContext context, ILogger<LoginController> logger)
		{
			_context = context;
			_logger = logger;
		}
		[HttpPost("register")]
		public IActionResult Register([FromBody] RegisterUserDTO dto)
		{
			try
			{
				if (_context.khachhangs.Any(kh => kh.Email == dto.Email))
				{
					return BadRequest("Email đã tồn tại");
				}

				var khachHang = new Khachhang
				{
					Ten = dto.Ten,
					Sdt = dto.Sdt,
					Ngaysinh = dto.Ngaysinh,
					Email = dto.Email,
					Diachi = dto.Diachi,
					Password = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Băm mật khẩu
					Ngaytaotaikhoan = DateTime.UtcNow,
					Tichdiem = 0, // Giá trị mặc định
					Diemsudung = 0,
					Trangthai = 0,
					Idrank = 1 // Rank mặc định
				};

				_context.khachhangs.Add(khachHang);
				_context.SaveChanges();

				return Ok("Đăng ký thành công");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error during registration");
				return StatusCode(500, "Đã xảy ra lỗi trong quá trình đăng ký");
			}
			// Kiểm tra xem email đã tồn tại chưa


		}






		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
		{
			try
			{
				_logger.LogInformation($"Login attempt for email: {dto.Email}");
				if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
				{
					_logger.LogWarning("Email or password is empty");
					return BadRequest("Email và mật khẩu không được để trống");
				}
				var khachHang = await _context.khachhangs
					.FirstOrDefaultAsync(kh => kh.Email == dto.Email);
				if (khachHang == null)
				{
					_logger.LogWarning($"Account not found for email: {dto.Email}");
					return NotFound("Tài khoản không tồn tại");
				}
				bool passwordValid = BCrypt.Net.BCrypt.Verify(dto.Password, khachHang.Password);
				_logger.LogInformation($"Password validation result: {passwordValid}");
				if (!passwordValid)
				{
					_logger.LogWarning($"Invalid password for email: {dto.Email}");
					return Unauthorized("Mật khẩu không đúng");
				}
				_logger.LogInformation($"Login successful for email: {dto.Email}");
				return Ok(new
				{
					Message = "Đăng nhập thành công",
					KhachHangId = khachHang.Id,
					Ten = khachHang.Ten,
					Email = khachHang.Email,
					Ngaytaotaikhoan = khachHang.Ngaytaotaikhoan
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error during login process");
				return StatusCode(500, "Đã xảy ra lỗi trong quá trình đăng nhập");
			}
		}

	}

}

