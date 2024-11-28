﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

using AppData.ViewModel;
namespace AppData.IService
{
    public interface IHoadonService
    {
        Task<IEnumerable<Hoadon>> GetAllAsync();
		    Task<Hoadon> GetByIdAsync(int id);
		    Task AddAsync(HoaDonDTO dto);
		    Task UpdateAsync(HoaDonDTO dto, int id);
		    Task DeleteAsync(int id);
        Task<List<HoaDonDTO>> Checkvoucher(int idspct);
        Task<List<HoaDonViewModel>> TimhoadontheoIdKH(int id);
    }
}
