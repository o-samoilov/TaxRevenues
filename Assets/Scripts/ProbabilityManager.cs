using System;

public class ProbabilityManager
{
    private Random _random = new Random();

    public bool IsProbability(int percentageProbability)
    {
        if (percentageProbability < 0 || percentageProbability > 100)
        {
            throw new ArgumentException();
        }

        return _random.Next(0, 101) <= percentageProbability;
    }
}