using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.OpenApi.Models; // Importante: Agregar esta línea para Swagger
using Microsoft.AspNetCore.Builder; // Importante: Agregar esta línea para Swagger
using Microsoft.AspNetCore.Cors; // Agrega este using

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<LogisticaAPI.Data.LogisticaAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogisticaAPIContext")));

// Configuración de la autenticación y autorización
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "mi-issuer", // Reemplaza con tu emisor
//            ValidAudience = "mi-audience", // Reemplaza con tu audiencia
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi-clave-secreta")) // Reemplaza con tu clave secreta
//        };
//    });

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("NombrePolitica", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        // Agrega otros requisitos de autorización según tus necesidades
//    });
//});

builder.Services.AddControllers();

// Agregar la configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogisticaAPI", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Habilitar la documentación de Swagger en la ruta "/swagger"
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LogisticaAPI v1"));
}
//app.UseCors(builder =>
//{
//    builder.AllowAnyOrigin()
//           .AllowAnyMethod()
//           .AllowAnyHeader();
//});
app.UseCors(options =>
{
    options.AllowAnyOrigin(); // Permitir cualquier origen
    options.AllowAnyMethod(); // Permitir cualquier método (GET, POST, etc.)
    options.AllowAnyHeader(); // Permitir cualquier encabezado
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<LogisticaAPI.Data.LogisticaAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogisticaAPIContext")));

// Configuración de la autenticación y autorización
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "mi-issuer", // Reemplaza con tu emisor
            ValidAudience = "mi-audience", // Reemplaza con tu audiencia
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mi-clave-secreta")) // Reemplaza con tu clave secreta
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NombrePolitica", policy =>
    {
        policy.RequireAuthenticatedUser();
        // Agrega otros requisitos de autorización según tus necesidades
    });
});

builder.Services.AddControllers();

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
*/

/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LogisticaAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LogisticaAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogisticaAPIContext") ?? throw new InvalidOperationException("Connection string 'LogisticaAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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
*/