using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData;
using AppData.Models;
using AppData.Dto;
using AppData.IService;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhanhController : ControllerBase
    {
        private readonly IHinhanhService _ser;

        public HinhanhController(IHinhanhService context)
        {
            _ser = context;
        }

        // GET: api/Hinhanh
        [HttpGet]
        public async Task<IActionResult> Gethinhanhs()
        {
            try
            {
                return Ok(await _ser.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Hinhanh/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHinhanh(int id)
        {
            try
            {
                return Ok(await _ser.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Hinhanh/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHinhanh(int id, HinhanhDTO hinhanh)
        {
            try
            {
                await _ser.Update(id, hinhanh);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Hinhanh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostHinhanh(HinhanhDTO hinhanh)
        {
            try
            {
                await _ser.Add(hinhanh);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Hinhanh/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHinhanh(int id)
        {
            try
            {
                await _ser.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
