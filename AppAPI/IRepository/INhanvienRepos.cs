using AppData.Models;

namespace AppAPI.IRepository
{
    public interface INhanvienRepos
    {
        Task<IEnumerable<Nhanvien>> GetAllAsync();
        Task<Nhanvien> GetByIdAsync(int id);
        Task<Nhanvien> AddAsync(Nhanvien nv);
        Task<Nhanvien> UpdateAsync(Nhanvien nv);
        Task DeleteAsync(int id);
    }
}
