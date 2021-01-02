namespace GeneticAlgorithm.Commands
{
    public class ReduceProductCoastPrice : AbstractCommand
    {
        private enum Result
        {
            ReduceProductCoastPrice = 1,
            NotReduceProductCoastPrice = 2
        }

        public override string GetName()
        {
            return "reduce_product_coast_price";
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
            if (manufacture.IsPossibleReduceProductCoastPrice() && manufacture.ReduceProductCoastPrice())
            {
                return (int) Result.ReduceProductCoastPrice;
            }

            return (int) Result.NotReduceProductCoastPrice;
        }
    }
}