using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.Commands
{
    public class Manager
    {
        public int GetCount()
        {
            return GetCommands().Count;
        }

        public AbstractCommand GetByIndex(int index)
        {
            return GetCommands()[index];
        }
        
        public AbstractCommand GetByName(string name)
        {
            foreach (var command in GetCommands())
            {
                if (command.GetName() == name)
                {
                    return command;
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        private List<AbstractCommand> GetCommands()
        {
            return new List<AbstractCommand>()
            {
                new CreateProduct()
            };
        }
    }
}