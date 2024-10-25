using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.IRepository;
using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repositoties
{
	public class GiamgiaRepos:IGiamgiaRepos
	{
		private readonly MyDbContext _context;
        public GiamgiaRepos(MyDbContext context)
        {
            _context = context;
        }
		public async Task<IEnumerable<Giamgia>> GetAllAsync()
		{
			return await _context.giamgias.ToListAsync();
		}

		public async Task<Giamgia> GetByIdAsync(int id)
		{
			return await _context.giamgias.FindAsync(id);
		}

		public async Task<Giamgia> AddAsync(Giamgia giamgia)
		{
			_context.giamgias.Add(giamgia);
			await _context.SaveChangesAsync();
			return giamgia;
		}

		public async Task<Giamgia> UpdateAsync(Giamgia giamgia)
		{
			_context.giamgias.Update(giamgia);
			await _context.SaveChangesAsync();
			return giamgia;
		}

		public async Task DeleteAsync(int id)
		{
			var giamgia = await _context.giamgias.FindAsync(id);
			if (giamgia != null)
			{
				_context.giamgias.Remove(giamgia);
				await _context.SaveChangesAsync();
			}
		}

	}
}
