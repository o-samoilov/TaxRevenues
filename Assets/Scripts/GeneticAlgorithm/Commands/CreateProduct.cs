namespace GeneticAlgorithm.Commands
{
    /**
     * Command CreateProduct
     *
     * Coefficient
     * 0 - pay taxes
     * 1 - pay fine
     *
     * Relative jumps
     * 1 - product not created
     * 2 - product created
     */
    public class CreateProduct : AbstractCommand
    {
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
            return 2;
        }
        
        public override int Process(Manufacture manufacture, GenElement genElement)
        {
            if (!manufacture.IsPossibleCreateProduct())
            {
                return 1; // No
            }

            var product = manufacture.CreateProduct();

            if (genElement.Coefficient == 0)
            {
                manufacture.PayTaxes(product);
            }
            else
            {
                manufacture.PayFines(product);
            }

            return 2; // Yes
        }
    }
}