namespace GeneticAlgorithm.Commands
{
    public class ReduceProductCreationTime : AbstractCommand
    {
        internal enum Result
        {
            ReduceProductCreationTime = 1,
            NotReduceProductCreationTime = 2
        }

        internal enum Coefficient
        {
        }

        public override string GetName()
        {
            return "reduce_product_creation_time";
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
                manufacture.ReduceProductCreationTime();

                return (int) Result.ReduceProductCreationTime;
            }

            return (int) Result.NotReduceProductCreationTime;
        }
    }
}