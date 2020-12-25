using System;

namespace GeneticAlgorithm
{
    public class GenElementFactory
    {
        private Random _random = new Random();
        private ProbabilityManager _probabilityManager = new ProbabilityManager();

        private Commands.Manager _commandManager = new Commands.Manager();
        private Questions.Manager _questionsManager = new Questions.Manager();

        public GenElement CreateRandom()
        {
            return _probabilityManager.IsProbability(50)
                ? CreateRandomCommand()
                : CreateRandomQuestion();
        }
        
        private GenElement CreateRandomCommand()
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

        private GenElement CreateRandomQuestion()
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