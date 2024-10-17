using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiachiController : ControllerBase
    {
        private readonly IDiachiRepos _repos;
        public DiachiController(IDiachiRepos repos)
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
                var a = _repos.GetById(id);
                if (a == null)
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
        [HttpPost]
        public IActionResult Post(Diachi diachi)
        {
            try
            {
                var a = _repos.Add(diachi);
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
        [HttpPut]
        public IActionResult Put(int id,Diachi diachi)
        {
            try
            {
                var a = _repos.Update(id,diachi);
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
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
    }
}
