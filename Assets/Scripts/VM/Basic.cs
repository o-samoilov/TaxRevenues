
namespace VM
{
    public class Basic
    {
        private Manufacture _manufacture;
        
        private GeneticAlgorithm.Dnk _dnk;
        private GeneticAlgorithm.Commands.Manager _commandsManager = new  GeneticAlgorithm.Commands.Manager();
        private GeneticAlgorithm.Questions.Manager _questionsManager = new  GeneticAlgorithm.Questions.Manager();

        public Basic(Manufacture manufacture)
        {
            _manufacture = manufacture;
            _dnk = new GeneticAlgorithm.DnkFactory().CreateRandom();
        }

        public void Process()
        {
            var genCurrentElement = _dnk.MainGen.GetCurrentElement();

            if (genCurrentElement.IsTypeCommand())
            {
                var command = _commandsManager.GetByName(genCurrentElement.Name);
                command.Process(_manufacture, genCurrentElement);
            }
            else
            {
                var question = _questionsManager.GetByName(genCurrentElement.Name);
                question.Process(_manufacture, genCurrentElement);
            }
            
            var product = _manufacture.CreateProduct();
            if (product != null)
            {
                product.Price = Exchange.ProductPrice;
                _manufacture.AddMoney(Exchange.ProductPrice);
            }
            
            
            /*if (Exchange.IsPossibleSell())
            {
                var product = CreateProduct();
                _money += Exchange.Sold(product);
            }*/
        }
    }
}