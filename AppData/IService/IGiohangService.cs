﻿using AppData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface IGiohangService
    {
        Task<IEnumerable<GiohangDTO>> GetAllGiohangsAsync();
        Task<GiohangDTO> GetGiohangByIdAsync(int id);
        Task AddGiohangAsync(GiohangDTO dto);
        Task UpdateGiohangAsync(int id, GiohangDTO dto);
        Task DeleteGiohangAsync(int id);
    }
}