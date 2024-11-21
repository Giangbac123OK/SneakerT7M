using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;

namespace AppData.IService
{
    public interface ISanphamchitietService
    {
        Task<IEnumerable<SanphamchitietsDTO>> GetAllAsync();
        Task<SanphamchitietsDTO> GetByIdAsync(int id);
        Task AddAsync(SanphamchitietsDTO dto);
        Task UpdateAsync(int id, SanphamchitietsDTO dto);
        Task AddThuoctinhsanphamchitiet(ThuoctinhsanphamchitietDTO thuoctinhsanphamchitietDTO);
        Task DeleteAsync(int id);
    }
}
