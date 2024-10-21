using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IThuongHieuRepos
    {
        List<Thuonghieu> GetAll();
        Thuonghieu GetById(int id);
        bool Add(Thuonghieu thuonghieu);
        bool Update(int id, Thuonghieu thuonghieu);
        bool Delete(int id);
    }
}
