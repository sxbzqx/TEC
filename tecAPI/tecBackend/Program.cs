using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using tecBackend.Models;
using tecBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 0. Загрузка env
Env.Load();
builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtSecret =
    builder.Configuration["AppSettings:Token"]
    ?? throw new InvalidOperationException("Ключа JWT нет в конфигурации");

var jwtIssuer = builder.Configuration["AppSettings:Issuer"] ?? "tec-api";
var jwtAudience = builder.Configuration["AppSettings:Audience"] ?? "tec-client";

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

// 1. Настройка CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowNextJS",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:3000",
                    "http://10.0.4.37:3000",
                    "https://chp-blond.vercel.app",
                    "http://btec.kg:3000",
                    "http://btec.kg",
                    "https://10.0.4.37",
                    "https://btec.kg",
                    "https://localhost:3000"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // Полезно, если передаются cookies/credentials
        }
    );
});

// 2. Настройка контроллеров и JSON
builder
    .Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System
            .Text
            .Json
            .Serialization
            .ReferenceHandler
            .IgnoreCycles
    );


// 3. Подключение к БД (PostgreSQL)
builder.Services.AddDbContext<SiteContext>(options => 
    options.UseNpgsql(connectionString!));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// 4. Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }

    options.SwaggerDoc(
        "v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "ТЭЦ API",
            Version = "v1",
            Description = "Документация API для корпоративного портала ТЭЦ",
        }
    );

    options.AddSecurityDefinition(
        "Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Введите токен в формате: Bearer {ваш_токен}",
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer",
        }
    );

    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    },
                },
                Array.Empty<string>()
            },
        }
    );
});

// 5. Сервисы
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();

// 6. Аутентификация и авторизация
builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateLifetime = true,
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role,
        };
    });

builder.Services.AddAuthorization();

// 7. Rate limiting на аутентификационных эндпоинтах — защита от брутфорса
//    паролей и перебора табельных номеров.
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

    options.AddFixedWindowLimiter(
        "auth",
        opt =>
        {
            opt.PermitLimit = 10;
            opt.Window = TimeSpan.FromMinutes(1);
            opt.QueueLimit = 0;
        }
    );
});

var app = builder.Build();


// Swagger — только в Development. В проде схема API не должна быть публичной.
if (app.Environment.IsDevelopment())
{
    // 1. Указываем Swagger генерировать JSON с префиксом /api/
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
    });

    // 2. Настраиваем UI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "ТЭЦ API v1");
        c.RoutePrefix = "api/swagger";
    });
}

app.UseRouting();

app.UseCors("AllowNextJS");

app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();

app.MapControllers();

app.Run();