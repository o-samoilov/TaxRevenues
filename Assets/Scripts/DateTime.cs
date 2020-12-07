using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DateTime : MonoBehaviour
{
    [Tooltip("Day length in seconds.")]
    public float DayLength = 5f; // seconds
    private static int _currentDay = 1;

    public static int CurrentDay => _currentDay;

    private void Start()
    {
        InvokeRepeating(nameof(NextDay), DayLength, DayLength);
    }

    private void NextDay()
    {
        _currentDay++;
    }
}