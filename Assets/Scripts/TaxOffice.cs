using UnityEngine;

public class TaxOffice : MonoBehaviour
{
    public WorldDateTime worldDateTime;

    public static float Taxes { get; private set; }
    public static float Fines { get; private set; }
    public static float Bribes { get; private set; }

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
        // todo complex taxes
        return 50;
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
        return 10;
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
        // 90%
        return _probabilityManager.IsProbability(90);
    }

    public static void PayTaxes(float money)
    {
        Taxes += money;
        CurrentDayTaxes += money;
    }

    public static void PayFines(float money)
    {
        Fines += money;
        CurrentDayFines += money;
    }

    public static void PayBribe(float money)
    {
        Bribes += money;
        CurrentDayBribes += money;
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        CurrentDayTaxes = 0;
        CurrentDayFines = 0;
        CurrentDayBribes = 0;

        //todo save statistic
    }
}