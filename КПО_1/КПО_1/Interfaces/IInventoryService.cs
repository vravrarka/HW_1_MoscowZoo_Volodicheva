using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Interfaces
{
    public interface IInventoryService
    {
        void RegisterInventory(IInventory item);
        IEnumerable<string> GetFullInventory();
    }
}
