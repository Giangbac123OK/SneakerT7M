﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Dto
{
    public class GiohangDTO
    {
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0,int.MaxValue,ErrorMessage = "Vui lòng nhập số lượng lớn hơn 0")]
        public int Soluong { get; set; }
        public int Idkh { get; set; }
    }
}
