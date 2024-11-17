using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
	public class SanphamchitietRepository : ISanphamchitietRepository
	{
		private readonly MyDbContext _context;

		public SanphamchitietRepository(MyDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Sanphamchitiet>> GetAllAsync()
		{
			return await _context.Sanphamchitiets
								 .Include(sp => sp.Sanpham)
								 .ToListAsync();
		}

		public async Task<Sanphamchitiet> GetByIdAsync(int id)
		{
			return await _context.Sanphamchitiets
								 .Include(sp => sp.Sanpham)
								 .FirstOrDefaultAsync(sp => sp.Id == id);
		}

		public async Task AddAsync(Sanphamchitiet entity)
		{
			await _context.Sanphamchitiets.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Sanphamchitiet entity)
		{
			_context.Sanphamchitiets.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Sanphamchitiets.FindAsync(id);
			if (entity != null)
			{
				_context.Sanphamchitiets.Remove(entity);
				await _context.SaveChangesAsync();
			}
		}

	}
}
