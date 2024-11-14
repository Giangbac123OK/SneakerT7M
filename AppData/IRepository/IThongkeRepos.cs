using AppData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IThongkeRepos
    {
        Task<ThongkeDTO> GetThongke(string thoigian);
    }
}
