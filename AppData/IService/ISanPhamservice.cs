﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
	public interface ISanPhamservice
	{
		Task<IEnumerable<Sanpham>> GetAllAsync();
		Task<SanphamDTO> GetByIdAsync(int id);
		Task AddAsync(SanphamDTO sanphamDto);
		Task UpdateAsync(int id, SanphamDTO sanphamDto);
		Task DeleteAsync(int id);
		Task UpdateStatusToCancelled(int id);
		Task UpdateStatusLoad(int id);
		Task<IEnumerable<SanphamDTO>> SearchByNameAsync(string name);
	}
}