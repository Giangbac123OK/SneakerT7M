using AppData.Dto;
using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppData.Dto.LichSuMuaHangDTO;

namespace AppData.Repository
{
    public class DanhGiaRepos : IDanhGiaRepos
    {
        private readonly MyDbContext _db;

        public DanhGiaRepos(MyDbContext db)
        {
            _db = db;
        }

        public async Task Create(Danhgia danhgia)
        {
            await _db.danhgias.AddAsync(danhgia);
        }

        public async Task Delete(int id)
        {
            var item = await GetById(id);
            if (item != null)
            {


                _db.danhgias.Remove(item);
            } 
           
            
        }

        public async Task<List<Danhgia>> GetAll()
        {
            return await _db.danhgias.ToListAsync();
        }

        public async Task<Danhgia> GetById(int id)
        {
            return await _db.danhgias.FindAsync(id);
        }

      
        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(Danhgia danhgia)
        {
            var itemUpdate  = await GetById(danhgia.Id);
            if(itemUpdate != null)
            {
                _db.Entry(danhgia).State = EntityState.Modified;
            }
        }
        public async Task<List<LichSuMuaHangDTO>> lichSuMuaHangDTOs(int idkh)
        {
            var HoaDons = await _db.hoadons
             .Where(hd => hd.Idkh == idkh)
              .Include(hd => hd.Hoadonchitiets)
              .ThenInclude(hdct => hdct.Idspchitiet.Sanpham)
              .Include(hd => hd.Hoadonchitiets)
             .ThenInclude(hdct => hdct.Idspchitiet.Thuoctinhsanphamchitiets)
             //.Include(hd => hd.Hoadonchitiets)
             //.ThenInclude(hdct => hdct.danhgia) 
             .ToListAsync();



            // Ánh xạ sang DTO
            return HoaDons.Select(hd => new LichSuMuaHangDTO
            {
                IdHD = hd.Id,
                IdKH = hd.Idkh,
                Trangthaithanhtoan = hd.Trangthaithanhtoan,
                Donvitrangthai = hd.Donvitrangthai,
                Thoigiandathang = hd.Thoigiandathang,
                Tongtiencantra = hd.Tongtiencantra,
                Tongtiensanpham = hd.Tongtiensanpham,
                Tonggiamgia = hd.Tonggiamgia,
                TrangthaiDonHang = hd.Trangthai,
                HoaDonCTS = hd.Hoadonchitiets.Select(ct => new HoaDonCTDTO
                {
                    IdHDCT = ct.Id,
                    Soluong = ct.Soluong,
                    Giasp = ct.Giasp,
                    Giamgia = ct.Giamgia,
                    IdSPCT = ct.Idspct,
                    Giathoidiemhientai = ct.Idspchitiet.Giathoidiemhientai,
                    TenSanPham = ct.Idspchitiet.Sanpham.Tensp,
                    URLHinhAnh = ct.Idspchitiet.Sanpham.UrlHinhanh,
                    //tenThuocTinh = string.Join(", ",
                    //    ct.Idspchitiet.Thuoctinhsanphamchitiets.Select(tt => tt.Thuoctinh.Tenthuoctinh)),
                    TenThucTinhChiTiet = string.Join(", ",
                        ct.Idspchitiet.Thuoctinhsanphamchitiets.Select(tt => tt.Tenthuoctinhchitiet)),
                    //DanhGias = ct.danhgia != null ? new DanhGiaDTO
                    //{
                    //    Id = ct.danhgia.Id,
                    //    Noidungdanhgia = ct.danhgia.Noidungdanhgia,
                    //    Ngaydanhgia = ct.danhgia.Ngaydanhgia,
                    //    UrlHinhanh = ct.danhgia.UrlHinhanh,
                    //    Trangthai = ct.danhgia.Trangthai
                    //} : null


                }).ToList()
            }).ToList();
        }

        public async Task<Danhgia> getByidHDCT(int id)
        {
            var resurl = await _db.danhgias.Where(d => d.Idhdct == id).FirstOrDefaultAsync();
            return resurl;

        }

    }
}
