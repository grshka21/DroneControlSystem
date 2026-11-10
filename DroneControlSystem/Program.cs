using System;
using System.Collections.Generic;

namespace DroneControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");

            List<Drone> dronesList = new List<Drone>
            {
                new Drone("DJI Mini 3", 85),
                new Drone("Autel EVO Lite", 45),
                new Drone("Parrot Anafi", 15),
                new Drone("DJI Avata", 35),
                new Drone("Mavic 3", 42)
            };

            foreach (Drone drone in dronesList)
            {
                drone.PrintInfo();

                if (drone.BatteryLevel < 20)
                {
                    Console.WriteLine("ВНИМАНИЕ: Низкий уровень заряда батареи!");
                }
                Console.WriteLine();
            }
            Drone myDrone = new Drone("DJI Mini 3", 45);
            Drone mySecondDrone = new Drone("DJI Avata"); 

            Console.WriteLine("--- Информация о первом дроне ---");
            myDrone.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("--- Информация о втором дроне ---");
            mySecondDrone.PrintInfo();
            Console.WriteLine();

            Drone[] selectedDrones = { myDrone, mySecondDrone };
            int i = 0;
            while (i < selectedDrones.Length)
            {
                if (selectedDrones[i].BatteryLevel < 50)
                {
                    Console.WriteLine($"У дрона {selectedDrones[i].Model} низкий заряд: {selectedDrones[i].BatteryLevel}%.");
                    Console.Write("Хотите подзарядить его? (1 — да, 0 — нет): ");

                    if (int.TryParse(Console.ReadLine(), out int choice) && choice == 1)
                    {
                        selectedDrones[i].ChargeBattery(100);
                        Console.WriteLine("Дрон успешно заряжен.");
                    }
                    Console.WriteLine();
                }
                i++;
            }
        }
    }
}