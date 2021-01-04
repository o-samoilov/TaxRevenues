namespace VM
{
    public class Basic
    {
        private const int MaxStepsCount = 20;
        private Manufacture _manufacture;

        private GeneticAlgorithm.Dnk _dnk;
        private GeneticAlgorithm.Commands.Manager _commandsManager = new GeneticAlgorithm.Commands.Manager();
        private GeneticAlgorithm.Questions.Manager _questionsManager = new GeneticAlgorithm.Questions.Manager();

        public Basic(Manufacture manufacture, GeneticAlgorithm.Dnk dnk)
        {
            _manufacture = manufacture;
            _dnk = dnk;
        }

        public void Process()
        {
            var gen = _dnk.MainGen;
            var genCurrentElement = gen.GetCurrentElement();

            for (var i = 0; i < MaxStepsCount; i++)
            {
                if (genCurrentElement.IsTypeCommand())
                {
                    var command = _commandsManager.GetByName(genCurrentElement.Name);
                    var steps = command.Process(_manufacture, genCurrentElement);
                    gen.Move(steps);

                    if (command.IsFinished())
                    {
                        break;
                    }
                }
                else
                {
                    var question = _questionsManager.GetByName(genCurrentElement.Name);
                    var steps = question.Process(_manufacture, genCurrentElement);
                    gen.Move(steps);
                }
            }
        }
    }
}