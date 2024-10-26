using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Dto;

namespace AppAPI.IService
{
    public interface IThuoctinhsanphamchitietService
    {
        Task<IEnumerable<ThuoctinhsanphamchitietDTO>> GetAllAsync();
        Task<ThuoctinhsanphamchitietDTO> GetByIdAsync(int id);
        Task<ThuoctinhsanphamchitietDTO> AddAsync(ThuoctinhsanphamchitietDTO dto);
        Task<ThuoctinhsanphamchitietDTO> UpdateAsync(int id, ThuoctinhsanphamchitietDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
