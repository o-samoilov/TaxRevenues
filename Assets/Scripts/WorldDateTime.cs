using UnityEngine;

public class WorldDateTime : MonoBehaviour
{
    private const float DayLength = Settings.Basic.DayLength;

    private int _currentDay = 1;

    public delegate void NewDayHandler(object sender, Event.WorldDateTimeEventArgs e);

    public event NewDayHandler NewDay;

    public int CurrentDay => _currentDay;

    private void Awake()
    {
        InvokeRepeating(nameof(NextDay), DayLength, DayLength);
    }

    private void NextDay()
    {
        NewDay?.Invoke(this, new Event.WorldDateTimeEventArgs(++_currentDay));
    }
}