using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;
namespace Repository.IRepositories
{
    public interface IDanhgiaRepos
    {
        List<Danhgia> GettAll();
        Danhgia GettById(int id);
        bool Add(Danhgia danhgia);
        bool Update(int id, Danhgia danhgia);
        bool Delete(int id);
    }
}
