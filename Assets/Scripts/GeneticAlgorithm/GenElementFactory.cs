using Random = UnityEngine.Random;

namespace GeneticAlgorithm
{
    public class GenElementFactory
    {
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
            var commandIndex = Random.Range(0, _commandManager.GetCount());
            var command = _commandManager.GetByIndex(commandIndex);
            var coefficient = Random.Range(command.GetMinCoefficient(), command.GetMaxCoefficient() + 1);

            return new GenElement(
                GenTypes.Command,
                command.GetName(),
                coefficient
            );
        }

        private GenElement CreateRandomQuestion()
        {
            var questionIndex = Random.Range(0, _questionsManager.GetCount());
            var question = _questionsManager.GetByIndex(questionIndex);
            var coefficient = Random.Range(question.GetMinCoefficient(), question.GetMaxCoefficient() + 1);

            return new GenElement(
                GenTypes.Question,
                question.GetName(),
                coefficient
            );
        }
    }
}