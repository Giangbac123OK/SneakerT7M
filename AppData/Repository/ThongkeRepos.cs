using AppData.Dto;
using AppData.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository
{
    public class ThongkeRepos : IThongkeRepos
    {
        private readonly MyDbContext _context;
        public ThongkeRepos(MyDbContext context)
        {
            _context = context;
        }
        private async Task<DateTime> ThoiGian(string thoigian)
        {
            DateTime tg = DateTime.MinValue;
            DateTime now = DateTime.Now;
            if (thoigian == "Day")
            {
                return tg = now.AddDays(-1);
            }
            else if (thoigian == "Week")
            {
                return tg = now.AddDays(-7);
            }
            else if (thoigian == "Month")
            {
                return tg = now.AddMonths(-1);
            }
            else if (thoigian == "Year")
            {
                return tg = now.AddYears(-1);
            }
            else
            {
                return tg;
            }
        }
        private async Task<decimal> GetDoanhthu(string thoigian)
        {
            DateTime tg = await ThoiGian(thoigian);
            decimal doanhthu;
            if (thoigian == null)
            {
                doanhthu = await _context.hoadons
                    .Where(x => x.Ngaygiaothucte <= DateTime.Now && x.Trangthai == 0)
                    .SumAsync(x => x.Tongtiencantra);
            }
            else
            {
                doanhthu = await _context.hoadons
                    .Where(x => x.Ngaygiaothucte >= tg && x.Ngaygiaothucte <= DateTime.Now && x.Trangthai == 0)
                    .SumAsync(x => x.Tongtiencantra);
            }
            return doanhthu;
        }


        private async Task<decimal> GetLoinhuan(string thoigian)
        {
            return 0;
        }

        private async Task<int> GetSoluongban(string thoigian)
        {
            DateTime tg = await ThoiGian(thoigian);
            int totalSoluong;
            if (thoigian == null)
            {
                totalSoluong = await (from ct in _context.hoadonchitiets
                                      join hd in _context.hoadons on ct.Idhd equals hd.Id
                                      where hd.Trangthaithanhtoan == 0 && hd.Ngaygiaothucte <= DateTime.Now && hd.Ngaygiaothucte >= tg
                                      select ct.Soluong).SumAsync();
            }
            else
            {
                totalSoluong = await (from ct in _context.hoadonchitiets
                                      join hd in _context.hoadons on ct.Idhd equals hd.Id
                                      where hd.Trangthaithanhtoan == 0 && hd.Ngaygiaothucte <= DateTime.Now
                                      select ct.Soluong).SumAsync();
            }
            return totalSoluong;
        }


        private async Task<int> GetSoluongton()
        {
            return await _context.Sanphamchitiets.SumAsync(x => x.Soluong);
        }

        public async Task<ThongkeDTO> GetThongke(string thoigian)
        {
            var data = new ThongkeDTO()
            {
                Doanhthu = await GetDoanhthu(thoigian),
                Loinhuan = await GetLoinhuan(thoigian),
                Soluongban = await GetSoluongban(thoigian),
                Soluongton = await GetSoluongton()
            };
            return data;
        }
    }
}
