﻿using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository
{
    public class KhachHang_DiaChiRepos : KhachHang_IDiaChiRepos
    {
        private readonly MyDbContext _db;

        public KhachHang_DiaChiRepos(MyDbContext db)
        {
            _db = db;
        }

        public async Task Create(Diachi diachi)
        {
           await _db.diachis.AddAsync(diachi);
        }

        public async Task Delete(int id)
        {
            var item = await GetByIdAsync(id);
            _db.diachis.Remove(item);

        }

        public async Task<IEnumerable<Diachi>> GetAllDiaChi()
        {
            return await _db.diachis.ToListAsync();
        }

        public async Task<Diachi> GetByIdAsync(int id)
        {
            try
            {
                return await _db.diachis
                                     .Include(h => h.Khachhang)
                                     .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy hóa đơn với ID {id}.", ex);
            }
        }

        public async Task<List<Diachi>> GetDiaChiByIdKH(int Idkh)
        {
            return await _db.diachis.Where(t => t.Idkh == Idkh).ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update( Diachi diachi)
        {
           var updateItem = await GetByIdAsync(diachi.Id);
            if (updateItem != null)
            {
                _db.Entry(diachi).State = EntityState.Modified;
            }
        }
    }
}