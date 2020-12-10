namespace VM
{
    public class Basic
    {
        private Manufacture _manufacture;

        public Basic(Manufacture manufacture)
        {
            _manufacture = manufacture;
        }

        public void Process()
        {
            _manufacture.CreateProduct();
            _manufacture.AddMoney(Exchange.ProductPrice);

            /*if (Exchange.IsPossibleSell())
            {
                var product = CreateProduct();
                _money += Exchange.Sold(product);
            }*/
        }
    }
}