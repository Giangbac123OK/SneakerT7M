using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.IRepository;
using AppData.Models;
using AppData.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
    public class SanphamRepos : IsanphamRepos
    {
        private readonly MyDbContext _context;

        public SanphamRepos(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Sanpham>> GetAllAsync() => await _context.sanphams.ToListAsync();

        public async Task<Sanpham> GetByIdAsync(int id) => await _context.sanphams.FindAsync(id);

        public async Task AddAsync(Sanpham sanpham)
        {
            if (sanpham.Soluong > 0)
                sanpham.Trangthai = 0; // Đang bán
            else
                sanpham.Trangthai = 1; // Hết hàng

            _context.sanphams.Add(sanpham);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sanpham sanpham)
        {
            _context.sanphams.Update(sanpham);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sanpham = await GetByIdAsync(id);
            if (sanpham != null)
            {
                _context.sanphams.Remove(sanpham);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Sanpham>> SearchByNameAsync(string name) =>
            await _context.sanphams.Where(sp => sp.Tensp.ToLower().StartsWith(name.ToLower()) && sp.Soluong > 0)
        .ToListAsync();

        public async Task<IEnumerable<SanphamViewModel>> GetAllSanphamViewModels()
        {

            var sanphams = await _context.sanphams
          .Include(sp => sp.Sanphamchitiets)
          .ThenInclude(spct => spct.Salechitiets)
            .Include(sp => sp.Thuonghieu)
            .Where(sp => sp.Trangthai != 2)
          .ToListAsync();
            // Ánh xạ dữ liệu sang ViewModel
            var sanphamViewModels = sanphams.Select(sp => new SanphamViewModel
            {
                Id = sp.Id,
                Tensp = sp.Tensp,
                Giaban = sp.Giaban,
                Soluong = sp.Soluong,
                URlHinhAnh = sp.UrlHinhanh,
                ThuongHieu = sp.Thuonghieu?.Tenthuonghieu ?? "N/A",
                idThuongHieu = sp.Idth,
                Giasale = sp.Sanphamchitiets
                       .SelectMany(spct => spct.Salechitiets, (spct, salect) => spct.Giathoidiemhientai - salect.Giatrigiam)
                       .DefaultIfEmpty(sp.Giaban) // Nếu không có giá trị nào, giữ giá mặc định
                       .Min() // Lấy giá trị nhỏ nhất// Kiểm tra null và sử dụng giá bán gốc nếu không có giảm giá
            }).ToList() ?? new List<SanphamViewModel>();  // Nếu sanphams là null thì dùng danh sách rỗng

            return sanphamViewModels;
        }

        public async Task<SanphamViewModel> GetSanphamViewModelByIdSP(int idsp)
        {

            var sanpham = await _context.sanphams
                .Include(sp => sp.Sanphamchitiets)
                    .ThenInclude(spct => spct.Salechitiets)
                .Include(sp => sp.Thuonghieu)
                .Include(sp => sp.Sanphamchitiets)
                    .ThenInclude(spct => spct.Thuoctinhsanphamchitiets)
                    .ThenInclude(tt => tt.Thuoctinh)
                .Where(sp => sp.Id == idsp)
                .FirstOrDefaultAsync();

            if (sanpham == null)
            {
                return null;
            }

            // Ánh xạ dữ liệu sang ViewModel
            var sanphamViewModel = new SanphamViewModel
            {
                Id = sanpham.Id,
                Tensp = sanpham.Tensp,
                Mota = sanpham.Mota,
                Giaban = sanpham.Giaban,
                ThuongHieu = sanpham.Thuonghieu?.Tenthuonghieu ?? "N/A", // Kiểm tra null Thuonghieu
                URlHinhAnh = sanpham.UrlHinhanh,
                Soluong = sanpham.Soluong,
                idThuongHieu = sanpham.Idth,
                Sanphamchitiets = sanpham.Sanphamchitiets?.Select(spct => new SanphamchitietViewModel
                {
                    Id = spct.Id,
                    Mota = spct.Mota,
                    Giathoidiemhientai = spct.Giathoidiemhientai,
                    Soluong = spct.Soluong,
                    ThuocTinhs = spct.Thuoctinhsanphamchitiets?.Select(tt => new ThuoctinhsanphamchitietViewModel
                    {
                        Tenthuoctinh = tt.Thuoctinh?.Tenthuoctinh ?? "Unknown", // Kiểm tra null thuộc tính Thuoctinh
                        Tenthuoctinhchitiet = tt.Tenthuoctinhchitiet ?? "No detail available" // Kiểm tra null Tenthuoctinhchitiet
                    }).ToList() ?? new List<ThuoctinhsanphamchitietViewModel>(), // Nếu null thì dùng danh sách rỗng
                    Sales = spct.Salechitiets?.Select(salect => new SalechitietViewModel
                    {
                        Donvi = salect.Donvi,
                        Giatrigiam = salect.Giatrigiam,
                        Soluong = salect.Soluong
                    }).ToList() ?? new List<SalechitietViewModel>() // Nếu null thì dùng danh sách rỗng
                }).ToList() ?? new List<SanphamchitietViewModel>(), // Nếu Sanphamchitiets là null thì dùng danh sách rỗng
                Giasale = sanpham.Sanphamchitiets
                    .SelectMany(spct => spct.Salechitiets, (spct, salect) => spct.Giathoidiemhientai - salect.Giatrigiam)
                    .DefaultIfEmpty(sanpham.Giaban) // Nếu không có giá trị nào, giữ giá mặc định
                    .Min() // Lấy giá trị nhỏ nhất
            };

            return sanphamViewModel;
        }

        public async Task<IEnumerable<SanphamViewModel>> GetAllSanphamGiamGiaViewModels()
        {
            var sanphams = await _context.sanphams
        .Include(sp => sp.Sanphamchitiets)
            .ThenInclude(spct => spct.Salechitiets)
                .ThenInclude(sct => sct.Sale) // Bao gồm Sale để kiểm tra trạng thái
        .Include(sp => sp.Thuonghieu)
        .Where(sp => sp.Trangthai != 2)
        // Lọc chỉ lấy những sản phẩm có ít nhất một Salechitiet với Giatrigiam > 0 và Sale.Trangthai = 0 (giảm giá đang diễn ra)
        .Where(sp => sp.Sanphamchitiets
            .Any(spct => spct.Salechitiets
                .Any(salect => salect.Giatrigiam > 0 && salect.Sale.Trangthai == 0))) // Điều kiện giảm giá đang diễn ra
        .ToListAsync();

            var sanphamViewModels = sanphams.Select(sp => new SanphamViewModel
            {
                Id = sp.Id,
                Tensp = sp.Tensp,
                Giaban = sp.Giaban,
                Soluong = sp.Soluong,
                URlHinhAnh = sp.UrlHinhanh,
                ThuongHieu = sp.Thuonghieu?.Tenthuonghieu ?? "N/A",
                idThuongHieu = sp.Idth,
                Giasale = sp.Sanphamchitiets
                    .SelectMany(spct => spct.Salechitiets, (spct, salect) => spct.Giathoidiemhientai - salect.Giatrigiam)
                    .DefaultIfEmpty(sp.Giaban)  // Nếu không có giá trị nào, giữ giá mặc định
                    .Min()  // Lấy giá trị nhỏ nhất
            }).ToList() ?? new List<SanphamViewModel>();  // Nếu sanphams là null thì dùng danh sách rỗng

            return sanphamViewModels;
        }

        public async Task<IEnumerable<SanphamViewModel>> GetAllSanphamByThuongHieu(int id)
        {
            // Lấy danh sách sản phẩm có liên kết với thương hiệu qua id
            var sanphams = await _context.sanphams
                .Include(sp => sp.Sanphamchitiets) // Bao gồm chi tiết sản phẩm
                .ThenInclude(spct => spct.Salechitiets) // Bao gồm chi tiết giảm giá
                .Include(sp => sp.Thuonghieu) // Bao gồm thông tin thương hiệu
                .Where(sp => sp.Thuonghieu.Id == id) // Lọc theo thương hiệu
                .Where(sp => sp.Trangthai != 2)
                .ToListAsync();

            // Ánh xạ dữ liệu sang ViewModel
            var sanphamViewModels = sanphams.Select(sp => new SanphamViewModel
            {
                Id = sp.Id,
                Tensp = sp.Tensp,
                Giaban = sp.Giaban,
                Soluong = sp.Soluong,
                URlHinhAnh = sp.UrlHinhanh,
                ThuongHieu = sp.Thuonghieu?.Tenthuonghieu ?? "N/A",
                Giasale = sp.Sanphamchitiets
                    .SelectMany(spct => spct.Salechitiets, (spct, salect) => spct.Giathoidiemhientai - salect.Giatrigiam)
                    .DefaultIfEmpty(sp.Giaban) // Nếu không có giá trị nào, giữ giá mặc định
                    .Min() // Lấy giá trị nhỏ nhất
            }).ToList();

            return sanphamViewModels;
        }

      public async Task<IEnumerable<SanphamViewModel>> GetSanphamByThuocTinh(
    List<string> tenThuocTinhs = null,
    decimal? giaMin = null,
    decimal? giaMax = null,
    int? idThuongHieu = null)
{
    // Bắt đầu với toàn bộ sản phẩm
    var query = _context.sanphams
        .Include(sp => sp.Sanphamchitiets)
            .ThenInclude(spct => spct.Salechitiets)
        .Include(sp => sp.Thuonghieu)
        .Include(sp => sp.Sanphamchitiets)
            .ThenInclude(spct => spct.Thuoctinhsanphamchitiets)
            .ThenInclude(tt => tt.Thuoctinh)
        .Where(sp => sp.Trangthai != 2) // Lọc trạng thái không bị vô hiệu
        .AsQueryable();

    // Lọc theo tên thuộc tính
    if (tenThuocTinhs != null && tenThuocTinhs.Any())
    {
        query = query.Where(sp => sp.Sanphamchitiets
            .Any(spct => spct.Thuoctinhsanphamchitiets
                .Any(tt => tenThuocTinhs.Contains(tt.Tenthuoctinhchitiet))));
    }

    // Lọc theo khoảng giá
    if (giaMin.HasValue)
    {
        query = query.Where(sp => sp.Giaban >= giaMin.Value);
    }

    if (giaMax.HasValue)
    {
        query = query.Where(sp => sp.Giaban <= giaMax.Value);
    }

    // Lọc theo ID thương hiệu
    if (idThuongHieu.HasValue)
    {
        query = query.Where(sp => sp.Idth == idThuongHieu.Value);
    }

    // Lấy danh sách sản phẩm
    var sanphams = await query.ToListAsync();

    // Chuyển đổi sang ViewModel
    var sanphamViewModels = sanphams.Select(sp => new SanphamViewModel
    {
        Id = sp.Id,
        Tensp = sp.Tensp,
        Giaban = sp.Giaban,
        Soluong = sp.Soluong,
        URlHinhAnh = sp.UrlHinhanh,
        ThuongHieu = sp.Thuonghieu?.Tenthuonghieu ?? "N/A",
        idThuongHieu = sp.Idth,
        Giasale = sp.Sanphamchitiets
            .SelectMany(spct => spct.Salechitiets, (spct, salect) => spct.Giathoidiemhientai - salect.Giatrigiam)
            .DefaultIfEmpty(sp.Giaban)
            .Min()
    }).ToList();

    return sanphamViewModels;
}





    }
}