using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppAPI.IRepository
{
	public interface IphuongthucthanhtoanRepos
	{
		Task<IEnumerable<Phuongthucthanhtoan>> GetAllAsync();
		Task<Phuongthucthanhtoan> GetByIdAsync(int id);
		Task<Phuongthucthanhtoan> AddAsync(Phuongthucthanhtoan entity);
		Task<Phuongthucthanhtoan> UpdateAsync(Phuongthucthanhtoan entity);
		Task<bool> DeleteAsync(int id);

	}
}
