using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Hoadonnhap
	{
		public string Id {  get; set; }
		public string Idnv {  get; set; }
		public DateTime Ngaynhap { get; set; }
		public string Trangthai {  get; set; }
		public float Tongtienhang {  get; set; }
		public string Nguoigiao {  get; set; }
		public string Sdtnguoigiao {  get; set; }
		public virtual Nhanvien Nhanvien { get; set; }
	}
}
