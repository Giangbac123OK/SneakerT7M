using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IDiaChiRepos
    {
        Task<IEnumerable<Diachi>> GetAllDiaChi();
        Task<Diachi> GetDiaChiById(int id);
        Task Create(Diachi diachi);
        Task Delete(int id);
        Task Update( Diachi diachi);
        Task SaveChanges();
    }
}
