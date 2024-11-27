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
    public class TraHangChiTietService : ITraHangChiTietService
    {
        private readonly ITraHangChiTietRepos _repos;
        public TraHangChiTietService(ITraHangChiTietRepos repos)
        {
            _repos = repos;
        }

        public async Task Add(TraHangChiTietDTO ct)
        {
            var a = new Trahangchitiet
            {
                Idth = ct.Idth,
                Soluong = ct.Soluong,
                Tinhtrang = ct.Tinhtrang,
                Ghichu = ct.Ghichu,
                Hinhthucxuly = ct.Hinhthucxuly,
                Idhdct = ct.Idhdct
            };
            await _repos.Add(a);
        }

        public async Task Delete(int id)
        {
            await _repos.Delete(id);
        }

        public async Task<List<TraHangChiTietDTO>> GetAll()
        {
            var a = await _repos.GetAll();
            return a.Select(x => new TraHangChiTietDTO 
            { 
                Id = x.Id,
                Idth = x.Idth,
                Soluong = x.Soluong,
                Tinhtrang = x.Tinhtrang,
                Ghichu = x.Ghichu,
                Hinhthucxuly = x.Hinhthucxuly,
                Idhdct = x.Idhdct
            }).ToList();
        }

        public async Task<TraHangChiTietDTO> GetById(int id)
        {
            var x = await _repos.GetById(id);
            return new TraHangChiTietDTO
            {
                Id = x.Id,
                Idth = x.Idth,
                Soluong = x.Soluong,
                Tinhtrang = x.Tinhtrang,
                Ghichu = x.Ghichu,
                Hinhthucxuly = x.Hinhthucxuly,
                Idhdct = x.Idhdct
            };
        }

        public async Task<List<TraHangChiTietDTO>> GetByMaHD(int id)
        {
            var a = await _repos.GetByMaHD(id);
            return a.Select(x => new TraHangChiTietDTO
            {
                Id = x.Id,
                Idth = x.Idth,
                Soluong = x.Soluong,
                Tinhtrang = x.Tinhtrang,
                Ghichu = x.Ghichu,
                Hinhthucxuly = x.Hinhthucxuly,
                Idhdct = x.Idhdct
            }).ToList();
        }

        public async Task Update(int id,TraHangChiTietDTO ct)
        {
            var a = await _repos.GetById(id);
            if (a != null)
            {
                a.Idth = ct.Idth;
                a.Soluong = ct.Soluong;
                a.Tinhtrang = ct.Tinhtrang;
                a.Ghichu = ct.Ghichu;
                a.Hinhthucxuly = ct.Hinhthucxuly;
                a.Idhdct = ct.Idhdct;
                await _repos.Update(a);
            }
            else
            {
                throw new KeyNotFoundException("Không tồn tại!");
            }
        }
    }
}
