using System;
using Random = UnityEngine.Random;

public class ProbabilityManager
{
    public bool IsProbability(int percentageProbability)
    {
        if (percentageProbability < 0 || percentageProbability > 100)
        {
            throw new ArgumentException();
        }

        return Random.Range(0, 101) <= percentageProbability;
    }
}