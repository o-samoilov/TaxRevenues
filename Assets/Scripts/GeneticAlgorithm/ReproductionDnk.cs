namespace GeneticAlgorithm
{
    public class ReproductionDnk
    {
        public int CreateDay { get; }
        public bool IsHighPriority { get; }
        
        public Dnk Dnk { get; }

        public ReproductionDnk(int createDay, bool isHighPriority, Dnk dnk)
        {
            CreateDay = createDay;
            IsHighPriority = isHighPriority;
            Dnk = dnk;
        }
    }
}