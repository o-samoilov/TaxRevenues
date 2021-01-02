using UnityEngine;

public class TaxOffice : MonoBehaviour
{
    public WorldDateTime worldDateTime;
    
    public static float Taxes => _taxes;
    public static float Fines => _fines;
    public static float Bribe => _bribe;

    private static float _taxes = 0;
    private static float _fines = 0;
    private static float _bribe = 0;
    
    private static float _currentTaxes = 0;
    private static float _currentFines = 0;
    private static float _currentBribe = 0;

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
        return 50;
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
        // 50%
        return _probabilityManager.IsProbability(50);
    }

    public static void PayTaxes(float money)
    {
        _taxes += money;
        _currentTaxes += money;
    }

    public static void PayFines(float money)
    {
        _fines += money;
        _currentFines += money;
    }

    public static void PayBribe(float money)
    {
        _bribe += money;
        _currentBribe += money;
    }

    private void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        _currentTaxes = 0;
        _currentFines = 0;
        _currentBribe = 0;
        
        //todo save statistic
    }
}