using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;

namespace AppData.Service
{
	public class SalechitietService:ISalechitietService
	{
		private readonly IsalechitietRepos _repository;
        public SalechitietService(IsalechitietRepos repository)
        {
			_repository = repository;

		}

	
		public async Task<string> AddSalechitietAsync(SalechitietDTO salechitietDto)
		{
			try
			{
				await _repository.AddSalechitietAsync(salechitietDto);
				return "Thông tin salechitiet đã được thêm thành công.";
			}
			catch (ArgumentException ex)
			{
				return ex.Message;
			}
		}
	}
}
