using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;

namespace AppData.IService
{
    public interface IThuoctinhService
    {
        Task<IEnumerable<ThuoctinhDTO>> GetAllAsync();
        Task<ThuoctinhDTO> GetByIdAsync(int id);
        Task<ThuoctinhDTO> AddAsync(ThuoctinhDTO dto);
        Task<ThuoctinhDTO> UpdateAsync(int id, ThuoctinhDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
