using System.IO;

namespace FixMusic
{
    public interface ITrackFactory
    {
        ITrack Create(FileInfo file);
    }
}