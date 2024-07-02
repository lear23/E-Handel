using E_Handel.Mappings;
using E_Handel.Repositories.DBContext;
using E_Handel.Repositories.Implementation;
using E_Handel.Repositories.Interfaces;
using E_Handel.Services.Implementations;
using E_Handel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbEHandelContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<ISaleRepo, SaleRepo>();

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
