using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly INhanvienRepos _repos;
        public NhanvienController(INhanvienRepos repos)
        {
            _repos = repos;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repos.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
			{
				if (id == null)
				{
					return BadRequest("Vui lòng nhập ID!");
				}
				if (id == 0)
				{
					return BadRequest("Vui lòng nhập ID lớn hơn 0!");
				}
                var a = _repos.GetById(id);
                if(a == null)
                {
                    return BadRequest("Không tồn tại");
                }
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,Nhanvien nv)
        {
            try
			{
				if (id == null)
				{
					return BadRequest("Vui lòng nhập ID!");
				}
				if (id == 0)
				{
					return BadRequest("Vui lòng nhập ID lớn hơn 0!");
				}
				if (nv.Hoten==null)
				{
					return BadRequest("Vui lòng nhập họ tên!");
				}
				if (nv.Hoten.Length>100)
				{
					return BadRequest("Vui lòng nhập họ tên không quá 100 ký tự!");
				}
				if (nv.Gioitinh == null)
				{
					return BadRequest("Vui lòng chọn giới tính!");
				}
				if (nv.Sdt == null)
				{
					return BadRequest("Vui lòng nhập số điện thoại!");
				}
				if (nv.Sdt.Length != 10)
				{
					return BadRequest("Vui lòng nhập số điện thoại phải là  10 số!");
				}
				if (nv.Trangthai == null)
				{
					return BadRequest("Vui lòng chọn trạng thái!");
				}
				if (nv.Password == null)
				{
					return BadRequest("Vui lòng nhập mật khẩu!");
				}
				if (nv.Password.Length < 8 || nv.Password.Length > 50)
				{
					return BadRequest("Mật khẩu phải từ 8 đến 50 ký tự!");
				}
				if (!nv.Password.Any(char.IsUpper) || !nv.Password.Any(ch => "!@#$%^&*(),.?\"{}|<>".Contains(ch)))
				{
					return BadRequest("Mật khẩu phải có ít nhất 1 ký tự chữ viết hoa và 1 ký tự đặc biệt!");
				}
				var  checksdt = _repos.GetAll().FirstOrDefault(x=>x.Sdt==nv.Sdt);
				if (checksdt != null)
				{
					return BadRequest("Số điện thoại đã tồn tại. Vui lòng chọn số điện thoại khác!");
				}
				var a = _repos.Update(id,nv);
                if (a)
                {
                    return Ok();
				}
				if (nv.Role == null)
				{
					return BadRequest("Vui lòng chọn quyền hạn!");
				}
				return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
			{
				if (id == null)
				{
					return BadRequest("Vui lòng nhập ID!");
				}
				if (id == 0)
				{
					return BadRequest("Vui lòng nhập ID lớn hơn 0!");
				}
				var a = _repos.Delete(id);
                if (a)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Nhanvien nv)
        {
            try
			{
				if (nv.Hoten == null)
				{
					return BadRequest("Vui lòng nhập họ tên!");
				}
				if (nv.Hoten.Length > 100)
				{
					return BadRequest("Vui lòng nhập họ tên không quá 100 ký tự!");
				}
				if (nv.Gioitinh == null)
				{
					return BadRequest("Vui lòng chọn giới tính!");
				}
				if (nv.Sdt == null)
				{
					return BadRequest("Vui lòng nhập số điện thoại!");
				}
				if (nv.Sdt.Length != 10)
				{
					return BadRequest("Vui lòng nhập số điện thoại phải là  10 số!");
				}
				if (nv.Trangthai == null)
				{
					return BadRequest("Vui lòng chọn trạng thái!");
				}
				if (nv.Password == null)
				{
					return BadRequest("Vui lòng nhập mật khẩu!");
				}
				if (nv.Password.Length < 8 || nv.Password.Length > 50)
				{
					return BadRequest("Mật khẩu phải từ 8 đến 50 ký tự!");
				}
				if (!nv.Password.Any(char.IsUpper) || !nv.Password.Any(ch => "!@#$%^&*(),.?\"{}|<>".Contains(ch)))
				{
					return BadRequest("Mật khẩu phải có ít nhất 1 ký tự chữ viết hoa và 1 ký tự đặc biệt!");
				}
				var checksdt = _repos.GetAll().FirstOrDefault(x => x.Sdt == nv.Sdt);
				if (checksdt != null)
				{
					return BadRequest("Số điện thoại đã tồn tại. Vui lòng chọn số điện thoại khác!");
				}
				var a = _repos.Add(nv);
                if (a)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
		[HttpPost("login")]
		public IActionResult Login(string sdt, string password)
		{
			try
			{
				if (string.IsNullOrEmpty(sdt))
				{
					return BadRequest("Vui lòng nhập số điện thoại!");
				}
				if (sdt.Length != 10)
				{
					return BadRequest("Vui lòng nhập số điện thoại phải là 10 số!");
				}
				if (string.IsNullOrEmpty(password))
				{
					return BadRequest("Vui lòng nhập mật khẩu!");
				}
				if (password.Length < 8 || password.Length > 50)
				{
					return BadRequest("Mật khẩu phải từ 8 đến 50 ký tự!");
				}
				if (!password.Any(char.IsUpper) || !password.Any(ch => "!@#$%^&*(),.?\"{}|<>".Contains(ch)))
				{
					return BadRequest("Mật khẩu phải có ít nhất 1 ký tự chữ viết hoa và 1 ký tự đặc biệt!");
				}
				var nhanvien = _repos.GetAll().FirstOrDefault(x => x.Sdt == sdt);

				if (nhanvien == null)
				{
					return BadRequest("Số điện thoại không tồn tại!");
				}
				if (nhanvien.Password != password)
				{
					return BadRequest("Mật khẩu không chính xác!");
				}
				return Ok(new { message = "Đăng nhập thành công", nhanvienId = nhanvien.Id });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
