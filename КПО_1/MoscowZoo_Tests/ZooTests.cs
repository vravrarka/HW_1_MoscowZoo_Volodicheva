using MoscowZoo;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using MoscowZoo.Animals;
using MoscowZoo.Interfaces;
using MoscowZoo.Services;
using MoscowZoo.Things;



namespace MoscowZoo_Tests
{
    public class ZooTests
    {
        private readonly ServiceProvider _serviceProvider;

        public ZooTests()
        {
            var services = new ServiceCollection();
            services.AddTransient<IVet, VetClinic>();
            services.AddSingleton<IInventoryService, InventoryService>();
            services.AddTransient<IZooService, ZooService>();
            services.AddTransient<ConsoleMenuService>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void Animal_GetInventoryDescription_ReturnsCorrectFormat()
        {
            var animal = new Monkey { InventoryNumber = 1, Name = "TestMonkey" };
            var result = animal.GetInventoryDescription();
            Assert.Equal("№ 1", result);
        }

        [Fact]
        public void Herbo_IsKind_ReturnsTrueWhenLevelGreaterThan5()
        {
            var kindHerbo = new Rabbit();
            var notKindHerbo = new Monkey();
            Assert.True(kindHerbo.IsKind);
            Assert.False(notKindHerbo.IsKind);
        }

        [Fact]
        public void Animal_FoodProperty_ReturnsCorrectValues()
        {
            var rabbit = new Rabbit();
            var monkey = new Monkey();
            var tiger = new Tiger();
            var wolf = new Wolf();
            Assert.Equal(1, rabbit.Food);
            Assert.Equal(3, monkey.Food);
            Assert.Equal(10, tiger.Food);
            Assert.Equal(6, wolf.Food);
        }
        [Fact]
        public void ZooService_AddAnimal_HealthyAnimal_AddsToCollection()
        {
            var vet = new AlwaysHealthyVet();
            var inventoryService = new InventoryService();
            var zooService = new ZooService(vet, inventoryService);
            var animal = new Rabbit { Name = "TestRabbit" };
            var result = zooService.AddAnimal(animal);
            Assert.True(result);
        }

        [Fact]
        public void ZooService_AddAnimal_UnhealthyAnimal_DoesNotAddToCollection()
        {
            var vet = new AlwaysUnhealthyVet();
            var inventoryService = new InventoryService();
            var zooService = new ZooService(vet, inventoryService);
            var animal = new Rabbit { Name = "TestRabbit" };
            var result = zooService.AddAnimal(animal);
            Assert.False(result);
        }

        [Fact]
        public void ZooService_CalculateTotalFood_ReturnsCorrectSum()
        {
            var vet = new AlwaysHealthyVet();
            var inventoryService = new InventoryService();
            var zooService = new ZooService(vet, inventoryService);
            zooService.AddAnimal(new Rabbit());
            zooService.AddAnimal(new Monkey());
            zooService.AddAnimal(new Tiger());
            var totalFood = zooService.CalculateTotalFood();
            Assert.Equal(14, totalFood); 
        }


        [Fact]
        public void ZooService_GetAnimalsForContactZoo_ReturnsOnlyKindHerbivores()
        {
            var vet = new AlwaysHealthyVet();
            var inventoryService = new InventoryService();
            var zooService = new ZooService(vet, inventoryService);

            zooService.AddAnimal(new Rabbit());
            zooService.AddAnimal(new Monkey());
            zooService.AddAnimal(new Tiger());
            zooService.AddAnimal(new Wolf()); 
            var contactZooAnimals = zooService.GetAnimalsForContactZoo().ToList();
            Assert.Equal(2, contactZooAnimals.Count);
            Assert.All(contactZooAnimals, animal => Assert.IsAssignableFrom<Herbo>(animal));
            Assert.All(contactZooAnimals, animal => Assert.True(animal.IsKind));
        }

        [Fact]
        public void InventoryService_RegisterInventory_AssignsSequentialNumbers()
        {
            var inventoryService = new InventoryService();
            var animal1 = new Rabbit { Name = "Rabbit1" };
            var animal2 = new Monkey { Name = "Monkey1" };
            inventoryService.RegisterInventory(animal1);
            inventoryService.RegisterInventory(animal2);
            Assert.Equal(0, animal1.InventoryNumber);
            Assert.Equal(1, animal2.InventoryNumber);
        }

        [Fact]
        public void InventoryService_GetFullInventory_ReturnsAllItems()
        {
            var inventoryService = new InventoryService();
            var animal1 = new Rabbit { Name = "Rabbit1" };
            var animal2 = new Monkey { Name = "Monkey1" };
            inventoryService.RegisterInventory(animal1);
            inventoryService.RegisterInventory(animal2);
            var inventory = inventoryService.GetFullInventory().ToList();
            Assert.Equal(2, inventory.Count);
            Assert.Contains("№ 0", inventory);
            Assert.Contains("№ 1", inventory);
        }

        [Fact]
        public void Thing_GetInventoryDescription_ReturnsCorrectFormat()
        {
            var table = new Table { Name = "TestTable", InventoryNumber = 5 };
            var result = table.GetInventoryDescription();
            Assert.Contains("TestTable", result);
            Assert.Contains("5", result);
        }

        [Fact]
        public void VetClinic_IsHealthy_AllHealthy_ReturnsTrue()
        {
            var vet = new VetClinic();
            var animal = new Rabbit();
        }
    }
}
