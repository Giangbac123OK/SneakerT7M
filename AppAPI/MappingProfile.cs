using AppAPI.Dto;
using AppData.Models;
using AutoMapper;

namespace AppAPI
{
	public class MappingProfile: Profile
	{
        public MappingProfile()
        {
			CreateMap<GiamgiaDTO, Giamgia>().ReverseMap();
            CreateMap<NhanvienDTO, Nhanvien>().ReverseMap();
			CreateMap<NhacungcapDTO, Nhacungcap>().ReverseMap();
            CreateMap<ThuoctinhDTO, Thuoctinh>().ReverseMap();
            CreateMap<ThuoctinhsanphamchitietDTO, Thuoctinhsanphamchitiet>().ReverseMap();
            CreateMap<ThuonghieuDTO, Thuonghieu>().ReverseMap();
        }
    }
}
