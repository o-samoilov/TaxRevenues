namespace GeneticAlgorithm
{
    public class DnkFactory
    {
        public Dnk CreateRandom()
        {
            var genFactory = new GenFactory();

            return new Dnk(genFactory.CreateRandom());
        }
    }
}