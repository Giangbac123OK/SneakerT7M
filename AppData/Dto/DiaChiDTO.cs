using AppData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Dto
{
    public class DiaChiDTO
    {

        public int Idkh { get; set; }
        public string Thanhpho { get; set; }
        public string Quanhuyen { get; set; }
        public string Phuongxa { get; set; }
        public string? Diachicuthe { get; set; }
    }
}
