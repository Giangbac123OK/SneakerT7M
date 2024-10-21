using AppData.Models;

namespace AppView.IServices
{
    public interface IThuoctinhService
    {
        Task<IEnumerable<Thuoctinh>?> GetAllThuocTinhs();
        Task<Thuoctinh?> GetThuocTinhById(Guid id);
        Task Create(Thuoctinh thuoctinh);
        Task Update(Thuoctinh thuoctinh);
        Task Delete(Thuoctinh id);
    }
}
