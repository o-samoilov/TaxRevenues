namespace GeneticAlgorithm
{
    public class GenElement
    {
        public string Name { get; }
        public float Coefficient { get; }

        public GenElement(string name, float coefficient = 0)
        {
            Name = name;
            Coefficient = coefficient;
        }
    }
}