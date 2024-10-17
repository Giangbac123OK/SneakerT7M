using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;
using Repository.Repositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhgiaController : ControllerBase
    {
        private readonly IDanhgiaRepos _repos;
        public DanhgiaController(IDanhgiaRepos repos)
        {
            _repos = repos;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repos.GettAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_repos.GettById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Danhgia danhgia)
        {
            try
            {
                var a = _repos.Add(danhgia);
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
        [HttpPut("{id}")]
        public IActionResult Put(int id,Danhgia danhgia)
        {
            try
            {
                var a = _repos.Update(id,danhgia);
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
        [HttpDelete("{id}")]
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
