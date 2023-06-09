using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using YummyDrop_online_store.Data;
using YummyDrop_online_store.Services.GeneratorService;
using YummyDrop_online_store.Services.RandomizeService;
using Microsoft.Extensions.DependencyInjection;
using YummyDrop_online_store.Controllers;
using System;
using Moq;

using Microsoft.EntityFrameworkCore;
using DbContextSharLab;
using Blazorise;
using Blazorise.Bootstrap;
using YummyDrop_online_store.Services.CartService;
using YummyDrop_online_store.Services.BalanceService;
using YummyDrop_online_store.Services.BonusService;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();


        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<IRandomizeService, RandomizeSerivce>();

        builder.Services.AddSingleton<IGeneratorService, GeneratorService>();

         

        //add controllers
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = true;
        });

        builder.Services.AddScoped<YummyAPIController>();
        //builder.Services.AddSingleton<YummyAPIController>(); //will fire exception

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            //options.UseInMemoryDatabase("FruitBoxTable");
        });



        builder.Services.AddBlazorise()
          .AddBootstrapProviders();


        builder.Services.AddSingleton<ICartService, CartService>();

        builder.Services.AddSingleton<IBalanceService, BalanceService>();
        builder.Services.AddSingleton<IBonusService, BonusService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        //app.MapFallbackToPage("/_Host");

        //add routing
        app.UseRouting();
        //add endpoints
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToPage("/_Host");
        });


        app.Run();
    }
}