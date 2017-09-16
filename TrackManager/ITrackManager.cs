using System.Collections.Generic;
using TrackManagement.Models;

namespace TrackManagement
{
    public interface ITrackManager
    {
        List<Track> GetPossibleTracks(List<Event> events);
    }
}
