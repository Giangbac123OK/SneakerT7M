using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using AppData.ViewModel;
namespace AppData.Service
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private readonly IHoaDonChiTietRepository _repository;
        private readonly IHoadonRepository _HDrepository;
        private readonly ISanphamchitietRepos _SPCTrepository;
        private readonly IsalechitietRepos _Salerepository;
        private readonly IsanphamRepos _SPrepository;

        public HoaDonChiTietService(IHoaDonChiTietRepository repository, IHoadonRepository HDrepository, ISanphamchitietRepos SPCTrepository, IsalechitietRepos Salerepository, IsanphamRepos SPrepository)
        {
            _repository = repository;
            _HDrepository = HDrepository;
            _SPCTrepository = SPCTrepository;
            _Salerepository = Salerepository;
            _SPrepository = SPrepository;
        }

        public async Task<IEnumerable<Hoadonchitiet>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();

            return entities.Select(hoaDonCT => new Hoadonchitiet
            {
                Id = hoaDonCT.Id,
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


        public async Task ReturnProductAsync(int hoadonId)
        {
            // Lấy danh sách hoá đơn chi tiết theo Id hoá đơn
            var hoadonchitietList = await _repository.HoadonchitietByIDHD(hoadonId);
            if (hoadonchitietList == null || !hoadonchitietList.Any())
                throw new ArgumentNullException(nameof(hoadonchitietList), "Không có hoá đơn chi tiết nào cho hoá đơn này");

            foreach (var hoadonchitiet in hoadonchitietList)
            {
                // Lấy thông tin sản phẩm chi tiết
                var sanphamct = await _SPCTrepository.GetByIdAsync(hoadonchitiet.Idspct);
                if (sanphamct == null) throw new ArgumentNullException($"Sản phẩm chi tiết (ID: {hoadonchitiet.Idspct}) không tồn tại");

                // Lấy thông tin sản phẩm
                var sanpham = await _SPrepository.GetByIdAsync(sanphamct.Idsp);
                if (sanpham == null) throw new ArgumentNullException($"Sản phẩm (ID: {sanphamct.Idsp}) không tồn tại");

                // Hoàn trả số lượng sản phẩm chi tiết
                sanphamct.Soluong += hoadonchitiet.Soluong;

                // Hoàn trả số lượng sản phẩm
                sanpham.Soluong += hoadonchitiet.Soluong;

                // Cập nhật sản phẩm chi tiết và sản phẩm
                await _SPCTrepository.UpdateAsync(sanphamct);
                await _SPrepository.UpdateAsync(sanpham);

                // Nếu có giảm giá, cập nhật số lượng sale
                if (hoadonchitiet.Giamgia > 0)
                {
                    var salect = await _Salerepository.GetByIdAsyncSpct(hoadonchitiet.Idspct);
                    if (salect != null)
                    {
                        salect.Soluong += hoadonchitiet.Soluong;
                        await _Salerepository.UpdateAsync(salect);
                    }
                }

            }
        }

        public async Task AddAsync(HoaDonchitietDTO hoaDonCTDTO)
        {
            // Kiểm tra hoá đơn có tồn tại hay không
            var hoadon = await _HDrepository.GetByIdAsync(hoaDonCTDTO.Idhd);
            if (hoadon == null) throw new ArgumentNullException("Hoá đơn không tồn tại");

            // Kiểm tra sản phẩm chi tiết có tồn tại hay không
            var sanphamct = await _SPCTrepository.GetByIdAsync(hoaDonCTDTO.Idspct);
            if (sanphamct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            // Kiểm tra sản phẩm có tồn tại hay không
            var sanpham = await _SPrepository.GetByIdAsync(sanphamct.Idsp);
            if (sanpham == null) throw new ArgumentNullException("Sản phẩm không tồn tại");

            // Tính số lượng còn lại
            int soLuongMoi = sanphamct.Soluong - hoaDonCTDTO.soluong;

            if (soLuongMoi < 0)
            {
                throw new Exception($"Không đủ hàng trong kho. Hiện tại: {sanphamct.Soluong}, yêu cầu: {hoaDonCTDTO.soluong}.");
            }

            if(hoaDonCTDTO.giamgia > 0)
            {
                var salect = await _Salerepository.GetByIdAsyncSpct(hoaDonCTDTO.Idspct);
                if (salect == null) throw new ArgumentNullException("Sản phẩm chi tiết này không có sale không tồn tại");
                int soluongsale = salect.Soluong - hoaDonCTDTO.soluong;

                salect.Soluong = soluongsale;
                await _Salerepository.UpdateAsync(salect);
            }

            int soluongsp = sanpham.Soluong - hoaDonCTDTO.soluong;
            if (soluongsp < 0)
            {
                throw new Exception($"Không đủ hàng trong kho. Hiện tại: {sanpham.Soluong}, yêu cầu: {hoaDonCTDTO.soluong}.");
            }

            // Cập nhật số lượng sản phẩm chi tiết
            sanphamct.Soluong = soLuongMoi;
            await _SPCTrepository.UpdateAsync(sanphamct);

            sanpham.Soluong = soluongsp;
            await _SPrepository.UpdateAsync(sanpham);


            // Tạo đối tượng Hoá đơn chi tiết từ DTO
            var HoaDon = new Hoadonchitiet
            {
                Idhd = hoaDonCTDTO.Idhd,
                Idspct = hoaDonCTDTO.Idspct,
                Soluong = hoaDonCTDTO.soluong,
                Giasp = hoaDonCTDTO.Giasp,
                Giamgia = hoaDonCTDTO.giamgia,
            };

            // Thêm hoá đơn chi tiết
            await _repository.AddAsync(HoaDon);
        }


        public async Task UpdateAsync(HoaDonchitietDTO dto, int id)
        {
            // Lấy hóa đơn chi tiết cũ từ cơ sở dữ liệu
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Hóa đơn không tồn tại");

            // Kiểm tra hóa đơn có tồn tại hay không
            var hoadon = await _HDrepository.GetByIdAsync(dto.Idhd);
            if (hoadon == null) throw new ArgumentNullException("Hoá đơn không tồn tại");

            // Kiểm tra sản phẩm chi tiết có tồn tại hay không
            var sanphamct = await _SPCTrepository.GetByIdAsync(dto.Idspct);
            if (sanphamct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            // Cập nhật thông tin hóa đơn chi tiết
            entity.Idhd = dto.Idhd;
            entity.Idspct = dto.Idspct;
            entity.Soluong = dto.soluong;
            entity.Giasp = dto.Giasp;
            entity.Giamgia = dto.giamgia;

            // Lưu thay đổi hóa đơn chi tiết
            await _repository.UpdateAsync(entity);
        }

        // Phương thức xóa hoá đơn chi tiết
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<HoadonchitietViewModel>> HoadonchitietTheoMaHD(int id)
        {
            return await _repository.HoadonchitietTheoMaHD(id);
        }
    }

}
