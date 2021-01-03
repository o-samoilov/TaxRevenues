using Event;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    [Tooltip("Setting quantity max products for sold every day.")]
    public static int MaxProductsPerDay = 1000;

    public WorldDateTime worldDateTime;
    public static float ProductPrice = 120f;

    public static int SoldProducts { get; private set; }
    private static int SoldProductsToday { get; set; }

    private void Start()
    {
        worldDateTime.NewDay += WorldDateTimeNewDayHandler;
    }

    public static bool IsPossibleSell()
    {
        return SoldProductsToday < MaxProductsPerDay;
    }

    public static float Sell()
    {
        if (!IsPossibleSell())
        {
            return 0;
        }

        SoldProducts++;
        SoldProductsToday++;

        return ProductPrice;
    }

    private void WorldDateTimeNewDayHandler(object sender, WorldDateTimeEventArgs e)
    {
        SoldProductsToday = 0;

        //todo save statistic
    }
}