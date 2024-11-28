using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IRepository
{
    public interface IHoadonRepository
    {
        Task<IEnumerable<Hoadon>> GetAllAsync();
        Task<Hoadon> GetByIdAsync(int id);
        Task AddAsync(Hoadon entity);
        Task UpdateAsync(Hoadon entity);
        Task DeleteAsync(int id);
        Task<List<Hoadon>> Checkvoucher(int idspct);
    }
}
