using System;

namespace avtoperehonu
{
    public class Driver
    {
        public string Name { get; }
        public double Aggression { get; }
        public double Accuracy { get; }
        public int Experience { get; private set; }
        public int Wins { get; private set; }
        public int Crashes { get; private set; }

        public Driver(string name, double aggression, double accuracy)
        {
            Name = name;
            Aggression = Math.Clamp(aggression, 0.0, 1.0);
            Accuracy = Math.Clamp(accuracy, 0.0, 1.0);
            Experience = 0;
            Wins = 0;
            Crashes = 0;
        }

        public void FinishRace(bool won, bool crashed)
        {
            Experience++;
            if (won) Wins++;
            if (crashed) Crashes++;
        }

        public double GetErrorProbability()
        {
            double baseError = 0.1 + (Aggression * 0.2) - (Accuracy * 0.15);
            double experienceBonus = Math.Max(0, 0.05 * Experience);
            return Math.Clamp(baseError - experienceBonus, 0.02, 0.8);
        }

        public string GetProfile() =>
            $"{Name} | Aggression: {Aggression:F2} | Accuracy: {Accuracy:F2} | Wins: {Wins} | Crashes: {Crashes} | Experience: {Experience}";

        ~Driver() { }
    }
}
