using Event;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    public static int MaxProductsPerDay = Settings.Basic.ExchangeMaxProductsPerDay;
    public static float ProductPrice = Settings.Basic.ExchangeProductPrice;

    public WorldDateTime worldDateTime;

    public static int SoldProducts { get; private set; }
    public static int SoldProductsToday { get; private set; }

    public static float Vat { get; private set; }
    public static float VatToday { get; private set; }

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    public static bool IsPossibleSell()
    {
        return SoldProductsToday < MaxProductsPerDay;
    }

    public static float Sell(Product product)
    {
        if (!IsPossibleSell())
        {
            return 0;
        }

        SoldProducts++;
        SoldProductsToday++;

        Vat += ProductPrice - product.CoastPrice;
        VatToday += ProductPrice - product.CoastPrice;

        return ProductPrice;
    }

    private void WorldDateTimeNewDayHandler(object sender, WorldDateTimeEventArgs e)
    {
        SoldProductsToday = 0;
        VatToday = 0;

        //todo save statistic
    }
}