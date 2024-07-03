using Blazored.LocalStorage;
using Blazored.Toast;

using E_HandelBlazor.Client.Pages;
using E_HandelBlazor.Components;
using E_HandelBlazor.Services.Models;
using E_HandelBlazor.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<ICustomerModel, CustomerModel>();
builder.Services.AddScoped<ICategoyService, CategoryModel>();
builder.Services.AddScoped<IProductService, ProductModel>();
builder.Services.AddScoped<IShoppingCart, ShoppingCartModel>();
builder.Services.AddScoped<ISaleService, SaleModel>();
builder.Services.AddScoped<IDashboardService, DashboardModel>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(E_HandelBlazor.Client._Imports).Assembly);

app.Run();
