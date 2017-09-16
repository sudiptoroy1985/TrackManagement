using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackManagement
{
    /* Track Entity which contains list of sessions.Default Implementation contains Morning and Afternoon Sessions*/
    public class Track
    {
        public List<Session> Sessions { get; set; }

        public Track()
        {
            Sessions = new List<Session>();
        }
    }
}
