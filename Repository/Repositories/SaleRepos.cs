using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SaleRepos : ISaleRepos
    {
        private readonly MyDbContext _context;

        public SaleRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task create(Sale sale)
        {
           await _context.sales.AddRangeAsync(sale);
        }

        public async Task delete(int id)
        {
             var itemDelete =  await GetSaleByID(id);
            _context.sales.Remove(itemDelete);

        }

        public async Task<IEnumerable<Sale>> GetAllSale()
        {
            return await _context.sales.ToListAsync();
        }

        public async Task<Sale> GetSaleByID(int id)
        {
            return await _context.sales.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task update(Sale sale)
        {
            var itemUpdate = await GetSaleByID(sale.Id);

            itemUpdate.Ten = sale.Ten;
            itemUpdate.Mota = sale.Mota;
            itemUpdate.Trangthai = sale.Trangthai;
            itemUpdate.Ngayketthuc = sale.Ngayketthuc;
            itemUpdate.Ngaybatdau = sale.Ngaybatdau;

            _context.sales.Update(itemUpdate);
        }
    }
    public class SaleChiTietRepos : ISaleChiTietRepos
    {
        private readonly MyDbContext _context;

        public SaleChiTietRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task create(Salechitiet saleChiTiet)
        {
            await _context.salechitiets.AddAsync(saleChiTiet);
        }

        public async Task delete(int id)
        {
            var itemDelete = await GetSaleChiTietByID(id);
            _context.salechitiets.Remove(itemDelete);
        }

        public async Task<IEnumerable<Salechitiet>> GetAllSaleChiTiet()
        {
            return await _context.salechitiets.ToListAsync();
        }

        public async Task<Salechitiet> GetSaleChiTietByID(int id)
        {
            return await _context.salechitiets.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task update(Salechitiet saleChiTiet)
        {
           var itemUpdate = await GetSaleChiTietByID(saleChiTiet.Id);
            itemUpdate.Idsp = saleChiTiet.Idsp;
            itemUpdate.Idspct = saleChiTiet.Idspct;
            itemUpdate.Idsale = saleChiTiet.Idsale;
            itemUpdate.Donvi = saleChiTiet.Donvi;
            itemUpdate.Soluong = saleChiTiet.Soluong;
            itemUpdate.Giagiam = saleChiTiet.Giagiam;

            _context.salechitiets.Update(itemUpdate);

        }
    }
}
