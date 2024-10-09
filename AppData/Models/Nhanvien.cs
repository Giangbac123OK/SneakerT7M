using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Nhanvien
	{
		public string Id {  get; set; }
		public string Hoten { get; set; }
		public DateOnly Ngaysinh { get; set; }
		public string Diachi {  get; set; }
		public bool Gioitinh {  get; set; }
		public string Sdt {  get; set; }
		public string Trangthai {  get; set; }
		public string Password {  get; set; }
		public string Role {  get; set; }
		public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
	}
}
