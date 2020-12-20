using UnityEngine;

public class Exchange : MonoBehaviour
{
    [Tooltip("Setting quantity max products for sold every day.")]
    public static int MaxProductsPerDay = 1000;

    public static float ProductPrice = 10f;

    private static int _soldProductsToday = 0;

    public WorldDateTime worldDateTime;

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }


    public static bool IsPossibleSell()
    {
        return _soldProductsToday < MaxProductsPerDay;
    }

    public static float Sold(GameObject product)
    {
        if (!IsPossibleSell())
        {
            return 0;
        }

        _soldProductsToday++;

        return ProductPrice;
    }

    public static int CountOpportunitySell()
    {
        return MaxProductsPerDay - _soldProductsToday;
    }

    private static void WorldDateTimeNewDayHandler(object sender, Event.WorldDateTimeEventArgs e)
    {
        _soldProductsToday = 0;

        //todo save statistic
    }
}