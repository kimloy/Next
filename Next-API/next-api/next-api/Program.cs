using Duende.Bff;
using Duende.Bff.Yarp;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using next_api.DbContexts;
using next_api.Servies;
using System.Reflection;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlaceService, PlacesService>();
builder.Services.AddScoped<IParkService, ParkService>();
builder.Services.AddScoped<INextApiRepository, NextApiRepository>();
builder.Services.AddScoped<IPlayersService, PlayersService>();


builder.Services.AddDbContext<NextApiContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:NextApiDbConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("token")
               .AddJwtBearer("token", options =>
               {
                   options.Authority = "https://localhost:5001/";
                   options.Audience = "nextapi";

                   options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };

               });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("fullaccess", p =>
        p.RequireClaim(JwtClaimTypes.Scope, "nextapi_fullaccess"));

    //o.DefaultPolicy = new AuthorizationPolicyBuilder()
    //    .RequireClaim(JwtClaimTypes.Role, "contributor")
    //    .RequireAuthenticatedUser()
    //    .Build();
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
builder.WithOrigins("http://localhost:8100")
.AllowAnyHeader()
.AllowCredentials()
.AllowAnyMethod());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseBff();
app.UseAuthorization();

app.MapControllers();

app.Run();
