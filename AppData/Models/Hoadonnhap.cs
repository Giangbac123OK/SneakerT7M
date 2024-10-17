using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Hoadonnhap
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public int Idnv { get; set; }
		[ForeignKey("Idnv")]
		public virtual Nhanvien Nhanvien {  get; set; }
		public int Idncc { get; set; }
		[ForeignKey("Idncc")]
		public virtual Nhacungcap Nhacungcap {  get; set; }
		public DateTime Ngaynhap { get; set; }
		public int Trangthai {  get; set; }
		public decimal Tongtienhang {  get; set; }
		public string Nguoigiao {  get; set; }
		public string Sdtnguoigiao {  get; set; }
		public virtual ICollection<Hoadonnhapchitiet> Hoadonnhapchitiets { get; set; }
	}
}
