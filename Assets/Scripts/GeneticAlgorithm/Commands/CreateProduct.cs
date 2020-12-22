namespace GeneticAlgorithm.Commands
{
    /**
     * Command create product
     *
     * Coefficient
     * 0 - pay taxes
     * 1 - pay fine
     *
     * Relative jumps
     * 1 - product no created
     * 2 - product created
     */
    public class CreateProduct : AbstractCommand
    {
        public const string Name = "create_product";

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