using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IKhachhangRepos
    {
        List<Khachhang> GetAll();
        Khachhang Get(int id);
        bool Add(Khachhang kh);
        bool Update(int id,Khachhang kh);
        bool Delete(int id);
    }
}
