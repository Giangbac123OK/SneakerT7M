using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;

namespace AppData.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private readonly IHoaDonChiTietRepository _repository;
        private readonly IHoadonRepository _HDrepository;
        private readonly ISanphamchitietRepository _SPCTrepository;
        public HoaDonChiTietService(IHoaDonChiTietRepository repository, IHoadonRepository HDrepository, ISanphamchitietRepository SPCTrepository)
        {
            _repository = repository;
            _HDrepository = HDrepository;
            _SPCTrepository = SPCTrepository;
        }

        public async Task<IEnumerable<Hoadonchitiet>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();

            return entities.Select(hoaDonCT => new Hoadonchitiet
            {
                Idhd = hoaDonCT.Idhd,
                Idspct = hoaDonCT.Idspct,
                Soluong = hoaDonCT.Soluong,
                Giasp = hoaDonCT.Giasp,
                Giamgia = hoaDonCT.Giamgia,
            });
        }

        public async Task<Hoadonchitiet> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new Hoadonchitiet
            {
                Idhd = entity.Idhd,
                Idspct = entity.Idspct,
                Soluong = entity.Soluong,
                Giasp = entity.Giasp,
                Giamgia = entity.Giamgia,
            };
        }

        public async Task AddAsync(HoaDonchitietDTO hoaDonCTDTO)
        {
            var hoadon = await _HDrepository.GetByIdAsync(hoaDonCTDTO.Idhd);
            if (hoadon == null) throw new ArgumentNullException("Hoá đơn không tồn tại");

            var sanphamct = await _SPCTrepository.GetByIdAsync(hoaDonCTDTO.Idspct);
            if (sanphamct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            // Tạo đối tượng Hoadonct từ DTO
            var HoaDon = new Hoadonchitiet
            {
                Idhd = hoaDonCTDTO.Idhd,
                Idspct = hoaDonCTDTO.Idspct,
                Soluong = hoaDonCTDTO.soluong,
                Giasp = hoaDonCTDTO.Giasp,
                Giamgia = hoaDonCTDTO.giamgia,
            };

            await _repository.AddAsync(HoaDon);
        }


        // Phương thức cập nhật hoá đơn chi tiết
        public async Task UpdateAsync(HoaDonchitietDTO dto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Hóa đơn không tồn tại");

            var hoadon = await _HDrepository.GetByIdAsync(dto.Idhd);
            if (hoadon == null) throw new ArgumentNullException("Hoá đơn không tồn tại");

            var sanphamct = await _SPCTrepository.GetByIdAsync(dto.Idspct);
            if (sanphamct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            if (entity != null)
            {
                entity.Idhd = dto.Idhd;
                entity.Idspct = dto.Idspct;
                entity.Soluong = dto.soluong;
                entity.Giasp = dto.Giasp;
                entity.Giamgia = dto.giamgia;

                await _repository.UpdateAsync(entity);
            }
        }

        // Phương thức xóa hoá đơn chi tiết
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
