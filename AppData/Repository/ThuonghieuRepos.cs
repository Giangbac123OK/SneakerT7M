using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
	public class ThuonghieuRepos:IThuonghieuRepos
	{
        private readonly MyDbContext _context;
        public ThuonghieuRepos(MyDbContext context)
        {
			_context=context;

		}
		public async Task<IEnumerable<Thuonghieu>> GetAllAsync()
		{
			return await _context.thuonghieus.ToListAsync();
		}

		public async Task<IEnumerable<ThuonghieuDTO>> GetAllDtoAsync()
		{
			return await _context.thuonghieus
				.Select(th => new ThuonghieuDTO
				{
					Tenthuonghieu = th.Tenthuonghieu
				}).ToListAsync();
		}

		public async Task<Thuonghieu> GetByIdAsync(int id)
		{
			return await _context.thuonghieus.FindAsync(id);
		}

		public async Task AddAsync(Thuonghieu thuonghieu)
		{
			_context.thuonghieus.Add(thuonghieu);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Thuonghieu thuonghieu)
		{
			_context.thuonghieus.Update(thuonghieu);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var thuonghieu = await GetByIdAsync(id);
			if (thuonghieu != null)
			{
				_context.thuonghieus.Remove(thuonghieu);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<ThuonghieuDTO>> SearchByNameAsync(string name)
		{
			return await _context.thuonghieus
				.Where(th => th.Tenthuonghieu.Contains(name))
				.Select(th => new ThuonghieuDTO
				{
					Tenthuonghieu = th.Tenthuonghieu
				}).ToListAsync();
		}
	}
}
