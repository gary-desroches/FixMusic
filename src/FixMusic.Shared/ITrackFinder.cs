using System.Collections.Generic;

namespace FixMusic
{
    public interface ITrackFinder
    {
        IEnumerable<ITrack> FindTracks(string filter);
    }
}