using System.Collections.Generic;
using System.IO;

namespace FixMusic
{
    public interface ITrackCollection
    {
        IReadOnlyCollection<int> MaxTrackNumbers { get; }
        int TotalDiscs { get; }

        void Rename(string format, string fileNameFormatVariousArtists);
        void Save();
        ITrack Add(FileInfo file);
        int GetTracksAcrossDiscs(int discNumber);
        int GetTracksAcrossAllDiscs();
    }
}