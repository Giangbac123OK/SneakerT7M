using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Dto;

namespace AppAPI.IService
{
	public interface IGiamgiaService
	{
		Task<IEnumerable<GiamgiaDTO>> GetAllAsync();
		Task<GiamgiaDTO> GetByIdAsync(int id);
		Task<GiamgiaDTO> AddAsync(GiamgiaDTO dto);
		Task<GiamgiaDTO> UpdateAsync(int id, GiamgiaDTO dto);
		Task DeleteAsync(int id);
	}
}
