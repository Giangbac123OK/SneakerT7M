using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepos _SaleRepos;

        public SaleController(ISaleRepos saleRepos)
        {
            _SaleRepos = saleRepos;
        }


        // GET: api/<SaleController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSaleAll()
        {
            try
            {
               var sales =   await _SaleRepos.GetAllSale();
               return Ok(sales);

            }catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSaleById(int id)
        {
            try
            {
                var sales = await _SaleRepos.GetSaleByID(id);
                return Ok(sales);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST api/<SaleController>
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            try
            {
                await _SaleRepos.create(sale);
                await _SaleRepos.SaveChanges();
                return Ok(sale);

            }catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }


        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale( [FromBody] Sale sale)
        {
            try
            {
                var item = await _SaleRepos.GetSaleByID(sale.Id);
                await _SaleRepos.update(item);
                await _SaleRepos.SaveChanges();
                return Ok(item);

            }catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _SaleRepos.delete(id);
                await _SaleRepos.SaveChanges();
                return Ok();

            }catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
