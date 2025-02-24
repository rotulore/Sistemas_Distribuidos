using SoapCore;
using PokemonAPi.Infrastructure;
    

using PokemonAPi.Services;
using Microsoft.EntityFrameworkCore;
using PokemonAPi.Repositories;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();

// builder.Services.AddTransient<>();
// builder.Services.AddSingleton<>();
builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRespository,PokemonRepository>();
builder.Services.AddSingleton<IHobbieService, HobbieService>();
builder.Services.AddScoped<IHobbiesRespository,HobbiesRepository>();

builder.Services.AddDbContext<RelationalDBContext>(options => 
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(
    builder.Configuration.GetConnectionString("DefaultConnection"))));

var app=builder.Build();

app.UseSoapEndpoint<IPokemonService>("/PokemonService.svc",new SoapEncoderOptions());
app.UseSoapEndpoint<IHobbieService>("/JosueUribeHobbiesService.svc",new SoapEncoderOptions());
app.Run();