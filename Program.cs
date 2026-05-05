using API_bancaria.Data;
using API_bancaria.Repositories;
using API_bancaria.Repositories.Interfaces;
using API_bancaria.Services;
using API_bancaria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔥 GARANTE LEITURA DAS ENVS DO RENDER
builder.Configuration.AddEnvironmentVariables();

// =====================
// SERVICES
// =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// =====================
// CORS
// =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
        .AllowAnyOrigin() // 🔥 importante para produção (Render)
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// =====================
// SWAGGER + JWT
// =====================
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Bancária",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Digite: Bearer {seu token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// =====================
// JWT (CORRIGIDO)
// =====================
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    Console.WriteLine("JWT KEY NÃO ENCONTRADA!");
    throw new Exception("Jwt não configurado!");
}

var key = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// =====================
// DEPENDENCY INJECTION
// =====================
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<IContaService, ContaService>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<AuthService>();

// =====================
// DATABASE (PostgreSQL)
// =====================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("CONNECTION STRING NÃO ENCONTRADA!");
    throw new Exception("Connection string não configurada!");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// =====================
// APP
// =====================
var app = builder.Build();

// =====================
// MIDDLEWARES
// =====================

// Swagger liberado em produção
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Bancária V1");
    c.RoutePrefix = string.Empty;
});

// CORS
app.UseCors("AllowFrontend");

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Rota raiz
app.MapGet("/", () => "API Bancária rodando 🚀");

// Controllers
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.Run();