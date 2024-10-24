using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepositories;

namespace AppAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RankController : ControllerBase
	{
		private readonly IRankRepo _repos;
		//cmt okowww
		public RankController(IRankRepo repos)
		{
			_repos = repos;
		}
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_repos.GetAll());
		}
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			try
			{
				var a = _repos.GetByid(id);
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
		public IActionResult Post(Rank rank)
		{
			try
			{
				var a = _repos.Add(rank);
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
		public IActionResult Put(int id, Rank rank)
		{
			try
			{
				var a = _repos.Update(id, rank);
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
