using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.IRepository
{
	public interface ISanphamchitietRepository
	{
		Task<IEnumerable<Sanphamchitiet>> GetAllAsync();
		Task<Sanphamchitiet> GetByIdAsync(int id);
		Task AddAsync(Sanphamchitiet entity);
		Task UpdateAsync(Sanphamchitiet entity);
		Task DeleteAsync(int id);
	}
}
