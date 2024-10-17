using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface INhanvienRepos
    {
        List<Nhanvien> GetAll();
        Nhanvien GetById(int id);
        bool Add(Nhanvien nhanvien);
        bool Update(int id, Nhanvien nhanvien);
        bool Delete(int id);
    }
}
