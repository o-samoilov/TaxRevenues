namespace GeneticAlgorithm.Questions
{
    public class GetSizeBribe : AbstractQuestion
    {
        private const float ExampleProductCoastPrice = 100;
        private const float ExampleProductPrice = 150;

        private enum Result
        {
            Small = 1,
            Medium = 2,
            Big = 3
        }

        private enum Coefficient
        {
            // small: 0-2,  medium: 2-10,   big: >10
            //SmallScale = 0,

            // small: 0-10,  medium: 10-20,  big: >20
            //MediumScale = 1,

            // small: 0-15, medium: 15-30, big: >30
            //BigScale = 2
        }

        public override string GetName()
        {
            return "get_size_bribe";
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
            var bribe = TaxOffice.CalculateBribe(manufacture, ExampleProductCoastPrice, ExampleProductPrice);

            if (bribe <= 5)
            {
                return (int) Result.Small;
            }
            else if (bribe > 5 && bribe <= 15)
            {
                return (int) Result.Medium;
            }
            
            return (int) Result.Big;
        }
    }
}