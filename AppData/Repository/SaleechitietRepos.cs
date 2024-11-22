using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
	public class SaleechitietRepos : IsalechitietRepos
	{
		private readonly MyDbContext _context;
        public SaleechitietRepos(MyDbContext context)
		{
			_context = context;

		}

		public Task AddSalechitietAsync(SalechitietDTO salechitietDto)
		{
			throw new NotImplementedException();
		}

		public Task UpdateGiasaleAsync(Sanpham sanpham, int donvi, decimal giatrigiam)
		{
			throw new NotImplementedException();
		}

		/*public async Task AddSalechitietAsync(SalechitietDTO salechitietDto)
		{
			if (salechitietDto.Idsp == null)
			{
				throw new ArgumentException("Idsp không được để trống.");
			}

			var salechitiet = new Salechitiet
			{
				Idspct = null, 
				//Idsp = salechitietDto.Idsp,
				Idsale = salechitietDto.Idsale,
				Donvi = salechitietDto.Donvi,
				Soluong = salechitietDto.Soluong,
				Giatrigiam = salechitietDto.Giatrigiam
			};

			_context.salechitiets.Add(salechitiet);
			await _context.SaveChangesAsync();

			var sale = await _context.sales.FindAsync(salechitietDto.Idsale);
			if (sale != null && sale.Trangthai == 0)  // Kiểm tra trạng thái Sale là 0
			{
				
				*//*var sanpham = await _context.sanphams.FindAsync(salechitietDto.Idsp);
				if (sanpham != null)
				{
					//await UpdateGiasaleAsync(sanpham, salechitietDto.Donvi, salechitietDto.Giatrigiam);
				}*//*
			}
		}*/

		/*public async Task UpdateGiasaleAsync(Sanpham sanpham, int donvi, decimal giatrigiam)
		{
			if (donvi == 1)
			{
				//sanpham.Giasale = sanpham.Giaban * (100 - giatrigiam) / 100;
			}
			else
			{
				sanpham.Giasale = sanpham.Giaban - giatrigiam;
			}

			_context.sanphams.Update(sanpham);
			await _context.SaveChangesAsync();
		}*/

	}
}
