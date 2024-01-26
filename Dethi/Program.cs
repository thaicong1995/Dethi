using Dethi.Data;
using Dethi.Repo;
using Dethi.Sevice.Iservice;
using Dethi.Sevice.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Đọc cấu hình từ builder.Configuration
builder.Services.AddDbContext<MyDb>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
// Add services to the container.

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
            .AllowAnyHeader()
            .WithMethods("POST", "GET", "PUT", "DELETE")
            .AllowCredentials();
    });
});

var app = builder.Build();
app.UseCors("AllowOrigins");
app.UseRouting();

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
