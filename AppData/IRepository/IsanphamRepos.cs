﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.IRepository
{
	public interface IsanphamRepos
	{
		Task<IEnumerable<Sanpham>> GetAllAsync();
		Task<Sanpham> GetByIdAsync(int id);
		Task AddAsync(Sanpham sanpham);
		Task UpdateAsync(Sanpham sanpham);
		Task DeleteAsync(int id);
		Task<IEnumerable<Sanpham>> SearchByNameAsync(string name);
	}
}