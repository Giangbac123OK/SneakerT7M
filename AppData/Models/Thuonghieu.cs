using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Thuonghieu
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public string Tenthuonghieu {  get; set; }
		public int Tinhtrang {  get; set; }
		public virtual ICollection<Sanpham> Sanphams { get; set; }
	}
}
