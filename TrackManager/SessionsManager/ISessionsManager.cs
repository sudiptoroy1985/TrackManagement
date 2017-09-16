using System.Collections.Generic;

namespace TrackManagement
{
    public interface ISessionsManager
    {
        IList<Session> GetAllPossibleSessions();
    }
}
