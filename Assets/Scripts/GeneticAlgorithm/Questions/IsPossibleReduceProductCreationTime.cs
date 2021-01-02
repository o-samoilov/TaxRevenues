namespace GeneticAlgorithm.Questions
{
    public class IsPossibleReduceProductCreationTime : AbstractQuestion
    {
        private enum Result
        {
            Possible = 1,
            NotPossible = 2
        }

        public override string GetName()
        {
            return "is_possible_reduce_product_creation_time";
        }

        public override int GetMinCoefficient()
        {
            return 0;
        }

        public override int GetMaxCoefficient()
        {
            return 0;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (manufacture.IsPossibleReduceProductCreationTime())
            {
                return (int) Result.Possible;
            }

            return (int) Result.NotPossible;
        }
    }
}