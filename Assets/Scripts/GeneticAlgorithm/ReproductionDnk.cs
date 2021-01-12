namespace GeneticAlgorithm
{
    public class ReproductionDnk
    {
        public Dnk Dnk { get; }
        public int CreateDay { get; }

        public ReproductionDnk(Dnk dnk, int createDay)
        {
            Dnk = dnk;
            CreateDay = createDay;
        }
    }
}