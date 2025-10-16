using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Interfaces
{
    public interface IInventory
    {
        int InventoryNumber { get; set; }
        string Name { get; set; }
        string GetInventoryDescription();
    }
}
