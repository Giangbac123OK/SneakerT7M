using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Nhanvien
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		[Required(ErrorMessage = "Vui lòng nhập họ tên nhân viên!")]
		[StringLength(100,ErrorMessage ="Vui lòng nhập không quá 100 ký tự")]
		public string Hoten { get; set; }
		public DateTime? Ngaysinh { get; set; }
		public string? Diachi {  get; set; }
		[Required(ErrorMessage = "Vui lòng chọn giới tính!")]
		public bool Gioitinh {  get; set; }
		[Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có đúng 10 chữ số!")]
		public string Sdt { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn trạng thái!")]
		public int Trangthai {  get; set; }
		[Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
		[StringLength(50, ErrorMessage = "Vui lòng nhập không quá 50 ký tự")]
		public string Password {  get; set; }
		[Required(ErrorMessage = "Vui lòng chọn quyền hạn!")]
		public int Role {  get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
		public virtual ICollection<Trahang> Trahangs { get; set; }
	}
}
