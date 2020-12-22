namespace GeneticAlgorithm.Commands
{
    public abstract class AbstractCommand
    {
        public abstract int Process(Manufacture manufacture, GenElement genElement);
    }
}