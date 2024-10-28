using AppData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface IKhachhangService
    {
        Task<IEnumerable<KhachhangDTO>> GetAllKhachhangsAsync();
        Task<KhachhangDTO> GetKhachhangByIdAsync(int id);
        Task AddKhachhangAsync(KhachhangDTO dto);
        Task UpdateKhachhangAsync(int id, KhachhangDTO dto);
        Task DeleteKhachhangAsync(int id);
    }
}
