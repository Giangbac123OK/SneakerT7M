using AppData;
using AppData.IRepository;
using AppData.IService;
using AppData.Repository;
using AppData.Service;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();


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
builder.Services.AddScoped<IGiohangRepos, GiohangRepos>();
builder.Services.AddScoped<IGiohangService, GiohangService>();
builder.Services.AddScoped<IDiaChiService, DiaChiService>();
builder.Services.AddScoped<IDiaChiRepos, DiaChiRepos>();
builder.Services.AddScoped<IThongkeRepos, ThongkeRepos>();
builder.Services.AddScoped<IThongkeService, ThongkeService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
