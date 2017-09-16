using System.Collections.Generic;
using TrackManagement.Models;

namespace TrackManagement
{
    /*Session entity containing list   */
    public abstract class Session
    {
        public virtual string Name { get; set; }

        public List<Event> Events { get; set; }

        public virtual int Duration
        { get; set; }

        public Session()
        {
            Events = new List<Event>();
        }
    }

    public class MorningSession : Session
    {
        public override string Name { get { return "Morning"; } }

        private int _duration;
        /* Morning session lasts from 9:00 AM to 12:00 PM == 180 minutes */
        public override int Duration
        {
            get { return _duration > -1 ? _duration : 180; } 
            set { _duration = value; }
        }
    }

    public class EveningSession : Session
    {
        public override string Name { get { return "Evening"; } }
        /* Afternoon session lasts from 1:00 PM to 5:00 PM == 240 minutes */
        private int _duration;
        
        public override int Duration
        {
            get { return _duration > -1 ? _duration : 240; }
            set { _duration = value; }
        }
    }
}
