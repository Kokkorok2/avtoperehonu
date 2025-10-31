using System;

namespace avtoperehonu
{
    public class Car
    {
        public string Model { get; }
        public string Team { get; }
        public double EnginePower { get; }
        public double Aerodynamics { get; }
        public double Fuel { get; private set; }
        public double TireWear { get; private set; }
        public bool InRace { get; private set; }

        public Car(string model, string team, double enginePower, double aerodynamics)
        {
            Model = model;
            Team = team;
            EnginePower = enginePower;
            Aerodynamics = aerodynamics;
            Fuel = 100.0;
            TireWear = 0.0;
            InRace = false;
        }

        public void StartRace() => InRace = true;

        public (double fuelUsed, double wearAdded) Drive(double distance)
        {
            if (!InRace || distance <= 0) return (0, 0);

            double fuelUsed = distance * (0.05 + (100 - Aerodynamics) / 2000);
            double wearAdded = distance * (0.03 + (EnginePower / 2000));

            Fuel = Math.Max(0, Fuel - fuelUsed);
            TireWear = Math.Min(100, TireWear + wearAdded);

            return (fuelUsed, wearAdded);
        }

        public void Refuel(double liters)
        {
            if (liters > 0)
                Fuel = Math.Min(100, Fuel + liters);
        }

        public void ChangeTires() => TireWear = 0;

        public string GetStatus() =>
            $"{Model} [{Team}] | Power: {EnginePower} | Aero: {Aerodynamics} | Fuel: {Fuel:F1}% | Tire wear: {TireWear:F1}%";

        ~Car() { }
    }
}
