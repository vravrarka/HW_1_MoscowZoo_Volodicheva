using MoscowZoo.Animals;
using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo_Tests
{
    public class TestVet : IVet
    {
        public bool IsHealthy(Animal animal) => true;
    }

    public class AlwaysHealthyVet : IVet
    {
        public bool IsHealthy(Animal animal) => true;
    }

    public class AlwaysUnhealthyVet : IVet
    {
        public bool IsHealthy(Animal animal) => false;
    }

    public class HerboMock : Herbo
    {
        public HerboMock(int kindnessLevel)
        {
            LevelOfKindness = kindnessLevel;
        }

        public override int Food => 2;
    }
}
