using Blazored.LocalStorage;
using IceArena.Data;
using IceArena.Data.Repositories.Implementations;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Web.Components;
using IceArena.Web.Interfaces;
using IceArena.Web.Mapping;
using IceArena.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Net.Http.Headers;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAutoMapper(typeof(MatchProfile));

builder.Services.AddDbContext<IceArenaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/api/");
});
builder.Services.AddHttpClient<IMatchService, MatchService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/api/");
});

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthService>();

builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireAssertion(context =>
    {
        var user = context.User;
        return user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "admin");
    }));
    options.AddPolicy("UserOnly", policy => policy.RequireAssertion(context =>
    {
        var user = context.User;
        return user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "user");
    }));
});

builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7118/") });

var app = builder.Build();
app.UseCors("AllowAll");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.Run();