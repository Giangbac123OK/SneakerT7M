using AppData.Models;

namespace AppData.IRepository
{
    public interface ISanphamchitietRepos
    {
        Task<IEnumerable<Sanphamchitiet>> GetAllAsync();
        Task<Sanphamchitiet> GetByIdAsync(int id);
        Task<List<Sanphamchitiet>> GetByIdSPAsync(int idsp);
        Task<List<Thuoctinhsanphamchitiet>> GetByIdTTSPCTAsync(int idspct);
        Task<Sanphamchitiet> AddAsync(Sanphamchitiet entity);
        Task<Sanphamchitiet> UpdateAsync(Sanphamchitiet entity);
        Task AddThuoctinhsanphamchitiet (int idsptt, int idtt, List<string> Tenthuoctinhchitiet);
        Task DeleteAsync(int id);
    }
}
