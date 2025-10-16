using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Animals
{
    public abstract class Animal : IAlive, IInventory
    {
        public string Name { get; set; } = "";
        public abstract int Food { get; }
        public int InventoryNumber { get; set; }
        public virtual string GetInventoryDescription()
        {
            return $"№ {InventoryNumber}";
        }
    }

}
