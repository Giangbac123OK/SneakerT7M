using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Sanpham
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Tensp {  get; set; }
		public string? Mota {  get; set; }
		public int Trangthai {  get; set; }
		public decimal Giaban {  get; set; }
		public decimal? Giasale {  get; set; }
		public string? UrlHinhanh {  get; set; }
		public int Idth { get; set; }
		[ForeignKey("Idth")]
		public virtual Thuonghieu Thuonghieu { get; set; }
		public virtual ICollection<Hoadonnhapchitiet> Hoadonnhapchitiets { get; set; }
		public virtual ICollection<Sanphamchitiet> Sanphamchitiets { get; set; }
		public virtual ICollection<Salechitiet> Salechitiets { get; set; }
	}
}
