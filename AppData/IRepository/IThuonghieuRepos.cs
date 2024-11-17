using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IRepository
{
	public interface IThuonghieuRepos
	{
		Task<IEnumerable<Thuonghieu>> GetAllAsync(); // Lấy tất cả thương hiệu với Id
		Task<IEnumerable<ThuonghieuDTO>> GetAllDtoAsync(); // Lấy tất cả thương hiệu mà không có Id
		Task<Thuonghieu> GetByIdAsync(int id);
		Task AddAsync(Thuonghieu thuonghieu);
		Task UpdateAsync(Thuonghieu thuonghieu);
		Task DeleteAsync(int id);
		Task<IEnumerable<ThuonghieuDTO>> SearchByNameAsync(string name);
	}
}
