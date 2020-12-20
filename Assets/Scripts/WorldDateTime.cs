using UnityEngine;

public class WorldDateTime : MonoBehaviour
{
    [Tooltip("Day length in seconds.")] 
    public float dayLength = 10f; // seconds
    private int _currentDay = 1;

    public delegate void NewDayHandler(object sender, Event.WorldDateTimeEventArgs e);

    public event NewDayHandler NewDay;

    public int CurrentDay => _currentDay;

    private void Start()
    {
        InvokeRepeating(nameof(NextDay), dayLength, dayLength);
    }

    private void NextDay()
    {
        _currentDay++;

        NewDay?.Invoke(this, new Event.WorldDateTimeEventArgs(_currentDay));
    }
}