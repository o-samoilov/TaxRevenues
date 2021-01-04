namespace GeneticAlgorithm.Questions
{
    public class GetSizeTaxes : AbstractQuestion
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
            // small: 0-200,  medium: 200-500,   big: >500
            //SmallScale = 0,

            // small: 0-1000,  medium: 1000-2000,  big: >2000
            //MediumScale = 1,

            // small: 0-2000, medium: 2000-5000, big: >5000
            //BigScale = 2
        }

        public override string GetName()
        {
            return "get_size_taxes";
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
            var taxes = TaxOffice.CalculateTaxes(manufacture, ExampleProductCoastPrice, ExampleProductPrice);

            if (taxes <= 10)
            {
                return (int) Result.Small;
            }
            else if (taxes > 10 && taxes <= 30)
            {
                return (int) Result.Medium;
            }

            return (int) Result.Big;
        }
    }
}