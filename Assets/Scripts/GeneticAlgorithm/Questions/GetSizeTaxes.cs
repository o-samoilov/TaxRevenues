namespace GeneticAlgorithm.Questions
{
    public class GetSizeTaxes : AbstractQuestion
    {
        private TaxOffice _taxOffice = new TaxOffice();

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
            SmallScale = 0,

            // small: 0-1000,  medium: 1000-2000,  big: >2000
            MediumScale = 1,

            // small: 0-2000, medium: 2000-5000, big: >5000
            BigScale = 2
        }

        public override string GetName()
        {
            return "get_size_fines";
        }

        public override int GetMinCoefficient()
        {
            return (int) Coefficient.SmallScale;
        }

        public override int GetMaxCoefficient()
        {
            return (int) Coefficient.BigScale;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            var taxes = _taxOffice.CalculateTaxes(manufacture, ExampleProductCoastPrice, ExampleProductPrice);

            switch (genElement.Coefficient)
            {
                case (int) Coefficient.SmallScale:
                {
                    if (taxes <= 200)
                    {
                        return (int) Result.Small;
                    }
                    else if (taxes > 200 && taxes <= 500)
                    {
                        return (int) Result.Medium;
                    }

                    break;
                }
                case (int) Coefficient.MediumScale:
                {
                    if (taxes <= 1000)
                    {
                        return (int) Result.Small;
                    }
                    else if (taxes > 1000 && taxes <= 2000)
                    {
                        return (int) Result.Medium;
                    }

                    break;
                }
                case (int) Coefficient.BigScale:
                {
                    if (taxes <= 2000)
                    {
                        return (int) Result.Small;
                    }
                    else if (taxes > 2000 && taxes <= 5000)
                    {
                        return (int) Result.Medium;
                    }

                    break;
                }
            }

            return (int) Result.Big;
        }
    }
}