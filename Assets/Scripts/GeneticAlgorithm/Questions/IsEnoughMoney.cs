namespace GeneticAlgorithm.Questions
{
    /**
     * Question IsEnoughMoney
     *
     * Coefficient (ranges money)
     * 0 - >=500
     * 1 - >=2000
     * 2 - >=5000
     *
     * Relative jumps
     * 1 - not enough
     * 2 - enough
     */
    public class IsEnoughMoney : AbstractQuestion
    {
        public override string GetName()
        {
            return "is_enough_money";
        }

        public override int GetMinCoefficient()
        {
            return 0;
        }

        public override int GetMaxCoefficient()
        {
            return 2;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (manufacture.Money < 500)
            {
                return 1;
            }

            switch (genElement.Coefficient)
            {
                case 0:
                    return manufacture.Money >= 500 ? 2 : 1;
                case 1:
                    return manufacture.Money >= 2000 ? 2 : 1;
                case 2:
                    return manufacture.Money >= 5000 ? 2 : 1;
            }

            return 2;
        }
    }
}