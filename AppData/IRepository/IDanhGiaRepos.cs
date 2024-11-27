﻿using AppData.Dto;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface IDanhGiaRepos
    {
        Task<List<Danhgia>> GetAll();
        Task <Danhgia> GetById(int id);
        Task Create(Danhgia danhgia);
        Task Update(Danhgia danhgia);
        Task Delete(int id);
        Task<Danhgia> getByidHDCT(int id);
        Task SaveChanges();
        Task<List<LichSuMuaHangDTO>> lichSuMuaHangDTOs(int idkh);
        Task<List<Danhgia>> GetByidSPCT(List<int> ids);
    }
}
