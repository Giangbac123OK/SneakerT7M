﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
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
			else
			{
				throw new KeyNotFoundException("Không tìm thấy mã giảm giá");
			}
		}

		public async Task AddRankToGiamgia(int giamgiaId, List<string> rankNames)
		{
			var giamgia = await _context.giamgias.FindAsync(giamgiaId);
			if (giamgia == null) throw new Exception("Giảm giá không tồn tại");

			foreach (var rankName in rankNames)
			{
				var rank = await _context.ranks.FirstOrDefaultAsync(r => r.tenrank == rankName);
				if (rank != null)
				{
					var giamgiaRank = new giamgia_rank { IDgiamgia = giamgiaId, Idrank = rank.id };
					_context.giamgia_Ranks.Add(giamgiaRank);
				}
			}

			await _context.SaveChangesAsync();
		}
	}
}
