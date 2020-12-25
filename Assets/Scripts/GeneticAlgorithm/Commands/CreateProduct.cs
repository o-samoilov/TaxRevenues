namespace GeneticAlgorithm.Commands
{
    internal enum Result
    {
        ProductCantBeCreated = 1,
        ProductCantBeSold = 2,
        ProductCreated = 3
    }

    internal enum Coefficient
    {
        PayTaxes = 1,
        PayFines = 2,
        PayBribes = 3
    }

    public class CreateProduct : AbstractCommand
    {
        private TaxOffice _taxOffice = new TaxOffice();

        public override string GetName()
        {
            return "create_product";
        }

        public override int GetMinCoefficient()
        {
            return (int) Coefficient.PayTaxes;
        }

        public override int GetMaxCoefficient()
        {
            return (int) Coefficient.PayBribes;
        }

        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (!manufacture.IsPossibleCreateProduct())
            {
                return (int) Result.ProductCantBeCreated;
            }

            if (!Exchange.IsPossibleSell())
            {
                return (int) Result.ProductCantBeSold;
            }

            var product = manufacture.CreateProduct();
            if (product == null)
            {
                return (int) Result.ProductCantBeCreated;
            }

            product.Price = Exchange.Sell();
            manufacture.AddMoney(product.Price);

            if (genElement.Coefficient == (int) Coefficient.PayTaxes)
            {
                manufacture.PayTaxes(product);

                return (int) Result.ProductCreated;
            }

            if (_taxOffice.IsNeedPayFines(manufacture, product))
            {
                if (genElement.Coefficient == (int) Coefficient.PayFines)
                {
                    manufacture.PayFines(product);

                    return (int) Result.ProductCreated;
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

            return (int) Result.ProductCreated;
        }
    }
}