using System;
using System.Collections.Generic;
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
        public HoaDonChiTietService(IHoaDonChiTietRepository repository, IHoadonRepository HDrepository, ISanphamchitietRepos SPCTrepository, IsalechitietRepos Salerepository)
        {
            _repository = repository;
            _HDrepository = HDrepository;
            _SPCTrepository = SPCTrepository;
            _Salerepository = Salerepository;
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

        public async Task AddAsync(HoaDonchitietDTO hoaDonCTDTO)
        {
            // Kiểm tra hoá đơn có tồn tại hay không
            var hoadon = await _HDrepository.GetByIdAsync(hoaDonCTDTO.Idhd);
            if (hoadon == null) throw new ArgumentNullException("Hoá đơn không tồn tại");

            // Kiểm tra sản phẩm chi tiết có tồn tại hay không
            var sanphamct = await _SPCTrepository.GetByIdAsync(hoaDonCTDTO.Idspct);
            if (sanphamct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

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

            // Cập nhật số lượng sản phẩm chi tiết
            sanphamct.Soluong = soLuongMoi;
            await _SPCTrepository.UpdateAsync(sanphamct);

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

            // Tính toán chênh lệch số lượng
            int deltaQuantity = dto.soluong - entity.Soluong;

            // Kiểm tra và cập nhật số lượng sản phẩm chi tiết
            int newQuantity = sanphamct.Soluong - deltaQuantity;
            if (newQuantity < 0)
            {
                throw new Exception($"Không đủ hàng trong kho. Hiện tại: {sanphamct.Soluong}, yêu cầu thêm: {deltaQuantity}.");
            }
            sanphamct.Soluong = newQuantity;
            await _SPCTrepository.UpdateAsync(sanphamct);

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
