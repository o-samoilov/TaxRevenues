namespace GeneticAlgorithm
{
    public class ReproductionDnk
    {
        public int CreateDay { get; }

        public int ManufactureId { get; }

        public Dnk Dnk { get; }

        public ReproductionDnk(int createDay, int manufactureId, Dnk dnk)
        {
            CreateDay = createDay;
            ManufactureId = manufactureId;
            Dnk = dnk;
        }
    }
}