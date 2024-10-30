using AppData.Models;

namespace AppAPI.IRepository
{
    public interface ISanphamchitietRepos
    {
        Task<IEnumerable<Sanphamchitiet>> GetAllAsync();
        Task<Sanphamchitiet> GetByIdAsync(int id);
        Task<Sanphamchitiet> AddAsync(Sanphamchitiet entity);
        Task<Sanphamchitiet> UpdateAsync(Sanphamchitiet entity);
        Task AddThuoctinhsanphamchitiet (int idsptt, int idtt, List<string> Tenthuoctinhchitiet);
        Task DeleteAsync(int id);
    }
}
