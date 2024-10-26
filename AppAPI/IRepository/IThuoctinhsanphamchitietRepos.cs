using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppAPI.IRepository
{
    public interface IThuoctinhsanphamchitietRepos
    {
        Task<IEnumerable<Thuoctinhsanphamchitiet>> GetAllAsync();
        Task<Thuoctinhsanphamchitiet> GetByIdAsync(int id);
        Task<Thuoctinhsanphamchitiet> AddAsync(Thuoctinhsanphamchitiet entity);
        Task<Thuoctinhsanphamchitiet> UpdateAsync(Thuoctinhsanphamchitiet entity);
        Task<bool> DeleteAsync(int id);
    }
}
