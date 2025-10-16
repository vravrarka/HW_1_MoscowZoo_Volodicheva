using MoscowZoo.Animals;
using MoscowZoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoscowZoo.Services
{
    public class VetClinic : IVet
    {
        public int _breath = 0;
        public int _gum = 0;
        public int _cover = 0;
        public bool IsHealthy(Animal animal)
        {
            string breath = GetInputWithRetry("В норме ли дыхание? ДА/НЕТ");
            if (breath == "ДА")
            {
                _breath++;
            }
            else if (breath == "НЕТ")
            {
                return false;
            }
            string gum = GetInputWithRetry("В норме ли ротовая полость? ДА/НЕТ");
            if (gum == "ДА")
            {
                _gum++;
            }
            else if (gum == "НЕТ")
            {
                return false;
            }
            string cover = GetInputWithRetry("В норме ли кожный покров? ДА/НЕТ");
            if (cover == "ДА")
            {
                _cover++;
            }
            else if (cover == "НЕТ")
            {
                return false;
            }
            return true;
        }

        private string GetInputWithRetry(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine()?.ToUpper().Trim();

                if (input == "ДА" || input == "НЕТ")
                {
                    return input;
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный выбор, попрбуйте снова");
                Console.ResetColor();
            }
        }
    }

}
