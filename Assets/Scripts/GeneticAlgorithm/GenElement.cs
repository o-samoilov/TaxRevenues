namespace GeneticAlgorithm
{
    public enum GenTypes
    {
        Command = 1,
        Question = 2
    }

    public class GenElement
    {
        public GenTypes Type { get; }
        public string Name { get; }
        public int Coefficient { get; }

        public GenElement(GenTypes type, string name, int coefficient = 0)
        {
            Type = type;
            Name = name;
            Coefficient = coefficient;
        }

        public bool IsTypeCommand()
        {
            return Type == GenTypes.Command;
        }

        public bool IsTypeQuestion()
        {
            return Type == GenTypes.Question;
        }
    }
}