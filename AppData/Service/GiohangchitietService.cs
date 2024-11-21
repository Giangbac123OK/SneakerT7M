﻿using AppData.Dto;
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
    public class GiohangchitietService : IGiohangchitietService
    {
        private readonly IGiohangchitietRepos _repos;
        public GiohangchitietService(IGiohangchitietRepos repos)
        {
            _repos = repos;
        }
        public async Task AddGiohangAsync(GiohangchitietDTO dto)
        {
            var gh = new Giohangchitiet()
            {
                Idgh = dto.Idgh,
                Idspct = dto.Idspct,
                Soluong = dto.Soluong
            };
            await _repos.AddAsync(gh);
        }

        public async Task DeleteGiohangAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<IEnumerable<GiohangchitietDTO>> GetAllGiohangsAsync()
        {
            var a = await _repos.GetAllAsync();
            return a.Select(x => new GiohangchitietDTO()
            {
                Idspct = x.Idspct,
                Idgh = x.Idgh,
                Soluong = x.Soluong
            });
        }

        public async Task<GiohangchitietDTO> GetGiohangByIdAsync(int id)
        {
            var a = await _repos.GetByIdAsync(id);
            return new GiohangchitietDTO()
            {
                Idspct = a.Idspct,
                Idgh = a.Idgh,
                Soluong = a.Soluong
            };
        }

        public async Task UpdateGiohangAsync(int id, GiohangchitietDTO dto)
        {
            var a = await _repos.GetByIdAsync(id);
            if (a == null) throw new KeyNotFoundException("Giỏ hàng không tồn tại.");
            a.Soluong = dto.Soluong;
            a.Idgh = dto.Idgh;
            a.Idspct = dto.Idspct;
            await _repos.UpdateAsync(a);
        }
    }
}