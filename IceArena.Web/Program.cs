using IceArena.Web.Components;
using IceArena.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using IceArena.Web.Mapping;
using IceArena.Web.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAutoMapper(typeof(MatchProfile));

builder.Services.AddScoped <IMatchService,MatchService>();
// Добавляем HttpClient (через DI)
builder.Services.AddHttpClient<ApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/api/");
});
builder.Services.AddHttpClient<IMatchService, MatchService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/api/");
});

var app = builder.Build();

// Настройка middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
