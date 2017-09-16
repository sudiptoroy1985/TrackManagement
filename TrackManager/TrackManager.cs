using System.Collections.Generic;
using System.Linq;
using TrackManagement.Models;

namespace TrackManagement
{
    public class TrackManager : ITrackManager
    {   
        private ISessionsManager _sessionsManager { get; set;}

        public TrackManager(ISessionsManager Sessionsmanager)
        {
            _sessionsManager = Sessionsmanager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public List<Track> GetPossibleTracks(List<Event> events)
        {
            var possibleTracks = CreateTracks(events);

            foreach (var track in possibleTracks)
            {
                FillSession(events, track);
            }

            return possibleTracks;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="events"></param>
        /// <param name="track"></param>
        private void FillSession(List<Event> events, Track track)
        {
            foreach (var session in track.Sessions)
            {
                FillEvent(events, session);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="events"></param>
        /// <param name="session"></param>
        private static void FillEvent(List<Event> events, Session session)
        {
            foreach (var evnt in events)
            {
                if (evnt.IsScheduled)
                {
                    continue;
                }

                var talkDuration = evnt.Duration;

                if (talkDuration <= session.Duration)
                {
                    session.Events.Add(evnt);

                    evnt.IsScheduled = true;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Track CreateTrack()
        {
            var allSessions = _sessionsManager.GetAllPossibleSessions();

            Track t = new Track();

            foreach(var session in allSessions)
            {
                t.Sessions.Add(session);
            }
            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        private List<Track> CreateTracks(List<Event> events)
        {
            List<Track> possibleTracks = new List<Track>();

            var allSessions = _sessionsManager.GetAllPossibleSessions();

            var totalSessionsDuration = allSessions.Sum(p => p.Duration);

            var totalEventsDuration = events.Sum(p => p.Duration);

            int trackCount = totalEventsDuration > 0 ? totalSessionsDuration/totalEventsDuration : 0;

            while(trackCount-- > 0)
            {
                possibleTracks.Add(CreateTrack());
            }

            return possibleTracks;
         
        }
    }
}
