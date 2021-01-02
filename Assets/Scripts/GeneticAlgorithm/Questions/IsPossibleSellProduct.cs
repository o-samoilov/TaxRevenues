namespace GeneticAlgorithm.Questions
{
    public class IsPossibleSellProduct : AbstractQuestion
    {
        private enum Result
        {
            Possible = 1,
            NotPossible = 2
        }

        public override string GetName()
        {
            return "is_possible_sell_product";
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
            if (Exchange.IsPossibleSell())
            {
                return (int) Result.Possible;
            }

            return (int) Result.NotPossible;
        }
    }
}