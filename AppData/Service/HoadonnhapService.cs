using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.Models;

namespace AppData.Service
{
    public class HoadonnhapService
	{
		private readonly IhoadonnhapRepository _repository;
        public HoadonnhapService(IhoadonnhapRepository repository)
        {
			_repository = repository;

		}
		public (string message, string providerName) ValidateAndAddHoadonnhap(HoadonnhapDTO hoadonnhapDTO, int idnv)
		{
			// Kiểm tra trạng thái
			if (hoadonnhapDTO.Trangthai < 0 || hoadonnhapDTO.Trangthai > 1)
			{
				return ("Không hợp lệ", string.Empty);
			}

			// Tạo hóa đơn nhập mới
			var hoadonnhap = new Hoadonnhap
			{
				Idnv = idnv, // Sử dụng Id nhân viên được truyền vào
				Idncc = hoadonnhapDTO.Idncc,
				Ngaynhap = hoadonnhapDTO.Ngaynhap,
				Trangthai = hoadonnhapDTO.Trangthai,
				Tongtienhang = hoadonnhapDTO.Tongtienhang,
				Nguoigiao = hoadonnhapDTO.Nguoigiao,
				Sdtnguoigiao = hoadonnhapDTO.Sdtnguoigiao
			};

			// Thêm hóa đơn nhập vào cơ sở dữ liệu
			_repository.AddHoadonnhap(hoadonnhap);

			// Lấy tên nhà cung cấp
			var nhacungcap = _repository.GetNhacungcapById(hoadonnhap.Idncc);
			return nhacungcap != null ? ("Hợp lệ", nhacungcap.Tennhacungcap) : ("Không hợp lệ", string.Empty);
		}
	}

}
