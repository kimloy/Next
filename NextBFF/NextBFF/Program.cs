using Duende.Bff;
using Duende.Bff.Yarp;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Logging;
using NextBFF;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;


builder.Services.AddControllers();
builder.Services.AddBff().AddRemoteApis();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:8100")
            .WithHeaders("x-csrf", "content-type")
            .WithMethods("DELETE")
            .AllowCredentials();
    });
});

builder.Services.AddTransient<IReturnUrlValidator, FrontendHostReturnUrlValidator>();

builder.Services.AddUserAccessTokenHttpClient("api_client", configureClient: client =>
{
    client.BaseAddress = new Uri("http://localhost:8100/");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(o => 
    {
        o.Cookie.Name = "__Host-bff";
        o.Cookie.SameSite = SameSiteMode.None;
    })

    .AddOpenIdConnect(options =>
    {
        options.Authority = "https://localhost:5001";

        options.ClientId = "next";
        //Store in application secrets
        options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("nextapi_fullaccess");


        options.ResponseType = "code";
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.MapInboundClaims = false;


        options.TokenValidationParameters = new()
        {
            NameClaimType = "name",
            RoleClaimType = "role"
        };

        options.Events = new OpenIdConnectEvents
        {
            OnTokenResponseReceived = r =>
            {
                var accessToken = r.TokenEndpointResponse.AccessToken;
                return Task.CompletedTask;
            }
        };

    });

builder.Services.AddOpenIdConnectAccessTokenManagement();


var app = builder.Build();

app.UseCors();
app.UseRouting();

app.MapBffManagementEndpoints();

app.MapControllers()
    .RequireAuthorization()
    .AsBffApiEndpoint();

app.UseAuthentication();
app.UseBff();
app.UseAuthorization();





//app.MapBffManagementEndpoints();
////app.MapRemoteBffApiEndpoint("/api", "https://localhost:7151/api/places/geocoding/33071").RequireAccessToken(Duende.Bff.TokenType.UserOrClient);



await app.RunAsync();