using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppData;
using AppData.Models;
using AppData.IService;
using AppData.Dto;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoadonnhapsController : ControllerBase
    {
        private readonly IHoadonnhapService _services;

        public HoadonnhapsController(IHoadonnhapService services)
        {
            _services = services;
        }



        // GET: api/Hoadonnhaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoadonnhapDTO>>> Gethoadonnhaps()
        {
            try
            {
                var listHoaDon = await _services.GetHoadonnhapListAsync();
                return Ok(listHoaDon);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Hoadonnhaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HoadonnhapDTO>> GetHoadonnhap(int id)
        {

            var hoadonnhap = await _services.GetHoadonnhapById(id);

            if (hoadonnhap == null)
            {
                return NotFound();
            }

            return hoadonnhap;
        }

        // PUT: api/Hoadonnhaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoadonnhap(int id, HoadonnhapDTO hoadonnhap)
        {
          
            try
            {
                await _services.Update(id, hoadonnhap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        // POST: api/Hoadonnhaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hoadonnhap>> PostHoadonnhap(HoadonnhapDTO hoadonnhap)
        {
            try
            {
                await _services.Create(hoadonnhap);
                return Ok();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

        // DELETE: api/Hoadonnhaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoadonnhap(int id)
        {
            try
            {
                await _services.Delete(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

       ]
    }
}
