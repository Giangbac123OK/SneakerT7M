using AppData.IRepository;
using AppData.IService;
using AppData.Repository;
using AppData.Service;
using AppData;
using Microsoft.EntityFrameworkCore;
using AppData.Models;
using AppData.Dto;
using Net.payOS;

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
builder.Services.AddScoped<IDanhGiaRepos, DanhGiaRepos>();
builder.Services.AddScoped<IDanhGiaServices, DanhGiaServices>();
builder.Services.AddScoped<IDiaChiRepos, DiaChiRepos>();
builder.Services.AddScoped<IDiaChiService, DiaChiService>();
builder.Services.AddScoped<IGiamgiaRepos, GiamgiaRepos>();
builder.Services.AddScoped<IGiamgiaService, GiamgiaService>();
builder.Services.AddScoped<IGiohangchitietRepos, GiohangchitietRepos>();
builder.Services.AddScoped<IGiohangchitietService, GiohangchitietService>();
builder.Services.AddScoped<IGiohangRepos, GiohangRepos>();
builder.Services.AddScoped<IGiohangService, GiohangService>();
builder.Services.AddScoped<IHoaDonChiTietRepository, HoaDonChiTietRepos>();
builder.Services.AddScoped<IHoaDonChiTietService, HoaDonChiTietService>();
builder.Services.AddScoped<IHoadonRepository, HoadonRepos>();
builder.Services.AddScoped<IHoadonService, HoadonService>();
builder.Services.AddScoped<IKhachhangRepos, KhachhangRepos>();
builder.Services.AddScoped<IKhachhangService, KhachhangService>();
builder.Services.AddScoped<InhacungcapRepos, NhacungcapRepos>();
builder.Services.AddScoped<InhacungcapService, NhacungcapService>();
builder.Services.AddScoped<INhanvienRepos, NhanvienRepos>();
builder.Services.AddScoped<INhanvienService, NhanvienService>();
builder.Services.AddScoped<IphuongthucthanhtoanRepos, PhuongthucthanhtoanRepos>();
builder.Services.AddScoped<IphuongthucthanhtoanServicee, PhuongthucthanhtoanService>();
builder.Services.AddScoped<IRankRepos, RankRepos>();
builder.Services.AddScoped<IRankServiece, RankSevi>();
builder.Services.AddScoped<IsalechitietRepos, SaleechitietRepos>();
builder.Services.AddScoped<ISalechitietService, SalechitietService>();
builder.Services.AddScoped<IsaleRepos, SaleRepos>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISanphamchitietRepos, SanphamchitietRepos>();
builder.Services.AddScoped<ISanphamchitietService, SanphamchitietService>();
builder.Services.AddScoped<IsanphamRepos, SanphamRepos>();
builder.Services.AddScoped<ISanPhamservice, SanphamService>();
builder.Services.AddScoped<IThuocTinhRepos, ThuocTinhRepos>();
builder.Services.AddScoped<IThuongHieuRepos, ThuongHieuRepos>();
builder.Services.AddScoped<IThuongHieuService, ThuongHieuService>();
builder.Services.AddScoped<ITraHangChiTietRepos, TraHangChiTietRepos>();
builder.Services.AddScoped<ITraHangChiTietService, TraHangChiTietService>();
builder.Services.AddScoped<ITraHangRepos, TraHangRepos>();
builder.Services.AddScoped<ITraHangService, TraHangService>();
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
