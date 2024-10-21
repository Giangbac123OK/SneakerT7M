using AppData.Models;

namespace AppView.IServices
{
    public interface IThuoctinhsanphamchitietService
    {
        Task<IEnumerable<Thuoctinhsanphamchitiet>?> GetAllThuocTinhSanPhamChiTiets();
        Task<Thuoctinhsanphamchitiet?> GetThuocTinhSanPhamChiTietById(Guid id);
        Task Create(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet);
        Task Update(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet);
        Task Delete(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet);
    }
}
