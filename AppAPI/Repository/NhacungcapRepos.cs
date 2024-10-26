using AppAPI.IRepository;
using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repository
{
	public class NhacungcapRepos : INhacungcapRepo
	{
		private readonly MyDbContext _context;
		public NhacungcapRepos(MyDbContext context)
		{
			_context = context;
		}
		public async Task<Nhacungcap> AddAsync(Nhacungcap ncc)
		{
			_context.nhacungcaps.AddAsync(ncc);
			await _context.SaveChangesAsync();
			return ncc;
		}

		public async Task DeleteAsync(int id)
		{
			var a = await _context.nhacungcaps.FindAsync(id);
			if (a != null)
			{
				_context.nhacungcaps.Remove(a);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Nhacungcap>> GetAllAsync()
		{
			return await _context.nhacungcaps.ToListAsync();
		}

		public async Task<Nhacungcap> GetByIdAsync(int id)
		{
			return await _context.nhacungcaps.FindAsync(id);
		}

		public async Task<Nhacungcap> UpdateAsync(Nhacungcap ncc)
		{
			_context.nhacungcaps.Update(ncc);
			await _context.SaveChangesAsync();
			return ncc;
		}
	}
}
