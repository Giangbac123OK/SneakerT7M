﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
	public interface IthuonghieuService
	{
		Task<IEnumerable<Thuonghieu>> GetAllAsync(); // Trả về danh sách thương hiệu
		Task<ThuonghieuDTO> GetByIdAsync(int id);
		Task AddAsync(ThuonghieuDTO thuonghieuDto);
		Task UpdateAsync(int id, ThuonghieuDTO thuonghieuDto);
		Task DeleteAsync(int id);
		Task<IEnumerable<ThuonghieuDTO>> SearchByNameAsync(string name);

	}
}
