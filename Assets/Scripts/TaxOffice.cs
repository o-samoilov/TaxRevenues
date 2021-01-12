using UnityEngine;

public class TaxOffice : MonoBehaviour
{
    public WorldDateTime worldDateTime;

    public static float Taxes { get; private set; }
    public static float Fines { get; private set; }
    public static float Bribes { get; private set; }

    public static float UncollectedTaxes { get; private set; }

    public static float CurrentDayTaxes { get; private set; }
    public static float CurrentDayFines { get; private set; }
    public static float CurrentDayBribes { get; private set; }

    private static ProbabilityManager _probabilityManager = new ProbabilityManager();

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    public static float CalculateTaxes(Manufacture manufacture, Product product)
    {
        return CalculateTaxes(manufacture, product.CoastPrice, product.Price);
    }

    public static float CalculateTaxes(Manufacture manufacture, float productCoastPrice, float productPrice)
    {
        var income = productPrice - productCoastPrice;

        return income * 0.425f; //42,5%
    }

    public static float CalculateFines(Manufacture manufacture, Product product)
    {
        return CalculateFines(manufacture, product.CoastPrice, product.Price);
    }

    public static float CalculateFines(Manufacture manufacture, float productCoastPrice, float productPrice)
    {
        // todo complex fine
        return 200;
    }

    public static float CalculateBribe(Manufacture manufacture, Product product)
    {
        return CalculateBribe(manufacture, product.CoastPrice, product.Price);
    }

    public static float CalculateBribe(Manufacture manufacture, float productCoastPrice, float productPrice)
    {
        // todo complex bribe
        var income = productPrice - productCoastPrice;

        return income * 0.05f + 1; //5% + 1
    }

    public static bool IsNeedPayFines(Manufacture manufacture, Product product)
    {
        //todo complex 
        // 50%
        return _probabilityManager.IsProbability(50);
    }

    public static bool IsCouldPayBribe(Manufacture manufacture, Product product)
    {
        //todo complex 
        // 98%
        return _probabilityManager.IsProbability(98);
    }

    public static float PayTaxes(Manufacture manufacture, Product product)
    {
        var money = CalculateTaxes(manufacture, product);

        Taxes += money;
        CurrentDayTaxes += money;

        return money;
    }

    public static float PayFines(Manufacture manufacture, Product product)
    {
        var money = CalculateFines(manufacture, product);

        Fines += money;
        CurrentDayFines += money;

        return money;
    }

    public static float PayBribe(Manufacture manufacture, Product product)
    {
        var money = CalculateBribe(manufacture, product);

        Bribes += money;
        CurrentDayBribes += money;
        UncollectedTaxes += CalculateTaxes(manufacture, product);

        return money;
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        CurrentDayTaxes = 0;
        CurrentDayFines = 0;
        CurrentDayBribes = 0;

        //todo save statistic
    }
}