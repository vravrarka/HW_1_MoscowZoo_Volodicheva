using MoscowZoo.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Interfaces
{
    public interface IZooService
    {
        bool AddAnimal(Animal animal);
        int CalculateTotalFood();
        IEnumerable<Herbo> GetAnimalsForContactZoo();
        IEnumerable<string> GetFullInventory();
    }
}
