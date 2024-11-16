using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class ThongkeService : IThongkeService
    {
        private readonly IThongkeRepos _repos;
        public ThongkeService(IThongkeRepos repos)
        {
            _repos = repos;
        }
        public async Task<ThongkeDTO> GetThongke(string thoigian)
        {
            return await _repos.GetThongke(thoigian);
        }
    }
}
