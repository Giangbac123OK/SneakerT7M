using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
    public interface ISanphamchitietService
    {
        Task<IEnumerable<Sanphamchitiet>> GetAllAsync();
        Task<Sanphamchitiet> GetByIdAsync(int id);
        Task<List<SanphamchitietsDTO>> GetByIdSPAsync(int idspct);
        Task<List<ThuoctinhsanphamchitietDTO>> GetByIdTTSPCTAsync(int idspct);
        Task AddAsync(SanphamchitietsDTO dto);
        Task UpdateAsync(int id, SanphamchitietsDTO dto);
        Task AddThuoctinhsanphamchitiet(ThuoctinhsanphamchitietDTO thuoctinhsanphamchitietDTO);
        Task DeleteAsync(int id);
    }
}
