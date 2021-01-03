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
            SmallScale = 0,

            // small: 0-10,  medium: 10-20,  big: >20
            MediumScale = 1,

            // small: 0-15, medium: 15-30, big: >30
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
            var bribe = TaxOffice.CalculateBribe(manufacture, ExampleProductCoastPrice, ExampleProductPrice);

            switch (genElement.Coefficient)
            {
                case (int) Coefficient.SmallScale:
                {
                    if (bribe <= 2)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 2 && bribe <= 10)
                    {
                        return (int) Result.Medium;
                    }
                    
                    break;
                }
                case (int) Coefficient.MediumScale:
                {
                    if (bribe <= 10)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 10 && bribe <= 20)
                    {
                        return (int) Result.Medium;
                    }
                    
                    break;
                }
                case (int) Coefficient.BigScale:
                {
                    if (bribe <= 15)
                    {
                        return (int) Result.Small;
                    }
                    else if (bribe > 15 && bribe <= 30)
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