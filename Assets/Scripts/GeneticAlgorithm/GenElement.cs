namespace GeneticAlgorithm
{
    public enum Types
    {
        Command = 1,
        Question = 2
    }

    public class GenElement
    {
        public int Type { get; }
        public string Name { get; }
        public int Coefficient { get; }

        public GenElement(int type, string name, int coefficient = 0)
        {
            Type = type;
            Name = name;
            Coefficient = coefficient;
        }

        public bool IsTypeCommand()
        {
            return Type == (int) Types.Command;
        }

        public bool IsTypeQuestion()
        {
            return Type == (int) Types.Question;
        }
    }
}