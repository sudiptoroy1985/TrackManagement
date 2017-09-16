using System.Collections.Generic;

namespace TrackManagement
{
    public class SessionsManager : ISessionsManager
    {
        /* get default sessions which are valid for a given track*/
        public virtual IList<Session> GetAllPossibleSessions()
        {
            List<Session> sessions = new List<Session>
            {
                new MorningSession(),

                new EveningSession()
            };

            return sessions;
        }
    }
}
