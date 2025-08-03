using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pizzaria.Data;
using Pizzaria.Interface;
using Pizzaria.Services;
using Pizzaria.Settings;
using PizzariaAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("TwilioSettings"));
builder.Services.AddScoped<ISMSService, SMSService>();
builder.Services.AddScoped<IVendaService, VendaService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// =tcp:sistemaapis.database.windows.net,1433;Initial Catalog=DeliveryDB;Persist Security Info=False;User ID=adminsql;Password=Cc000000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();



app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();


app.Run();

