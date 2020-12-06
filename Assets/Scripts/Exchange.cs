using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    public int MaxProductsPerDay = 1000;
    
    private int _soldProductsToday = 0;

    void Update()
    {
        //todo 
        // clear _soldProductsToday every day
    }

    public bool IsPossibleSell()
    {
        return _soldProductsToday < MaxProductsPerDay;
    }

    public void Sold()
    {
        _soldProductsToday++;
    }
}