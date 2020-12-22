using System.Collections.Generic;

namespace GeneticAlgorithm.Commands
{
    public class Manager
    {
        public List<AbstractCommand> GetCommands()
        {
            return new List<AbstractCommand>()
            {
                new CreateProduct()
            };
        }
        
        public int GetCountCommands()
        {
            return GetCommands().Count;
        }
    }
}