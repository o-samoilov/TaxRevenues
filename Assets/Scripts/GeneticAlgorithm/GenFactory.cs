using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class GenFactory
    {
        private const int BasicSize = 64;

        private Random _random = new Random();
        private Commands.Manager _commandManager = new Commands.Manager();
        private Questions.Manager _questionsManager = new Questions.Manager();

        public Gen CreateRandom()
        {
            var elements = new List<GenElement>();

            for (int i = 0; i < BasicSize; i++)
            {
                var element = IsGenElementCommand()
                    ? CreateRandomCommandGenElement()
                    : CreateRandomQuestionGenElement();
                
                elements.Add(element);
            }

            return new Gen(elements);
        }

        private bool IsGenElementCommand()
        {
            return _random.Next(0, 1) == 0;
        }

        private GenElement CreateRandomCommandGenElement()
        {
            var commandIndex = _random.Next(0, _commandManager.GetCount() - 1);
            var command = _commandManager.GetByIndex(commandIndex);
            var coefficient = _random.Next(command.GetMinCoefficient(), command.GetMaxCoefficient());

            return new GenElement(
                GenTypes.Command,
                command.GetName(),
                coefficient
            );
        }
        
        private GenElement CreateRandomQuestionGenElement()
        {
            var questionIndex = _random.Next(0, _questionsManager.GetCount() - 1);
            var question = _questionsManager.GetByIndex(questionIndex);
            var coefficient = _random.Next(question.GetMinCoefficient(), question.GetMaxCoefficient());

            return new GenElement(
                GenTypes.Command,
                question.GetName(),
                coefficient
            );
        }
    }
}