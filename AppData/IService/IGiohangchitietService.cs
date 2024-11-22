﻿using AppData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface IGiohangchitietService
    {
        Task<IEnumerable<GiohangchitietDTO>> GetAllGiohangsAsync();
        Task<GiohangchitietDTO> GetGiohangByIdAsync(int id);
        Task AddGiohangAsync(GiohangchitietDTO dto);
        Task UpdateGiohangAsync(int id, GiohangchitietDTO dto);
        Task DeleteGiohangAsync(int id);
    }
}
