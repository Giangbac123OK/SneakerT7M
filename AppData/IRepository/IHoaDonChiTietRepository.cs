using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IRepository
{
    public interface IHoaDonChiTietRepository
    {
        Task<IEnumerable<Hoadonchitiet>> GetAllAsync();
        Task<Hoadonchitiet> GetByIdAsync(int id);
        Task AddAsync(Hoadonchitiet entity);
        Task UpdateAsync(Hoadonchitiet entity);
        Task DeleteAsync(int id);
    }
}
