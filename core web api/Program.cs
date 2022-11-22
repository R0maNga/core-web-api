using System.Text;
using BLL.Services;
using BLL.Services.Interfaces;
using core_web_api.Automapper;
using DAL;
using DAL.Contracts;
using DAL.Contracts.Finders;
using DAL.Contracts.Procedures;
using DAL.Contracts.Repositories;
using DAL.Entities;
using DAL.Finders;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();
var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];

/*
 Хранимая процедура 
CREATE PROCEDURE [dbo].[Procedure]

AS
    Select k.CupboardId, k.ClothesId, c.DefaultQuantity, k.Id
    From CupboardEntities as t
Left Join CupboardClothesEntities as k
ON t.Id = k.CupboardId
Left Join ClothesEntities as c
on k.ClothesId = c.Id
WHERE k.Quantity = 0*/
// For Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<CupboardContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,

            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });


builder.Services.AddDbContext<CupboardContext>(options =>
    options.UseSqlServer(connection));


builder.Services.AddTransient<IGetPrincipalFromExpiredToken, GetPrincipalFromExpiredToken>();
builder.Services.AddTransient<IGenerateRefreshToken, GenerateRefreshToken>();
builder.Services.AddTransient<ICreateTokensService, CreateTokensService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<IRegisterAdminService, RegisterAdminService>();
builder.Services.AddTransient<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IGetPrincipalFromExpiredToken, GetPrincipalFromExpiredToken>();
builder.Services.AddTransient<ICreateUserService, CreateUserService>();


builder.Services.AddTransient(provider => provider.GetRequiredService<CupboardContext>().ClothesEntities);
builder.Services.AddTransient<IClothesRepository, ClothesRepository>();
builder.Services.AddTransient<IClothesFinder, ClothesFinder>();
builder.Services.AddTransient<IClothesService, ClothesService>();

builder.Services.AddTransient(provider => provider.GetRequiredService<CupboardContext>().CupboardEntities);
builder.Services.AddTransient<ICupboardRepository, CupboardRepository>();
builder.Services.AddTransient<ICupboardFinder, CupBoardFinder>();
builder.Services.AddTransient<ICupboardService, CupboardService>();

builder.Services.AddTransient(provider => provider.GetRequiredService<CupboardContext>().CupboardModelEntities);
builder.Services.AddTransient<ICupboardModelRepository, CupboardModelRepository>();
builder.Services.AddTransient<ICupboardModelService, CupboardModelService>();
builder.Services.AddTransient<ICupboardModelFinder, CupboardModelFinder>();

builder.Services.AddTransient(provider => provider.GetRequiredService<CupboardContext>().CupboardClothesEntities);
builder.Services.AddTransient<ICupboardClothesRepository, CupboardClothesRepository>();
builder.Services.AddTransient<ICupboardClothesService, CupboardClothesService>();
builder.Services.AddTransient<IProcedureProcessor, ProcedureProcessor>();
builder.Services.AddTransient<ICupboardClothesFinder, CupboardClothesFinder>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(ClothesProfile), typeof(CupboardClothesProfile), typeof(CupboardModelProfile),
    typeof(CupboardProfile));
builder.Services.AddAutoMapper(typeof(BLL.Automapper.ClothesProfile), typeof(BLL.Automapper.CupboardClothesProfile),
    typeof(BLL.Automapper.CupboardModelProfile), typeof(BLL.Automapper.CupboardProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => //CookieAuthenticationOptions
    {
        options.LoginPath = new PathString("/Account/Login");
    });
/*builder.Services.AddControllersWithViews();*/


builder.Services.AddCors();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(t =>
{
    t.AllowAnyHeader();
    t.AllowAnyMethod();
    t.SetIsOriginAllowed(t => true);
    t.AllowCredentials();
});

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();