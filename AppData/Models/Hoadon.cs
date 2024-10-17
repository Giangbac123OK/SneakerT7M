using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace AppData.Models
{
	public class Hoadon
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public int? Idnv { get; set; }
		[ForeignKey("Idnv")]
		public virtual Nhanvien Nhanvien {  get; set; }
		public int Idkh { get; set; }
		[ForeignKey("Idkh")]
		public virtual Khachhang Khachhang {  get; set; }
		public int Trangthaithanhtoan {  get; set; }
		public int Donvitrangthai {  get; set; }
		public DateTime Thoigiandathang {  get; set; }
		public string Diachiship {  get; set; }
		public DateTime? Ngaygiaodukien { get; set; }
		public DateTime? Ngaygiaothucte { get; set; }
		public decimal Tongtiencantra { get; set; }
		public decimal Tongtiensanpham {  get; set; }
		public string Sdt {  get; set; }
		public decimal? Tonggiamgia {  get; set; }
		public int? Idgg { get; set; }
		[ForeignKey("Idgg")]
		public virtual Giamgia Giamgia { get; set; }
		public int Trangthai {  get; set; }
		public virtual ICollection<Hoadonchitiet> Hoadonchitiets { get; set; }
		public virtual ICollection<Lichsuthanhtoan> Lichsuthanhtoans { get; set; }
	}
}
