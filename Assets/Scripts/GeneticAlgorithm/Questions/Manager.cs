using System;
using System.Collections.Generic;

namespace GeneticAlgorithm.Questions
{
    public class Manager
    {
        public AbstractQuestion GetByIndex(int index)
        {
            return GetQuestions()[index];
        }
        
        public AbstractQuestion GetByName(string name)
        {
            foreach (var question in GetQuestions())
            {
                if (question.GetName() == name)
                {
                    return question;
                }
            }

            throw new ArgumentOutOfRangeException();
        }
        
        public int GetCount()
        {
            return GetQuestions().Count;
        }
        
        private List<AbstractQuestion> GetQuestions()
        {
            return new List<AbstractQuestion>()
            {
                new GetSizeBribe()
            };
        }
    }
}