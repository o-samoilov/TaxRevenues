namespace Settings
{
    public class Basic
    {
        //WorldDateTime
        public const float DayLength = 2f; // seconds

        //Manufacture
        public const float ManufactureMoney = 1000f;
        public const float ManufactureMaintenanceCost = 100f;
        public const int ManufactureLiveDays = 50;
        public const float ManufactureReduceProductCoastTime = 0.5f; // seconds

        //Product
        public const float ProductCoast = 100f;
        public const float ProductCreationTime = 0.7f; // seconds

        //Exchange
        public const int ExchangeMaxProductsPerDay = 500;
        public const float ExchangeProductPrice = 150f;
    }
}