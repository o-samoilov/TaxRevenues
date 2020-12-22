namespace GeneticAlgorithm.Questions
{
    public abstract class AbstractQuestion
    {
        public abstract string GetName();
        
        public abstract int GetMinCoefficient();
        
        public abstract int GetMaxCoefficient();
        
        public abstract int Process(Manufacture manufacture, GenElement genElement);
    }
}