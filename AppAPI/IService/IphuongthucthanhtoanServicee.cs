using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Dto;

namespace AppAPI.IService
{
	public interface IphuongthucthanhtoanServicee
	{
		Task<IEnumerable<PhuongthucthanhtoanDTO>> GetAllAsync();
		Task<PhuongthucthanhtoanDTO> GetByIdAsync(int id);
		Task<PhuongthucthanhtoanDTO> AddAsync(PhuongthucthanhtoanDTO dto);
		Task<PhuongthucthanhtoanDTO> UpdateAsync(int id, PhuongthucthanhtoanDTO dto);
		Task<bool> DeleteAsync(int id);
	}
}
