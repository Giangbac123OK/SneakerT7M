using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Dto
{
	public class GiamgiaDTO
	{
		public string? Mota { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn đơn vị")]
		public string Donvi { get; set; }
		[Range(0, int.MaxValue, ErrorMessage = "Giá trị phải là dương")]
		public int Giatri { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn ngày bắt đầu")]
		public DateTime Ngaybatdau { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn ngày kết thúc")]
		public DateTime Ngayketthuc { get; set; }
		[Range(0, 2, ErrorMessage = "Phải lựa chọn trạng thái")]//0: phát hành, 1: chuẩn bị phát hành, 2: dừng phát hành
		public int Trangthai { get; set; }
	}
}
