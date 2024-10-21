using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IThuocTinhhRepos
    {
        List<Thuoctinh> GetAll();
        Thuoctinh GetById(int id);
        bool Add(Thuoctinh thuoctinh);
        bool Update(int id, Thuoctinh thuoctinh);
        bool Delete(int id);
    }
}
