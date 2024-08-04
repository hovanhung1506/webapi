using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.Abstract;
using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebApiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"),
                                             options => options.MigrationsAssembly(typeof(WebApiContext).Assembly.FullName)));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IDapperHelper, DapperHelper>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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
