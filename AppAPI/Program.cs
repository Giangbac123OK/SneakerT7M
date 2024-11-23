using AppData.IRepository;
using AppData.IService;
using AppData.Repository;
using AppData.Service;
using AppData;
using Microsoft.EntityFrameworkCore;
using AppData.Models;
using AppData.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();/*AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});*/

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});



// ??ng ký các d?ch v? c?a b?n
builder.Services.AddScoped<IphuongthucthanhtoanRepos, PhuongthucthanhtoanRepos>();
builder.Services.AddScoped<IphuongthucthanhtoanServicee, PhuongthucthanhtoanService>();
builder.Services.AddScoped<IGiamgiaRepos, GiamgiaRepos>();
builder.Services.AddScoped<IGiamgiaService, GiamgiaService>();
builder.Services.AddScoped<INhanvienRepos, NhanvienRepos>();
builder.Services.AddScoped<INhanvienService, NhanvienService>();
builder.Services.AddScoped<InhacungcapRepos, NhacungcapRepos>();
builder.Services.AddScoped<InhacungcapService, NhacungcapService>();

builder.Services.AddScoped<IKhachhangRepos, KhachhangRepos>();
builder.Services.AddScoped<IKhachhangService, KhachhangService>();
builder.Services.AddScoped<IsaleRepos, SaleRepos>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IsalechitietRepos, SaleechitietRepos>();
builder.Services.AddScoped<ISalechitietService, SalechitietService>();
builder.Services.AddScoped<IsanphamRepos, SanphamRepos>();
builder.Services.AddScoped<ISanPhamservice, SanphamService>();
builder.Services.AddScoped<IThuongHieuRepos, ThuongHieuRepos>();
builder.Services.AddScoped<IThuongHieuService, ThuongHieuService>();
builder.Services.AddScoped<IThuocTinhRepos, ThuocTinhRepos>();
builder.Services.AddScoped<IThuoctinhService, ThuocTinhService>();
builder.Services.AddScoped<ISanphamchitietRepos, SanphamchitietRepos>();
builder.Services.AddScoped<ISanphamchitietService, SanphamchitietService>();
builder.Services.AddScoped<IHoadonRepository, HoadonRepos>();
builder.Services.AddScoped<IHoadonService, HoadonService>();
builder.Services.AddScoped<IDanhGiaRepos, DanhGiaRepos>();
builder.Services.AddScoped<IDanhGiaServices, DanhGiaServices>();
builder.Services.AddScoped<IKhachhangRepos, KhachhangRepos>();
builder.Services.AddScoped<IKhachhangService, KhachhangService>();
builder.Services.AddScoped<IHoaDonChiTietRepository, HoaDonChiTietRepos>();
builder.Services.AddScoped<IHoaDonChiTietService, HoaDonChiTietService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
