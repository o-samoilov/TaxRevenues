﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : MonoBehaviour
{
    [Tooltip("Setting quantity max products for sold every day.")]
    public static int MaxProductsPerDay = 10;// todo revert 1000
    
    public static float ProductPrice = 10f;
    
    private static int _soldProductsToday = 0;
    private static int _currentDay;

    private void Start()
    {
        _currentDay = WorldDateTime.CurrentDay;
    }
    
    private void Update()
    {
        if (_currentDay != WorldDateTime.CurrentDay)
        {
            _currentDay = WorldDateTime.CurrentDay;
            _soldProductsToday = 0;
        }
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
}