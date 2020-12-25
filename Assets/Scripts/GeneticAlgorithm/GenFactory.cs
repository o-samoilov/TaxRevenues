using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class GenFactory
    {
        public const int BasicSize = 64;

        private GenElementFactory _genElementFactory = new GenElementFactory();

        public Gen CreateRandom()
        {
            var elements = new List<GenElement>();
            for (var i = 0; i < BasicSize; i++)
            {
                elements.Add(_genElementFactory.CreateRandom());
            }

            return new Gen(elements);
        }
    }
}