using AppAPI.Dto;
using AppAPI.IRepository;
using AppAPI.IService;
using AppData.Models;
using AutoMapper;
using Humanizer;
using NuGet.Protocol.Core.Types;

namespace AppAPI.Service
{
    public class NhanvienService : INhanvienService
    {
        private readonly INhanvienRepos _repos;
        private readonly IMapper _mapper;
        public NhanvienService(INhanvienRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        public async Task<NhanvienDTO> AddAsync(NhanvienDTO nv)
        {
            var a = _mapper.Map<Nhanvien>(nv);
            await _repos.AddAsync(a);
            return _mapper.Map<NhanvienDTO>(nv);
        }

        public async Task DeleteAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<IEnumerable<NhanvienDTO>> GetAllAsync()
        {
            var a = await _repos.GetAllAsync();
            return _mapper.Map<IEnumerable<NhanvienDTO>>(a);
        }

        public async Task<NhanvienDTO> GetByIdAsync(int id)
        {
            var a = await _repos.GetByIdAsync(id);
            return _mapper.Map<NhanvienDTO>(a);
        }

        public async Task<NhanvienDTO> UpdateAsync(int id, NhanvienDTO nv)
        {
            var a = await _repos.GetByIdAsync(id);
            _mapper.Map(nv, a);
            await _repos.UpdateAsync(a);
            return _mapper.Map<NhanvienDTO>(a);
        }
    }
}
