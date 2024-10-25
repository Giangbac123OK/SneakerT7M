using AppAPI.Dto;
using AppData.Models;

namespace AppAPI.IService
{
    public interface INhanvienService
    {
        Task<IEnumerable<NhanvienDTO>> GetAllAsync();
        Task<NhanvienDTO> GetByIdAsync(int id);
        Task<NhanvienDTO> AddAsync(NhanvienDTO nv);
        Task<NhanvienDTO> UpdateAsync(int id,NhanvienDTO nv);
        Task DeleteAsync(int id);
    }
}
