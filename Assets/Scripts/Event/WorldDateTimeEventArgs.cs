namespace Event
{
    public class WorldDateTimeEventArgs
    {
        public int Day { get; }

        public WorldDateTimeEventArgs(int day)
        {
            Day = day;
        }
    }
}