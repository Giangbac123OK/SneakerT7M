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
    public class DiaChiRepos : IDiaChiRepos
    {
        private readonly MyDbContext _db;

        public DiaChiRepos(MyDbContext db)
        {
            _db = db;
        }

        public async Task Create(Diachi diachi)
        {
           await _db.diachis.AddAsync(diachi);
        }

        public async Task Delete(int id)
        {
            var item = await GetDiaChiById(id);
            _db.diachis.Remove(item);

        }

        public async Task<IEnumerable<Diachi>> GetAllDiaChi()
        {
            return await _db.diachis.ToListAsync();
        }

        public async Task<Diachi> GetDiaChiById(int id)
        {
            return await _db.diachis.FirstAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update( Diachi diachi)
        {
           var updateItem = await GetDiaChiById(diachi.Id);
            if (updateItem != null)
            {
                _db.Entry(diachi).State = EntityState.Modified;
            }
        }
    }
}
