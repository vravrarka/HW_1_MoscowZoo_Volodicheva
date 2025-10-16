using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Animals
{
    public abstract class Herbo : Animal
    {
        public int LevelOfKindness { get; set; }
        public bool IsKind => LevelOfKindness > 5;
    }
}
