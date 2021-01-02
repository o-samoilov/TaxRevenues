namespace GeneticAlgorithm.Questions
{
    // todo remove
    public class IsEnoughMoney : AbstractQuestion
    {
        private enum Result
        {
            NotEnough = 1,
            Enough = 2
        }

        private enum Coefficient
        {
            More5000 = 0,
            More10000 = 1,
            More50000 = 2
        }
        
        public override string GetName()
        {
            return "is_enough_money";
        }

        public override int GetMinCoefficient()
        {
            return (int) Coefficient.More5000;
        }

        public override int GetMaxCoefficient()
        {
            return (int) Coefficient.More50000;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (manufacture.Money < 1000)
            {
                return (int) Result.NotEnough;
            }

            switch (genElement.Coefficient)
            {
                case (int) Coefficient.More5000:
                {
                    return (int) (manufacture.Money >= 5000 ? Result.Enough : Result.NotEnough);
                }
                case (int) Coefficient.More10000:
                {
                    return (int) (manufacture.Money >= 10000 ? Result.Enough : Result.NotEnough);
                }
                case (int) Coefficient.More50000:
                {
                    return (int) (manufacture.Money >= 50000 ? Result.Enough : Result.NotEnough);
                }
            }

            return 2;
        }
    }
}