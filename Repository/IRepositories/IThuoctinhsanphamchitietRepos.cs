using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IThuoctinhsanphamchitietRepos
    {
        List<Thuoctinhsanphamchitiet> GetAll();
        Thuoctinhsanphamchitiet GetById(int id);
        bool Add(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet);
        bool Update(int id, Thuoctinhsanphamchitiet thuoctinhsanphamchitiet);
        bool Delete(int id);
    }
}
