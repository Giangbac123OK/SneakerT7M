using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;

namespace AppData.IService
{
    public interface INhanvienService
    {
        Task<IEnumerable<NhanvienDTO>> GetAllNhanviensAsync();
        Task<NhanvienDTO> GetNhanvienByIdAsync(int id);
        Task AddNhanvienAsync(NhanvienDTO nhanvienDto);
        Task UpdateNhanvienAsync(int id, NhanvienDTO nhanvienDto);
        Task DeleteNhanvienAsync(int id);
    }
}
