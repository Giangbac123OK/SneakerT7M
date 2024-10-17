using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IDiachiRepos
    {
        List<Diachi> GetAll();
        Diachi GetById(int id);
        bool Add(Diachi diachi);
        bool Update(int id,Diachi diachi);
        bool Delete(int id);
    }
}
