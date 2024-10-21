using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData;
using AppData.Models;
using Repository.IRepositories;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuoctinhsController : ControllerBase
    {
        private readonly IThuocTinhhRepos _repos;

        public ThuoctinhsController(IThuocTinhhRepos repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetAll()
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
        public IActionResult GetById(int id)
        {
            try
            {
                var a = _repos.GetById(id);
                if (a == null)
                {
                    return BadRequest("Thuộc tính không tồn tại");
                }
                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Thuoctinh thuoctinh)
        {
            try
            {
                var a = _repos.Update(id, thuoctinh);
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

        [HttpPost]
        public IActionResult Add(Thuoctinh thuoctinh)
        {
            try
            {
                var a = _repos.Add(thuoctinh);
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
