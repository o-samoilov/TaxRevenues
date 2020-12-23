public class TaxOffice
{
    private ProbabilityManager _probabilityManager = new ProbabilityManager();
    
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
    
    public float CalculateBribe(Manufacture manufacture, Product product)
    {
        // todo complex bribe
        return 10;
    }

    public bool IsNeedPayFines(Manufacture manufacture, Product product)
    {
        //todo complex 
        // 50%
        return _probabilityManager.IsProbability(50);
    }
    
    public bool IsCouldPayBribe(Manufacture manufacture, Product product)
    {
        //todo complex 
        return true;
    }
}