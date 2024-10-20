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
				if (nv.Password.Length > 50)
				{
					return BadRequest("Vui lòng nhập mật khẩu không quá 50 ký tự!");
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
				if (nv.Password.Length > 50)
				{
					return BadRequest("Vui lòng nhập mật khẩu không quá 50 ký tự!");
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
    }
}
