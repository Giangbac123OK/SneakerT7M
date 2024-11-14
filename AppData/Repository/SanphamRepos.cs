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
	public class SanphamRepos : IsanphamRepos
	{
		private readonly MyDbContext _context;

		public SanphamRepos(MyDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Sanpham>> GetAllAsync() => await _context.sanphams.ToListAsync();

		public async Task<Sanpham> GetByIdAsync(int id) => await _context.sanphams.FindAsync(id);

		public async Task AddAsync(Sanpham sanpham)
		{
			if (sanpham.Soluong > 0)
				sanpham.Trangthai = 0; // Đang bán
			else
				sanpham.Trangthai = 1; // Hết hàng

			_context.sanphams.Add(sanpham);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Sanpham sanpham)
		{
			_context.sanphams.Update(sanpham);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var sanpham = await GetByIdAsync(id);
			if (sanpham != null)
			{
				_context.sanphams.Remove(sanpham);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Sanpham>> SearchByNameAsync(string name) =>
			await _context.sanphams.Where(sp => sp.Tensp.Contains(name, StringComparison.OrdinalIgnoreCase))
		.ToListAsync();
	}
}