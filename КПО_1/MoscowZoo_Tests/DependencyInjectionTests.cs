using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MoscowZoo;
using MoscowZoo.Interfaces;
using MoscowZoo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo_Tests
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void ServiceCollection_RegistersAllServices()
        {
            Console.WriteLine("Тест регистрации сервисов в DI контейнере:");
            var services = new ServiceCollection();
            MoscowZoo.Program.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            Assert.NotNull(serviceProvider.GetService<IVet>());
            Assert.NotNull(serviceProvider.GetService<IInventoryService>());
            Assert.NotNull(serviceProvider.GetService<IZooService>());
            Assert.NotNull(serviceProvider.GetService<ConsoleMenuService>());
            Console.WriteLine("Все сервисы успешно зарегистрированы в DI контейнере\n");
        }

        [Fact]
        public void ZooService_Constructor_DependenciesResolved()
        {
            Console.WriteLine("Тест разрешения зависимостей ZooService");
            var services = new ServiceCollection();
            MoscowZoo.Program.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var zooService = serviceProvider.GetService<IZooService>();
            Assert.NotNull(zooService);
            Assert.IsType<ZooService>(zooService);
            Console.WriteLine("Зависимости ZooService успешно разрешены\n");
        }
    }
}
