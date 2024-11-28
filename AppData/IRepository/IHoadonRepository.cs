﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;
using AppData.ViewModel;

namespace AppData.IRepository
{
    public interface IHoadonRepository
    {
        Task<IEnumerable<Hoadon>> GetAllAsync();
        Task<Hoadon> GetByIdAsync(int id);
        Task AddAsync(Hoadon entity);
        Task UpdateAsync(Hoadon entity);
        Task DeleteAsync(int id);
        Task<List<HoaDonViewModel>> TimhoadontheoIdKH(int id);//ass
    }
}
