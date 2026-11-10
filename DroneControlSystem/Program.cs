using System;

namespace DroneControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");

            Drone[] drones = new Drone[]
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite", 45),
                new Drone("Parrot Anafi", 15)
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

            Console.Write("Введите команду (1 — взлёт первого дрона, 0 — выход): ");
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