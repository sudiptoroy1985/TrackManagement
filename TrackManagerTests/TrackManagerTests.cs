using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TrackManagement.Models;
using TrackManagement;
using System.Collections.Generic;
using System.Linq;

namespace TrackManagerTests
{
    [TestClass]
    public class TrackManagerTests
    {
        public ITrackManager _trackManager;
        public ISessionsManager _sessionsManager;
        List<Event> _events;



        private List<Session> CreateZeroDurationSession()
        {
            return new List<Session>{new MorningSession{Duration = 0}};
        }


        private List<Session> CreateSessionWithDurationFor8Hours()
        {
            return new List<Session> { new MorningSession { Duration = 8 * 60 } };
        }

        [TestInitialize]
        public void Init()
        {
            _sessionsManager = MockRepository.GenerateStub<SessionsManager>();                   
            _events = new List<Event>();
        }


        [TestMethod]
        public void SessionWithNoDurationAndNoEventsReturnsNoTracks()
        {
            _sessionsManager.Stub(p => p.GetAllPossibleSessions()).Return(CreateZeroDurationSession());
            _trackManager = new TrackManager(_sessionsManager);
            var tracks = _trackManager.GetPossibleTracks(_events);
            Assert.IsTrue(tracks.Count == 0);
        }

        [TestMethod]
        public void SessionWithWholeDayDurationAndNoEventsReturnsNoTracks()
        {
            _sessionsManager.Stub(p => p.GetAllPossibleSessions()).Return(CreateSessionWithDurationFor8Hours());
            _trackManager = new TrackManager(_sessionsManager);
            var tracks = _trackManager.GetPossibleTracks(_events);
            Assert.IsTrue(tracks.Count == 0);
        }

        [TestMethod]
        public void SessionWithWholeDayDurationAndOneEventWithSameDuration()
        {
            _sessionsManager.Stub(p => p.GetAllPossibleSessions()).Return(CreateSessionWithDurationFor8Hours());
            _trackManager = new TrackManager(_sessionsManager);
            _events.Add(new TalkEvent("test", CreateSessionWithDurationFor8Hours().Sum(p => p.Duration)));            
            var tracks = _trackManager.GetPossibleTracks(_events);
            Assert.IsTrue(tracks.Count == 1);
            Assert.IsTrue(tracks.First().Sessions.Any());
            Assert.IsTrue(tracks.First().Sessions.First().Events.Any());
            Assert.IsTrue(tracks.First().Sessions.First().Events.First().IsScheduled);
        }
    }
}
