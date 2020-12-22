namespace GeneticAlgorithm.Commands
{
    public class Manager
    {
        public string[] GetQuestionsNames()
        {
            return new[]
            {
                CreateProduct.Name
            };
        }
        
        public int GetCountCommands()
        {
            return GetQuestionsNames().Length;
        }
    }
}