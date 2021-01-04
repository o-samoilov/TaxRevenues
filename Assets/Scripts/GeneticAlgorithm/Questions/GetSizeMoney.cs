namespace GeneticAlgorithm.Questions
{
    public class GetSizeMoney : AbstractQuestion
    {
        private enum Result
        {
            Small = 1,
            Medium = 2,
            Big = 3
        }

        private enum Coefficient
        {
            // small: 0-2000,  medium: 2000-10000,   big: >10000
            //SmallScale = 0,

            // small: 0-10000,  medium: 10000-50000,  big: >50000
            //MediumScale = 1,

            // small: 0-50000, medium: 50000-500000, big: >500000
            //BigScale = 2
        }

        public override string GetName()
        {
            return "get_size_money";
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
            var money = manufacture.Money;
            
            if (money <= 5000)
            {
                return (int) Result.Small;
            }
            else if (money > 5000 && money <= 15000)
            {
                return (int) Result.Medium;
            }
            
            return (int) Result.Big;
        }
    }
}