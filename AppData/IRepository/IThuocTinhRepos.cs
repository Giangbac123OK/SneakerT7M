using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.IRepository
{
    public interface IThuocTinhRepos
    {
        Task<IEnumerable<Thuoctinh>> GetAllAsync();
        Task<Thuoctinh> GetByIdAsync(int id);
        Task<Thuoctinh> AddAsync(Thuoctinh entity);
        Task<Thuoctinh> UpdateAsync(Thuoctinh entity);
        Task<bool> DeleteAsync(int id);
    }
}
