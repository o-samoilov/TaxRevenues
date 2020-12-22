using System.Collections.Generic;

namespace GeneticAlgorithm.Questions
{
    public class Manager
    {
        public List<AbstractQuestion> GetQuestions()
        {
            return new List<AbstractQuestion>()
            {
                new IsEnoughMoney()
            };
        }
        
        public int GetCountQuestions()
        {
            return GetQuestions().Count;
        }
    }
}