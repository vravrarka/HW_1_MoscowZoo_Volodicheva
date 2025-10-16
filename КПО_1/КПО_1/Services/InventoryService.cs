using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly List<IInventory> _inventoryItems = new();
        private int _nextInventoryNumber = 0;

        public void RegisterInventory(IInventory item)
        {
            item.InventoryNumber = _nextInventoryNumber++;
            _inventoryItems.Add(item);
            Console.WriteLine($"Зарегистрирован {item.Name} под номером {item.GetInventoryDescription()}");
        }

        public IEnumerable<string> GetFullInventory()
        {
            return _inventoryItems.Select(item => item.GetInventoryDescription());
        }
    }
}
