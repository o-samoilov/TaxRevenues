using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class GenFactory
    {
        private const int BasicSize = 64;
        
        public Gen CreateRandom()
        {
            var elements = new List<GenElement>();

            for (int i = 0; i < BasicSize; i++)
            {
                elements.Add();// todo
            }
            
            return new Gen(elements);
        }
    }
}