﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Khachhang
	{
		public string Id { get; set; }
		public string Ten {  get; set; }
		public string Sdt {  get; set; }
		public DateOnly Ngaysinh { get; set; }
		public int Tichdiem {  get; set; }
		public string Email {  get; set; }
		public string Diachi {  get; set; }
		public string Password {  get; set; }
		public int Diemsudung {  get; set; }
		public string Trangthai {  get; set; }
	}
}
