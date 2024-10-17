using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Sanphamchitiet
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
	
		public string? Mota {  get; set; }
		public int Trangthai {  get; set; }
		public decimal Giathoidiemhientai {  get; set; }
		public int Soluong {  get; set; }
		public int Idsp { get; set; }
		[ForeignKey("Idsp")]
		public virtual Sanpham Sanpham { get; set; }
		public virtual ICollection<Hoadonchitiet> Hoadonchitiets { get; set; }
		public virtual ICollection<Thuoctinhsanphamchitiet> Thuoctinhsanphamchitiets { get; set; }
		public virtual ICollection<Giohangchitiet> Giohangchitiets { get; set; }
		public virtual ICollection<Salechitiet> Salechitiets { get; set; }
	}
}
