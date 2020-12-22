namespace GeneticAlgorithm.Questions
{
    public class Manager
    {
        public string[] GetQuestionsNames()
        {
            return new[]
            {
                IsEnoughMoney.Name
            };
        }
        
        public int GetCountQuestions()
        {
            return GetQuestionsNames().Length;
        }
    }
}