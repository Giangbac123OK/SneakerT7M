using AppData.Dto;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface IHinhanhService
    {
        Task<List<HinhanhDTO>> GetAll();
        Task<HinhanhDTO> GetById(int id);
        Task Add(HinhanhDTO hinhanh);
        Task Update(int id,HinhanhDTO hinhanh);
        Task DeleteById(int id);
    }
}
