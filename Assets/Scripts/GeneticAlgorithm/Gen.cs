using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class Gen
    {
        public List<GenElement> Elements { get; }

        public Gen(List<GenElement> elements)
        {
            Elements = elements;
        }
    }
}