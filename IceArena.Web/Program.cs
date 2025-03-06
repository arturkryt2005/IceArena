// IceArena.Web/Program.cs
using IceArena.Web.Components;
using IceArena.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using IceArena.Web.Mapping;
using IceArena.Web.Interfaces;
using MudBlazor.Services;
using System.Security.Claims;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAutoMapper(typeof(MatchProfile));
builder.Services.AddScoped<IMatchService, MatchService>();
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