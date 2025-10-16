using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoscowZoo.Animals;
using MoscowZoo.Services;
using MoscowZoo.Interfaces;




namespace MoscowZoo
{
    public class ConsoleMenuService
    {
        private readonly IZooService _zooService;

        public ConsoleMenuService(IZooService zooService)
        {
            _zooService = zooService;
        }

        public void ShowMainMenu()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Система управления зоопарком:");
                    Console.WriteLine("1. Добавить животное");
                    Console.WriteLine("2. Сколько едят животные");
                    Console.WriteLine("3. Подходит ли животное для контактного зоопарка");
                    Console.WriteLine("4. Выйти из программы");
                    Console.Write("Выберите пункт меню: ");

                    var input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            ShowAddAnimalMenu();
                            break;
                        case "2":
                            ShowFoodRequirements();
                            break;
                        case "3":
                            ShowContactZooAnimals();
                            break;
                        case "4":
                            Console.WriteLine("Программа завершена!");
                            return;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный выбор, попрбуйте снова");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Возникла ошибка: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Возникла ошибка: {ex.Message}");
                Console.ResetColor();
            }
        }

        private void ShowAddAnimalMenu()
        {
            Console.Clear();
            Console.WriteLine("Какого животноо вы хотели бы добавить?");
            Console.WriteLine("1. Кролик");
            Console.WriteLine("2. Обезьяна");
            Console.WriteLine("3. Тигр");
            Console.WriteLine("4. Волк");
            Console.WriteLine("5. Назад");
            Console.Write("Выберите тип животного: ");

            var input = Console.ReadLine();
            Animal? animal = null;

            switch (input)
            {
                case "1":
                    animal = new Rabbit { Name = GetAnimalName() };
                    break;
                case "2":
                    animal = new Monkey { Name = GetAnimalName() };
                    break;
                case "3":
                    animal = new Tiger { Name = GetAnimalName() };
                    break;
                case "4":
                    animal = new Wolf { Name = GetAnimalName() };
                    break;
                case "5":
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный выбор, попрбуйте снова");
                    Console.ResetColor();
                    break;
            }

            if (animal != null)
            {
                _zooService.AddAnimal(animal);
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }

        private string GetAnimalName()
        {
            Console.Write("Введите имя животного: ");
            return Console.ReadLine()?.Trim() ?? "Животное";
        }

        private void ShowFoodRequirements()
        {
            Console.Clear();
            Console.WriteLine("Количество еды по какому животному вы хотите посмотреть или по всем, напишите эту цифры?");
            Console.WriteLine("1. Кролик");
            Console.WriteLine("2. Обезьяна");
            Console.WriteLine("3. Тигр");
            Console.WriteLine("4. Волк");
            Console.WriteLine("5. Все");
            Console.WriteLine("6. Назад");
            var input = Console.ReadLine();
            int Food;
            switch (input)
            {
                case "1":
                    Rabbit rabbit = new Rabbit();
                    Food = rabbit.Food;
                    Console.WriteLine($"Заяц ест {Food} кг в сутки");
                    break;
                case "2":
                    Monkey monkey = new Monkey();
                    Food = monkey.Food;
                    Console.WriteLine($"Обезьяна ест {Food} кг в сутки");
                    break;
                case "3":
                    Tiger tiger = new Tiger();
                    Food = tiger.Food;
                    Console.WriteLine($"Тигр ест {Food} кг в сутки");
                    break;
                case "4":
                    Wolf wolf = new Wolf();
                    Food = wolf.Food;
                    Console.WriteLine($"Волк ест {Food} кг в сутки");
                    break;
                case "5":
                    var totalFood = _zooService.CalculateTotalFood();
                    Console.WriteLine($"Общее потребление еды всеми животными: {totalFood} кг в сутки");
                    break;
                case "6":
                    return;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный выбор, попрбуйте снова");
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }

        private void ShowContactZooAnimals()
        {
            Console.Clear();
            Console.WriteLine("Контактный зоопарк:");

            var contactZooAnimals = _zooService.GetAnimalsForContactZoo().ToList();

            if (!contactZooAnimals.Any())
            {
                Console.WriteLine("Нет животных, подходящих для контактного зоопарка.");
            }
            else
            {
                Console.WriteLine("Животные для контактного зоопарка:");
                foreach (var animal in contactZooAnimals)
                {
                    Console.WriteLine($"   - {animal.Name} (Уровень доброты: {animal.LevelOfKindness}/10)");
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения.");
            Console.ReadKey();
        }
    }
}

