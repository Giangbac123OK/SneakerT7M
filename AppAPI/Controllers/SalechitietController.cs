using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalechitietController : ControllerBase
    {
        private readonly ISaleChiTietRepos _saleChiTietRepos;

        public SalechitietController(ISaleChiTietRepos saleChiTietRepos)
        {
            _saleChiTietRepos = saleChiTietRepos;
        }



        // GET: api/<SalechitietController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salechitiet>>> GetAllSalechitiet()
        {
            try
            {
                var saleChiTiet = await _saleChiTietRepos.GetAllSaleChiTiet();
                return Ok(saleChiTiet);

            } catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<SalechitietController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salechitiet>> GetSalechitietByid(int id)
        {
            try
            {
                var saleChitiet = await _saleChiTietRepos.GetSaleChiTietByID(id);
                return Ok(saleChitiet);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

            // POST api/<SalechitietController>
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSaleChitiet([FromBody] Salechitiet salechitiet)
        {
            try
            {
                await _saleChiTietRepos.create(salechitiet);
                await _saleChiTietRepos.SaveChanges();
                return Ok(salechitiet);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

            // PUT api/<SalechitietController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleChiTiet( [FromBody] Salechitiet salechitiet)
        {
            try
            {
                await _saleChiTietRepos.GetSaleChiTietByID(salechitiet.Id);
                await _saleChiTietRepos.update(salechitiet);
                await _saleChiTietRepos.SaveChanges();
                return Ok(salechitiet);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

            // DELETE api/<SalechitietController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _saleChiTietRepos.delete(id);
                await _saleChiTietRepos.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}


