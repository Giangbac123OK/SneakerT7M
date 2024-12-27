using AppData.IRepository;
using AppData.IService;
using AppData.Repository;
using AppData.Service;
using AppData;
using Microsoft.EntityFrameworkCore;
using AppData.Models;
using AppData.Dto;
using Net.payOS;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllers();/*AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});*/

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

PayOS payOS = new PayOS(configuration["Environment:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
                    configuration["Environment:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
                    configuration["Environment:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});
builder.Services.AddScoped<KhachHang_IDanhGiaRepos, KhachHang_DanhGiaRepos>();
builder.Services.AddScoped<KhachHang_IDanhGiaServices, KhachHang_DanhGiaServices>();
builder.Services.AddScoped<KhachHang_IDiaChiRepos, KhachHang_DiaChiRepos>();
builder.Services.AddScoped<KhachHang_IDiaChiService, KhachHang_DiaChiService>();
builder.Services.AddScoped<KhachHang_IGiamgiaRepos, KhachHang_GiamgiaRepos>();
builder.Services.AddScoped<KhachHang_IGiamgiaService, KhachHang_GiamgiaService>();
builder.Services.AddScoped<KhachHang_IGiohangchitietRepos, KhachHang_GiohangchitietRepos>();
builder.Services.AddScoped<KhachHang_IGiohangchitietService, KhachHang_GiohangchitietService>();
builder.Services.AddScoped<KhachHang_IGiohangRepos, KhachHang_GiohangRepos>();
builder.Services.AddScoped<KhachHang_IGiohangService, KhachHang_GiohangService>();
builder.Services.AddScoped<KhachHang_IHoaDonChiTietRepository, HoaDonChiTietRepos>();
builder.Services.AddScoped<KhachHang_IHoaDonChiTietService, KhachHang_HoaDonChiTietService>();
builder.Services.AddScoped<KhachHang_IHoadonRepository, KhachHang_HoadonRepos>();
builder.Services.AddScoped<KhachHang_IHoadonService, KhachHang_HoaDonService>();
builder.Services.AddScoped<KhachHang_IKhachhangRepos, KhachHang_KhachhangRepos>();
builder.Services.AddScoped<KhachHang_IKhachhangService, KhachHang_KhachhangService>();
builder.Services.AddScoped<KhachHang_InhacungcapRepos, KhachHang_NhacungcapRepos>();
builder.Services.AddScoped<KhachHang_InhacungcapService, KhachHang_NhacungcapService>();
builder.Services.AddScoped<KhachHang_INhanvienRepos, KhachHang_NhanvienRepos>();
builder.Services.AddScoped<KhachHang_INhanvienService, KhachHang_NhanvienService>();
builder.Services.AddScoped<KhachHang_IphuongthucthanhtoanRepos, KhachHang_PhuongthucthanhtoanRepos>();
builder.Services.AddScoped<KhachHang_IphuongthucthanhtoanServicee, KhachHang_PhuongthucthanhtoanService>();
builder.Services.AddScoped<KhachHang_IRankRepos, KhachHang_RankRepos>();
builder.Services.AddScoped<KhachHang_IRankServiece, KhachHang_RankSevi>();
builder.Services.AddScoped<KhachHang_IsalechitietRepos, KhachHang_SaleechitietRepos>();
builder.Services.AddScoped<KhachHang_ISalechitietService, KhachHang_SalechitietService>();
builder.Services.AddScoped<KhachHang_IsaleRepos, SaleRepos>();
builder.Services.AddScoped<KhachHang_ISaleService, KhachHang_SaleService>();
builder.Services.AddScoped<KhachHang_ISanphamchitietRepos, KhachHang_SanphamchitietRepos>();
builder.Services.AddScoped<KhachHang_ISanphamchitietService, KhachHang_SanphamchitietService>();
builder.Services.AddScoped<KhachHang_IsanphamRepos, KhachHang_SanphamRepos>();
builder.Services.AddScoped<KhachHang_ISanPhamservice, KhachHang_SanphamService>();
builder.Services.AddScoped<KhachHang_IThuocTinhRepos, KhachHang_ThuocTinhRepos>();
builder.Services.AddScoped<KhachHang_IThuoctinhService, KhachHang_ThuocTinhService>();
builder.Services.AddScoped<KhachHang_IThuongHieuRepos, KhachHang_ThuongHieuRepos>();
builder.Services.AddScoped<KhachHang_IThuongHieuService, KhachHang_ThuongHieuService>();
builder.Services.AddScoped<KhachHang_ITraHangChiTietRepos, KhachHang_TraHangChiTietRepos>();
builder.Services.AddScoped<KhachHang_ITraHangChiTietService, KhachHang_TraHangChiTietService>();
builder.Services.AddScoped<KhachHang_ITraHangRepos, KhachHang_TraHangRepos>();
builder.Services.AddScoped<KhachHang_ITraHangService, KhachHang_TraHangService>();
builder.Services.AddScoped<KhachHang_IGiamgia_RankRepos, KhachHang_Giamgia_RankRepos>();
builder.Services.AddScoped<KhachHang_IGiamgia_RankService, KhachHang_Giamgia_RankService>();
builder.Services.AddScoped<KhachHang_IHinhanhRepos, KhachHang_HinhanhRepos>();
builder.Services.AddScoped<KhachHang_IHinhanhService, KhachHang_HinhanhService>();
builder.Services.AddScoped<KhachHang_ILichsuthanhtoanRepos, KhachHang_LichsuthanhtoanRepos>();
builder.Services.AddScoped<KhachHang_ILichsuthanhtoanService, KhachHang_LichsuthanhtoanService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAuthentication("Basic")
//	.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton(payOS);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// Thêm `app.UseCors("AllowAll")` tr??c `app.UseAuthorization` ?? kích ho?t CORS
app.UseHttpsRedirection();
app.UseCors("AllowAll"); // S? d?ng chính sách CORS

app.UseAuthorization();

app.MapControllers();

app.Run();
