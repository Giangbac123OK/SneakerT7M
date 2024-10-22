using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);//A

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
{

	options.UseSqlServer("Data Source=HOANGTHANHGIANG\\SQLEXPRESS;Initial Catalog=SneakerT7M;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
});
builder.Services.AddControllers();

builder.Services.AddScoped<IDanhgiaRepos, DanhgiaRepos>();
builder.Services.AddScoped<IDiachiRepos, DiachiRepos>();
builder.Services.AddScoped<IKhachhangRepos, KhachhangRepos>();
builder.Services.AddScoped<INhanvienRepos, NhanvienRepos>();
builder.Services.AddScoped<IRankRepo, RankRepo>();
builder.Services.AddScoped<INhaCungCapRepo, NhaCungCapRepo>();
builder.Services.AddScoped<ISaleChiTietRepos, SaleChiTietRepos>();
builder.Services.AddScoped<ISaleRepos, SaleRepos>();
// Lern more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
