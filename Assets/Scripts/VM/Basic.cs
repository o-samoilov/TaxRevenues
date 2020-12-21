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