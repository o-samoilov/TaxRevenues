namespace GeneticAlgorithm
{
    public class ReproductionDnk
    {
        public int CreateDay { get; }
        
        public Dnk Dnk { get; }

        public ReproductionDnk(int createDay, Dnk dnk)
        {
            CreateDay = createDay;
            Dnk = dnk;
        }
    }
}