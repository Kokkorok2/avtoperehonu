using System;

namespace avtoperehonu
{
    class Program
    {
        static void Main()
        {
            Car car1 = new Car("Falcon GT", "RedLine", 90, 70);
            Driver driver1 = new Driver("Max Speed", 0.7, 0.8);

            car1.StartRace();
            var (fuelUsed, wearAdded) = car1.Drive(25);
            driver1.FinishRace(won: true, crashed: false);

            Console.WriteLine(car1.GetStatus());
            Console.WriteLine(driver1.GetProfile());

            car1.Refuel(20);
            car1.ChangeTires();

            Console.WriteLine("\nПісля піт-стопу:");
            Console.WriteLine(car1.GetStatus());

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}