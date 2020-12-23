using System;
using System.Collections.Generic;

namespace GeneticAlgorithm
{
    public class GenFactory
    {
        public const int BasicSize = 64;

        private Random _random = new Random();
        private ProbabilityManager _probabilityManager = new ProbabilityManager();

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
            return _probabilityManager.IsProbability(50);
        }

        private GenElement CreateRandomCommandGenElement()
        {
            var commandIndex = _random.Next(0, _commandManager.GetCount());
            var command = _commandManager.GetByIndex(commandIndex);
            var coefficient = _random.Next(command.GetMinCoefficient(), command.GetMaxCoefficient() + 1);

            return new GenElement(
                GenTypes.Command,
                command.GetName(),
                coefficient
            );
        }

        private GenElement CreateRandomQuestionGenElement()
        {
            var questionIndex = _random.Next(0, _questionsManager.GetCount());
            var question = _questionsManager.GetByIndex(questionIndex);
            var coefficient = _random.Next(question.GetMinCoefficient(), question.GetMaxCoefficient() + 1);

            return new GenElement(
                GenTypes.Question,
                question.GetName(),
                coefficient
            );
        }
    }
}