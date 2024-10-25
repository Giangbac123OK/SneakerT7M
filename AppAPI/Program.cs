using AppAPI.IRepository;
using AppAPI.IService;
using AppAPI.Repository;
using AppAPI.Repositoties;
using AppAPI.Service;
using AppData;
using AppData.Repositoties;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//A

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
{
	options.UseSqlServer("Data Source=ADMIN-PC;Initial Catalog=SneakerT7M;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
});
builder.Services.AddControllers();


builder.Services.AddScoped<IphuongthucthanhtoanRepos, PhuongthucthanhtoanRepos>();
builder.Services.AddScoped<IphuongthucthanhtoanServicee, PhuongthucthanhtoanService>();
builder.Services.AddScoped<IGiamgiaRepos, GiamgiaRepos>();
builder.Services.AddScoped<IGiamgiaService, GiamgiaService>();
builder.Services.AddScoped<INhanvienRepos, NhanvienRepos>();
builder.Services.AddScoped<INhanvienService, NhanvienService>();

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
