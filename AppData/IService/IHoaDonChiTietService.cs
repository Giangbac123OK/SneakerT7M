using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
    public interface IHoaDonChiTietService
    {
        Task<IEnumerable<Hoadonchitiet>> GetAllAsync();
        Task<Hoadonchitiet> GetByIdAsync(int id);
        Task AddAsync(HoaDonchitietDTO dto);
        Task UpdateAsync(HoaDonchitietDTO dto, int id);
        Task DeleteAsync(int id);
    }
}
