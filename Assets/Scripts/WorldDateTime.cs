using UnityEngine;

public class WorldDateTime : MonoBehaviour
{
    [Tooltip("Day length in seconds.")] public float dayLength = 3f; // seconds
    private int _currentDay = 0;

    public delegate void NewDayHandler(object sender, Event.WorldDateTimeEventArgs e);

    public event NewDayHandler NewDay;

    public int CurrentDay => _currentDay;

    private void Awake()
    {
        InvokeRepeating(nameof(NextDay), 0, dayLength);
    }

    private void NextDay()
    {
        NewDay?.Invoke(this, new Event.WorldDateTimeEventArgs(++_currentDay));
    }
}