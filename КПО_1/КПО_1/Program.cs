using System;
using Microsoft.Extensions.DependencyInjection;
using MoscowZoo.Interfaces;
using MoscowZoo.Services;


namespace MoscowZoo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var menuService = serviceProvider.GetRequiredService<ConsoleMenuService>();
            menuService.ShowMainMenu();
        }  

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IVet, VetClinic>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddTransient<IZooService, ZooService>();
            services.AddTransient<ConsoleMenuService>();
        }
    }
}