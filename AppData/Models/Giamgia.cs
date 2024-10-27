﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Giamgia
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string? Mota {  get; set; }
		[Required(ErrorMessage = "Vui lòng chọn đơn vị")]
		[Range(0, 1, ErrorMessage = "Đơn vị phải là 0 hoặc 1")]
		public int Donvi {  get; set; }//0 là VND, 1 là %
		[Range(0, 2000000, ErrorMessage = "Giá trị phải là dương và ít hơn 2 triệu")]
		public int Giatri {  get; set; }
		[Required(ErrorMessage = "Vui lòng chọn ngày bắt đầu")]
		public DateTime Ngaybatdau { get; set; }
		[Required(ErrorMessage = "Vui lòng chọn ngày kết thúc")]
		public DateTime Ngayketthuc { get; set; }
		[Range(0, 2, ErrorMessage = "Phải lựa chọn trạng thái")]//0: phát hành, 1: chuẩn bị phát hành, 2: dừng phát hành
		public int Trangthai {  get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual ICollection<giamgia_rank> Giamgia_Ranks { get; set; }

	}
}
