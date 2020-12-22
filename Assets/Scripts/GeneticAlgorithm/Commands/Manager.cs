using System.Collections.Generic;

namespace GeneticAlgorithm.Commands
{
    public class Manager
    {
        public List<AbstractCommand> GetCommandsNames()
        {
            return new List<AbstractCommand>()
            {
                new CreateProduct()
            };
        }
        
        public int GetCountCommands()
        {
            return GetCommandsNames().Count;
        }
    }
}