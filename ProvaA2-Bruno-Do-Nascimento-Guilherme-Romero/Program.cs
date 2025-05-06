using System.Text;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Repositories;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MySQL");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<EventoRepository>();
builder.Services.AddScoped<UsuarioRepository>();

var chaveJwt = builder.Configuration["JwtSettings:SecretKey"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(chaveJwt!))
        };
    });
    

builder.Services.AddAuthorization();

var app = builder.Build();




app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
