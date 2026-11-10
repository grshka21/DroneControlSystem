using System;

namespace DroneControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Система управления БПЛА (версия 1.0) ===\n");

            Drone myDrone = new Drone("DJI Mini 3", 45);
           
            Drone mySecondDrone = new Drone("DJI Avata");

            Console.WriteLine("--- Информация о первом дроне ---");
            myDrone.PrintInfo();
            Console.WriteLine();
            Console.WriteLine("--- Информация о втором дроне ---");
            mySecondDrone.PrintInfo();
            Console.WriteLine();
            Drone[] drones = { myDrone, mySecondDrone };
            int i = 0;
            while (i < drones.Length)
            {
                if (drones[i].BatteryLevel < 50)
                {
                    Console.WriteLine($"У дрона {drones[i].Model} низкий заряд: {drones[i].BatteryLevel}%.");
                    Console.Write("Хотите подзарядить его? (1 — да, 0 — нет): ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        drones[i].ChargeBattery(60);
                    }
                    Console.WriteLine();
                }
                i++;
            }
            Console.Write("Введите команду для DJI Mini 3 (1 — взлёт, 0 — выход): ");
            int command = int.Parse(Console.ReadLine());
            while (command != 0)
            {
                if (command == 1)
                {
                    myDrone.TakeOff();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
                Console.Write("Введите команду (1 — взлёт, 0 — выход): ");
                command = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Программа завершена.");
        }
    }
}