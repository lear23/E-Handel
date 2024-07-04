using Blazored.LocalStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5126/api/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();

