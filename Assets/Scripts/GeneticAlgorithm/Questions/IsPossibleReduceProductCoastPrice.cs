namespace GeneticAlgorithm.Questions
{
    public class IsPossibleReduceProductCoastPrice : AbstractQuestion
    {
        private enum Result
        {
            Possible = 1,
            NotPossible = 2
        }

        public override string GetName()
        {
            return "is_possible_reduce_product_coast_price";
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
            if (manufacture.IsPossibleReduceProductCoastPrice())
            {
                return (int) Result.Possible;
            }

            return (int) Result.NotPossible;
        }
    }
}