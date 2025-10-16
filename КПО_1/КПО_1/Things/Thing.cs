using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Things
{
    public abstract class Thing : IInventory
    {
        public string Name { get; set; } = "";
        public abstract int InventoryNumber { get; set; }
        public virtual string GetInventoryDescription()
        {
            return $"Thing name: {Name} \n Inv.: {InventoryNumber}";
        }
    }

}
