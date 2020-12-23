namespace GeneticAlgorithm
{
    public class DnkFactory
    {
        public Dnk CreateRandom()
        {
            return new Dnk((new GenFactory()).CreateRandom());
        }
    }
}