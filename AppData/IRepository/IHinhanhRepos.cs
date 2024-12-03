using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IHinhanhRepos
    {
        Task<List<Hinhanh>> GetAll();
        Task<Hinhanh> GetById(int id);
        Task Add(Hinhanh hinhanh);
        Task Update(Hinhanh hinhanh);
        Task DeleteById(int id);
    }
}
