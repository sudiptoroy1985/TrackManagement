namespace TrackManagement.Models
{
    public abstract class Event
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public bool IsScheduled { get; set; }

        public Event(string Name, int Duration)
        {
            this.Name = Name;
            this.Duration = Duration;
        }
    }

    public class TalkEvent : Event
    {
        public TalkEvent(string Name, int Duration) : base(Name, Duration)
        {

        }
    }

    public class NetworkingEvent : Event
    {
        public NetworkingEvent(string Name="", int Duration=0) : base(Name, Duration)
        {

        }
    }

    public class LunchEvent: Event
    {
        public LunchEvent(string Name="", int Duration=60) : base(Name, Duration)
        {

        }
    }
}
