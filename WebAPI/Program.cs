using AutoMapper;
using FluentValidation.AspNetCore;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI._Configure;
using WebAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Aquí configuramos la escritura en un archivo
    .CreateLogger();
builder.Host.UseSerilog(logger);


builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {

        fv.RegisterValidatorsFromAssemblyContaining(typeof(Program));
    })
  .AddJsonOptions(options =>
  {
      options.JsonSerializerOptions.PropertyNamingPolicy = new PascalCaseNamingPolicy();
  });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguration(builder.Configuration);

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
