using MoscowZoo.Animals;
using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Services
{
    public class ZooService : IZooService
    {
        private readonly List<Animal> _animals = new();
        private readonly IVet _healthChecker;
        private readonly IInventoryService _inventoryService;

        public ZooService(IVet healthChecker, IInventoryService inventoryService)
        {
            _healthChecker = healthChecker;
            _inventoryService = inventoryService;
        }

        public bool AddAnimal(Animal animal)
        {
            if (_healthChecker.IsHealthy(animal))
            {
                _animals.Add(animal);
                _inventoryService.RegisterInventory(animal);
                Console.WriteLine($"Животное {animal.Name} принят в зоопарк!");
                return true;
            }
            else
            {
                Console.WriteLine($"Животное {animal.Name} не принято в зоопарк");
                return false;
            }
        }

        public int CalculateTotalFood()
        {
            return _animals.Sum(animal => animal.Food);
        }

        public IEnumerable<Herbo> GetAnimalsForContactZoo()
        {
            return _animals.OfType<Herbo>().Where(h => h.IsKind);
        }

        public IEnumerable<string> GetFullInventory()
        {
            return _inventoryService.GetFullInventory();
        }
    }
}
