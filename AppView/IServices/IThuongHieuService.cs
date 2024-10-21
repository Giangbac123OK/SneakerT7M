using System.Drawing;
using AppData.Models;

namespace AppView.IServices
{
    public interface IThuongHieuService
    {
        Task<IEnumerable<Thuonghieu>?> GetAllThuongHieus();
        Task<Thuonghieu?> GetThuongHieuById(Guid id);
        Task Create(Thuonghieu thuonghieu);
        Task Update(Thuonghieu thuonghieu);
        Task Delete(Thuonghieu id);
    }
}
