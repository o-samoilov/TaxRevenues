using System;

namespace GeneticAlgorithm
{
    public class Dnk : ICloneable
    {
        public Gen MainGen { get; }

        public Dnk(Gen mainGen)
        {
            MainGen = mainGen;
        }

        public object Clone()
        {
            return new Dnk((Gen)MainGen.Clone());
        }
    }
}