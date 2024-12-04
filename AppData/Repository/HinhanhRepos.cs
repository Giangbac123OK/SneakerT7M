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
    public class HinhanhRepos : IHinhanhRepos
    {
        private readonly MyDbContext _context;
        public HinhanhRepos(MyDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Hinhanh>> GetAllAsync()
        {
            try
            {
                return await _context.hinhanhs
                                     .Include(h => h.Trahang)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hình ảnh.", ex);
            }
        }

        public async Task<Hinhanh> GetByIdAsync(int id)
        {
            try
            {
                return await _context.hinhanhs
                                     .Include(h => h.Trahang)
                                     .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy hình ảnh với ID {id}.", ex);
            }
        }

        public async Task AddAsync(Hinhanh entity)
        {
            try
            {
                await _context.hinhanhs.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi thêm hình ảnh vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm hình ảnh.", ex);
            }
        }

        public async Task UpdateAsync(Hinhanh entity)
        {
            try
            {
                _context.hinhanhs.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi cập nhật hình ảnh trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật hình ảnh.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.hinhanhs.FindAsync(id);
                if (entity != null)
                {
                    _context.hinhanhs.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Không tìm thấy hình ảnh với ID {id} để xóa.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi xóa hình ảnh trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi xóa hình ảnh.", ex);
            }
        }
    }
}
