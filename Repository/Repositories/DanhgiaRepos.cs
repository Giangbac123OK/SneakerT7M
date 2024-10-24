﻿using AppData;
using AppData.Models;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DanhgiaRepos : IDanhgiaRepos
    {
        private readonly MyDbContext _context;
        public DanhgiaRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Danhgia danhgia)
        {
            try
            {
                _context.danhgias.Add(danhgia);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var a = _context.danhgias.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    _context.danhgias.Remove(a);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Danhgia> GettAll()
        {
            return _context.danhgias.ToList();
        }

        public Danhgia GetById(int id)
        {
            return _context.danhgias.Find(id);
        }

        public bool Update(int id, Danhgia danhgia)
        {
            try
            {
                var a = _context.danhgias.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    a.Idkh = danhgia.Idkh;
                    a.Trangthai = danhgia.Trangthai;
                    a.Ngaydanhgia = danhgia.Ngaydanhgia;
                    a.Idhdct = danhgia.Idhdct;
                    a.UrlHinhanh = danhgia.UrlHinhanh;
                    _context.danhgias.Update(a);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
