﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AppData.Models
{
	public class Salechitiet
	{	
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public int? Idspct { get; set; }
		[ForeignKey("Idspct")]
		[JsonIgnore]
		public virtual Sanphamchitiet spchitiet {  get; set; }
		public int? Idsp { get; set; }
		[ForeignKey("Idsp")]
		[JsonIgnore]
		public virtual Sanpham Sanpham {  get; set; }
		public int Idsale { get; set; }
		[ForeignKey("Idsale")]
		[JsonIgnore]
		public virtual Sale Sale {  get; set; }
		public string Donvi {  get; set; }
		public int Soluong {  get; set; }
		public decimal Giagiam {  get; set; }
	}
}
