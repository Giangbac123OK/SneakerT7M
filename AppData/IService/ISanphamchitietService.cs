using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
	public interface ISanphamchitietService
	{
		Task<IEnumerable<Sanphamchitiet>> GetAllAsync();
		Task<Sanphamchitiet> GetByIdAsync(int id);
		Task AddAsync(SanphamchitietDto dto);
		Task UpdateAsync(SanphamchitietDto dto, int id);
		Task DeleteAsync(int id);
	}
}
