namespace GeneticAlgorithm.Questions
{
    public class GetSizeBribe : AbstractQuestion
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
            // small: 0-100,  medium: 100-300,   big: >300
            SmallScale = 0,

            // small: 0-500,  medium: 500-1500,  big: >1500
            MediumScale = 1,

            // small: 0-1000, medium: 1000-3000, big: >3000
            BigScale = 2
        }

        public override string GetName()
        {
            return "get_size_bribe";
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
            var bribe = _taxOffice.CalculateBribe(manufacture, ExampleProductCoastPrice, ExampleProductPrice);

            switch (genElement.Coefficient)
            {
                case (int) Coefficient.SmallScale:
                {
                    if (bribe <= 100)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 100 && bribe <= 300)
                    {
                        return (int) Result.Medium;
                    }
                    
                    break;
                }
                case (int) Coefficient.MediumScale:
                {
                    if (bribe <= 500)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 500 && bribe <= 1500)
                    {
                        return (int) Result.Medium;
                    }
                    
                    break;
                }
                case (int) Coefficient.BigScale:
                {
                    if (bribe <= 1000)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 1000 && bribe <= 3000)
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