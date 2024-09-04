using Microsoft.EntityFrameworkCore;
using backEnd.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de nuestro contexto con la cadena de conexión SQL para utilizarlo dentro de los controladores
builder.Services.AddDbContext<TechStoreDBContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL")));

// Agregamos la política de reglas CORS para evitar problemas al subir APIs a un dominio en el futuro
var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
  opt.AddPolicy(name: misReglasCors, builder =>
  {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(misReglasCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
