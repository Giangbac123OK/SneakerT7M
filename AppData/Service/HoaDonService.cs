using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Service
{
    public class HoadonService : IHoadonService
    {
        private readonly IHoadonRepository _repository;
        private readonly INhanvienRepos _NVrepository;
        private readonly IKhachhangRepos _KHrepository;
        private readonly IGiamgiaRepos _GGrepository;
        public HoadonService(IHoadonRepository repository, INhanvienRepos NVrepository, IKhachhangRepos KHrepository, IGiamgiaRepos GGrepository)
        {
            _repository = repository;
            _NVrepository = NVrepository;
            _KHrepository = KHrepository;
            _GGrepository = GGrepository;
        }

        public async Task<IEnumerable<Hoadon>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();

            return entities.Select(hoaDon => new Hoadon
            {
                Id = hoaDon.Id,
                Idnv = hoaDon.Idnv,
                Idkh = hoaDon.Idkh,
                Trangthaithanhtoan = hoaDon.Trangthaithanhtoan,
                Donvitrangthai = hoaDon.Donvitrangthai,
                Thoigiandathang = hoaDon.Thoigiandathang,
                Diachiship = hoaDon.Diachiship,
                Ngaygiaodukien = hoaDon.Ngaygiaodukien,
                Ngaygiaothucte = hoaDon.Ngaygiaothucte,
                Tongtiencantra = hoaDon.Tongtiencantra,
                Tongtiensanpham = hoaDon.Tongtiensanpham,
                Sdt = hoaDon.Sdt,
                Tonggiamgia = hoaDon.Tonggiamgia,
                Idgg = hoaDon.Idgg,
                Trangthai = hoaDon.Trangthai,
            });
        }

        public async Task<Hoadon> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new Hoadon
            {
                Id = entity.Id,
                Idnv = entity.Idnv,
                Idkh = entity.Idkh,
                Diachiship = entity.Diachiship,
                Sdt = entity.Sdt,
                Idgg = entity.Idgg,
            };
        }

        public async Task AddAsync(HoaDonDTO hoaDonDTO)
        {
            // Kiểm tra xem khách hàng có tồn tại không
            var khachhang = await _KHrepository.GetByIdAsync(hoaDonDTO.Idkh);
            if (khachhang == null) throw new ArgumentNullException("Khách hàng không tồn tại");

            // Tạo đối tượng Hoadon từ DTO
            var hoaDon = new Hoadon
            {
                Idnv = hoaDonDTO.Idnv == 0 ? (int?)null : hoaDonDTO.Idnv,  // Nếu Idnv = 0, gán null
                Idkh = hoaDonDTO.Idkh,
                Trangthaithanhtoan = hoaDonDTO.Trangthaithanhtoan,
                Donvitrangthai = hoaDonDTO.Donvitrangthai,
                Thoigiandathang = hoaDonDTO.Thoigiandathang,
                Diachiship = hoaDonDTO.Diachiship,
                Ngaygiaodukien = hoaDonDTO.Ngaygiaodukien,
                Ngaygiaothucte = hoaDonDTO.Ngaygiaothucte,
                Tongtiencantra = hoaDonDTO.Tongtiencantra,
                Tongtiensanpham = hoaDonDTO.Tongtiensanpham,
                Sdt = hoaDonDTO.Sdt,
                Tonggiamgia = hoaDonDTO.Tonggiamgia,
                Idgg = hoaDonDTO.Idgg == 0 ? (int?)null : hoaDonDTO.Idgg,  // Nếu Idgg = 0, gán null
                Trangthai = hoaDonDTO.Trangthai > 0 ? 0 : 1,
            };

            // Thêm hóa đơn vào cơ sở dữ liệu
            await _repository.AddAsync(hoaDon);

            // Gán lại ID của hóa đơn từ đối tượng Hoadon vào DTO
            hoaDonDTO.Id = hoaDon.Id; // Gán ID từ Hoadon vào DTO
        }


        // Phương thức cập nhật hoá đơn
        public async Task UpdateAsync(HoaDonDTO dto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Hóa đơn không tồn tại");

            var khachhang = await _KHrepository.GetByIdAsync(dto.Idkh);
            if (khachhang == null) throw new ArgumentNullException("Khách hàng không tồn tại");

            if (entity != null)
            {
                entity.Idnv = dto.Idnv == 0 ? (int?)null : dto.Idnv;
                entity.Idkh = dto.Idkh;
                entity.Trangthaithanhtoan = dto.Trangthaithanhtoan;
                entity.Donvitrangthai = dto.Donvitrangthai;
                entity.Thoigiandathang = dto.Thoigiandathang;
                entity.Diachiship = dto.Diachiship;
                entity.Ngaygiaodukien = dto.Ngaygiaodukien;
                entity.Ngaygiaothucte = dto.Ngaygiaothucte;
                entity.Tongtiencantra = dto.Tongtiencantra;
                entity.Tongtiensanpham = dto.Tongtiensanpham;
                entity.Sdt = dto.Sdt;
                entity.Tonggiamgia = dto.Tonggiamgia;
                entity.Idgg = dto.Idgg == 0 ? (int?)null : dto.Idgg;
                entity.Trangthai = dto.Trangthai > 0 ? 0 : 1;

                await _repository.UpdateAsync(entity);
            }
        }

        // Phương thức xóa hoá đơn
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
