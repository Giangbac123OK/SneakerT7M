using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;


namespace AppData.Repositoties
{
	public class PhuongthucthanhtoanRepos : IphuongthucthanhtoanRepos
	{
		private readonly MyDbContext _context;
        public PhuongthucthanhtoanRepos(MyDbContext context)
        {
				_context = context;
        }
		

		public async Task<IEnumerable<Phuongthucthanhtoan>> GetAllAsync()
		{
			return await _context.Set<Phuongthucthanhtoan>().ToListAsync();
		}

		public async Task<Phuongthucthanhtoan> GetByIdAsync(int id)
		{
			return await _context.Set<Phuongthucthanhtoan>().FindAsync(id);
		}

		public async Task<Phuongthucthanhtoan> AddAsync(Phuongthucthanhtoan entity)
		{
			_context.Set<Phuongthucthanhtoan>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<Phuongthucthanhtoan> UpdateAsync(Phuongthucthanhtoan entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			if (entity == null) return false;

			_context.Set<Phuongthucthanhtoan>().Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
