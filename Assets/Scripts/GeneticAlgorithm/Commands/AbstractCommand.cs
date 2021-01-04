namespace GeneticAlgorithm.Commands
{
    public abstract class AbstractCommand
    {
        public abstract string GetName();
        
        public abstract int GetMinCoefficient();
        
        public abstract int GetMaxCoefficient();

        public abstract bool IsFinished();
        
        public abstract int Process(Manufacture manufacture, GenElement genElement);
    }
}