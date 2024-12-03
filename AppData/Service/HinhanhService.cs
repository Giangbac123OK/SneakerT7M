using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class HinhanhService : IHinhanhService
    {
        IHinhanhRepos _repos;
        public HinhanhService(IHinhanhRepos repos)
        {
            _repos = repos;
        }
        public async Task Add(HinhanhDTO hinhanh)
        {
            var a = new Hinhanh 
            { 
                Id = hinhanh.Id,
                Urlhinhanh = hinhanh.Urlhinhanh,
                Idth = hinhanh.Idth
            };
            await _repos.Add(a);
        }

        public async Task DeleteById(int id)
        {
            await _repos.DeleteById(id);
        }

        public async Task<List<HinhanhDTO>> GetAll()
        {
            var a = await _repos.GetAll();
            return a.Select(x => new HinhanhDTO
            {
                Id = x.Id,
                Idth = x.Idth,
                Urlhinhanh = x.Urlhinhanh
            }).ToList();
        }

        public async Task<HinhanhDTO> GetById(int id)
        {
            var x = await _repos.GetById(id);
            return new HinhanhDTO
            {
                Id = x.Id,
                Idth = x.Idth,
                Urlhinhanh = x.Urlhinhanh
            };
        }

        public async Task Update(int id, HinhanhDTO hinhanh)
        {
            var a = await _repos.GetById(id);
            if(a == null)
            {
                throw new KeyNotFoundException("khong tim thay id");
            }
            else
            {
                a.Urlhinhanh = hinhanh.Urlhinhanh;
                a.Idth = hinhanh.Idth;
                await _repos.Update(a);
            }
        }
    }
}
