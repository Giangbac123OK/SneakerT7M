using AppData.Dto;
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
    public class DiaChiService : IDiaChiService
    {
        private readonly IDiaChiRepos diaChiRepos;

        public DiaChiService(IDiaChiRepos diaChiRepos)
        {
            this.diaChiRepos = diaChiRepos;
        }

        public async Task Create(DiaChiDTO diachi)
        {
              var Diachi = new Diachi()
                {
                    Thanhpho = diachi.Thanhpho,
                    Idkh = diachi.Idkh,
                    Diachicuthe = diachi.Diachicuthe,
                    Quanhuyen = diachi.Quanhuyen,
                    Phuongxa = diachi.Phuongxa,

                };
                await diaChiRepos.Create(Diachi);
                await diaChiRepos.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await diaChiRepos.Delete(id);
            await diaChiRepos.SaveChanges();
        }

        public async Task<IEnumerable<DiaChiDTO>> GetAllDiaChi()
        {
            var diaChis = await diaChiRepos.GetAllDiaChi();
            return diaChis.Select(diaChis => new DiaChiDTO()
            {
                Diachicuthe = diaChis.Diachicuthe,
                Thanhpho = diaChis.Thanhpho,
                Phuongxa = diaChis.Phuongxa,
                Quanhuyen = diaChis.Quanhuyen,
                Idkh = diaChis.Idkh,

            });
        }

        public async Task<DiaChiDTO> GetDiaChiById(int id)
        {
            var diaChi = await diaChiRepos.GetDiaChiById(id);
            if (diaChi == null) throw new KeyNotFoundException("Không tìm thấy Dịa chỉ");
            return new DiaChiDTO()
            {
                Diachicuthe = diaChi.Diachicuthe,
                Thanhpho = diaChi.Thanhpho,
                Phuongxa = diaChi.Phuongxa,
                Quanhuyen = diaChi.Quanhuyen,
                Idkh = diaChi.Idkh,
            };
        }

        public async Task Update(int id, DiaChiDTO diaChiDTO)
        {
            var diaChi = await diaChiRepos.GetDiaChiById(id);
            diaChi.Quanhuyen= diaChiDTO.Quanhuyen;
            diaChi.Thanhpho = diaChiDTO.Thanhpho;
            diaChi.Diachicuthe = diaChiDTO.Diachicuthe;
            diaChi.Idkh = diaChiDTO.Idkh;
            diaChi.Phuongxa = diaChiDTO.Phuongxa;
            await diaChiRepos.Update(diaChi);
            await diaChiRepos.SaveChanges();
        }
    }
}
