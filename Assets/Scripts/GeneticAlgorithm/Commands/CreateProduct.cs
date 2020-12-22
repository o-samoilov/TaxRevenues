namespace GeneticAlgorithm.Commands
{
    internal enum CommandResult
    {
        ProductNotCreated = 1,
        ProductCreated = 2
    }

    /**
     * Command CreateProduct
     *
     * Coefficient
     * 0 - pay taxes
     * 1 - pay fine if need
     * 2 - pay bribe if need
     *
     * Relative jumps
     * 1 - product not created
     * 2 - product created
     */
    public class CreateProduct : AbstractCommand
    {
        private TaxOffice _taxOffice = new TaxOffice();

        public override string GetName()
        {
            return "create_product";
        }

        public override int GetMinCoefficient()
        {
            return 1;
        }

        public override int GetMaxCoefficient()
        {
            return 3;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (!manufacture.IsPossibleCreateProduct())
            {
                return (int) CommandResult.ProductNotCreated;
            }

            var product = manufacture.CreateProduct();

            // if Coefficient == 0 pay taxes else pay fines if need
            if (genElement.Coefficient == 0)
            {
                manufacture.PayTaxes(product);

                return (int) CommandResult.ProductCreated;
            }

            if (_taxOffice.IsNeedPayFines(manufacture, product))
            {
                if (genElement.Coefficient == 1)
                {
                    manufacture.PayFines(product);

                    return (int) CommandResult.ProductCreated;
                }

                if (_taxOffice.IsCouldPayBribe(manufacture, product))
                {
                    manufacture.PayBribe(product);
                }
                else
                {
                    manufacture.PayFines(product);
                }
            }

            return (int) CommandResult.ProductCreated;
        }
    }
}