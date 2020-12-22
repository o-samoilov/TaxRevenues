using System;

public class TaxOffice
{
    private Random _random = new Random();
    
    public float CalculateTaxes(Manufacture manufacture, Product product)
    {
        // todo complex taxes
        return 50;
    }
    
    public float CalculateFines(Manufacture manufacture, Product product)
    {
        // todo complex fine
        return 50;
    }

    public bool IsNeedPayFines(Manufacture manufacture, Product product)
    {
        //todo complex 
        // 50%
        return _random.Next(0, 1) == 0;
    }
}