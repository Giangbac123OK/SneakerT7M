using System.ComponentModel.DataAnnotations;

namespace AppAPI.Dto
{
	public class NhacungcapDTO
	{
		[Required(ErrorMessage = "Tên nhà cung cấp là bắt buộc.")]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Tên nhà cung cấp phải từ 3 đến 100 ký tự.")]
		public string Tennhacungcap { get; set; }

		[Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
		[RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải từ 10 đến 11 chữ số.")]
		public string Sdt { get; set; }

		[Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
		[StringLength(200, ErrorMessage = "Địa chỉ không được vượt quá 200 ký tự.")]
		public string Diachi { get; set; }

		[EmailAddress(ErrorMessage = "Email không hợp lệ.")]
		public string? Email { get; set; }

		[Range(0, 1, ErrorMessage = "Trạng thái chỉ có thể là 0 hoặc 1.")]
		public int Trangthai { get; set; }
	}
	}
}
