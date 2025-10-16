using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Animals
{
    public class Monkey : Herbo
    {
        public override int Food => 3;
        public Monkey() { LevelOfKindness = 3; }
    }

    public class Rabbit : Herbo
    {
        public override int Food => 1;
        public Rabbit() { LevelOfKindness = 9; }
    }

    public class Tiger : Predator
    {
        public override int Food => 10;
    }

    public class Wolf : Predator
    {
        public override int Food => 6;
    }
}
