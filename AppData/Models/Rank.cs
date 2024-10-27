using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Rank
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id {  get; set; }
		public string tenrank { get; set; }
		public decimal minMoney { get; set; }
		public decimal maxMoney { get; set; }
		public int trangthai { get; set; }
		public virtual ICollection<Khachhang> Khachhangs { get; set; }
		public virtual ICollection<giamgia_rank> Giamgia_Ranks { get; set; }
	}
}
