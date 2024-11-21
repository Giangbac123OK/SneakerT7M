using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;

namespace AppData.IService
{
    public interface IThuoctinhService
    {
        Task<IEnumerable<ThuoctinhDTO>> GetAll();
        Task<Thuoctinh> GetById(int id);
        Task Add(ThuoctinhDTO thuoctinhDto);
        Task Update(int id, ThuoctinhDTO thuoctinhDto);
        Task Delete(int id);
    }
}
