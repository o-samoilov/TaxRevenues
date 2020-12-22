using System.Collections.Generic;

namespace GeneticAlgorithm.Questions
{
    public class Manager
    {
        public List<AbstractQuestion> GetQuestionsNames()
        {
            return new List<AbstractQuestion>()
            {
                new IsEnoughMoney()
            };
        }
        
        public int GetCountQuestions()
        {
            return GetQuestionsNames().Count;
        }
    }
}