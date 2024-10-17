using AppData;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);//A

// Add services to the container.
builder.Services.AddDbContext<MyDbContext>(options =>
{
	options.UseSqlServer("Data Source=HOANG-VAN-TUAN\\HOANGTHANHGIANG;Initial Catalog=SneakerT7M;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
});
builder.Services.AddControllers();
builder.Services.AddScoped<IDanhgiaRepos, DanhgiaRepos>();
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
