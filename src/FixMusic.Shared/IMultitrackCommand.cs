using System.Collections.Generic;

namespace FixMusic
{
    public interface IMultitrackCommand
    {
        void Execute(IEnumerable<ITrack> tracks, ITrackCollection collection);
    }
}
