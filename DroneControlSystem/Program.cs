using System;
using System.Collections.Generic;

namespace DroneControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drone[] drones = new Drone[]
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite", 45),
                new Drone("Parrot Anafi", 15),
                new Drone("DJI Avata", 35),
                new Drone("Mavic 3", 42)
            };

            while (true)
            {
                try
                {
                    Console.WriteLine("=== Система управления БПЛА (версия 3.0) ===");
                    Console.WriteLine("1. Показать информацию о всех дронах");
                    Console.WriteLine("2. Взлёт выбранного дрона");
                    Console.WriteLine("3. Подзарядка выбранного дрона");
                    Console.WriteLine("4. Расчёт времени полёта");
                    Console.WriteLine("5. Сохранить состояние в файл");
                    Console.WriteLine("6. Загрузить состояние из файла");
                    Console.WriteLine("0. Выход");
                    Console.Write("Выберите пункт меню: ");

                    string menuInput = Console.ReadLine();
                    if (!int.TryParse(menuInput, out int choice))
                    {
                        Console.WriteLine("\nОшибка: введите число от 0 до 6.\n");
                        continue;
                    }
                    if (choice == 0)
                    {
                        Console.WriteLine("Выход из системы управления...");
                        break;
                    }
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n--- Информация о всех дронах ---");
                            for (int i = 0; i < drones.Length; i++)
                            {
                                Console.Write($"[{i}] ");
                                drones[i].PrintInfo();
                            }
                            break;

                        case 2:
                            if (TrySelectDrone(drones, out int indexToTakeOff))
                            {
                                drones[indexToTakeOff].TakeOff();
                            }
                            break;

                        case 3:
                            if (TrySelectDrone(drones, out int indexToCharge))
                            {
                                Console.Write("Введите уровень подзарядки (например, 20): ");
                                string chargeInput = Console.ReadLine();

                                if (int.TryParse(chargeInput, out int amount) && amount > 0)
                                {
                                    drones[indexToCharge].ChargeBattery(amount);
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: неверное значение для подзарядки.");
                                }
                            }
                            break;

                        case 4:
                            if (TrySelectDrone(drones, out int indexToCalculate))
                            {
                                drones[indexToCalculate].CalculateFlightTime();
                            }
                            break;

                        case 5:
                            Console.WriteLine("\n[Заглушка] Состояние успешно сохранено в файл.");
                            break;

                        case 6:
                            Console.WriteLine("\n[Заглушка] Состояние успешно загружено из файла.");
                            break;

                        default:
                            Console.WriteLine("\nОшибка: выбран несуществующий пункт меню.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear(); 
            }
        }
        private static bool TrySelectDrone(Drone[] drones, out int selectedIndex)
        {
            selectedIndex = -1;
            Console.Write($"Введите индекс дрона (от 0 до {drones.Length - 1}): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out selectedIndex))
            {
                Console.WriteLine("Ошибка: индекс должен быть числом.");
                return false;
            }

            if (selectedIndex < 0 || selectedIndex >= drones.Length)
            {
                Console.WriteLine("Ошибка: дрон с таким индексом не существует.");
                return false;
            }

            return true;
        }
    }
}