﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public async Task AddAsync(Phuongthucthanhtoan entity)
		{
			_context.Set<Phuongthucthanhtoan>().Add(entity);
			await _context.SaveChangesAsync();
			
		}

		public async Task UpdateAsync(Phuongthucthanhtoan entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		
		}

		public async Task DeleteAsync(int id)
		{
			var phuongthucthanhtoan = await GetByIdAsync(id);
			if (phuongthucthanhtoan != null)
			{
				_context.Set<Phuongthucthanhtoan>().Remove(phuongthucthanhtoan);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new KeyNotFoundException("Không tìm thấy Phương thức thanh toán");
			}
		}
	}
}
