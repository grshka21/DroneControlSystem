using System;
using System.Collections.Generic;

namespace DroneControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");

            List<Drone> drones = new List<Drone>
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite", 45),
                new Drone("Parrot Anafi", 15),
                new Drone("DJI Avata", 35),
                new Drone("Mavic 3", 42)
            };

            foreach (Drone drone in drones)
            {
                drone.PrintInfo();

                if (drone.BatteryLevel < 20)
                {
                    Console.WriteLine("ВНИМАНИЕ: Низкий уровень заряда батареи!");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < drones.Count; i++)
            {
                if (drones[i].BatteryLevel < 50)
                {
                    Console.WriteLine($"У дрона {drones[i].Model} низкий заряд: {drones[i].BatteryLevel}%.");
                    Console.Write("Хотите зарядить его? (1 — да, 0 — нет): ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        drones[i].ChargeBattery(100);
                    }
                    Console.WriteLine();
                }
            }

            Console.Write("Введите команду для первого дрона (1 — взлёт, 0 — выход): ");
            int command = int.Parse(Console.ReadLine());
            while (command != 0)
            {
                if (command == 1)
                {
                    drones[0].TakeOff();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
                Console.Write("Введите команду (1 — взлёт первого дрона, 0 — выход): ");
                command = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Программа завершена.");
        }
    }
}