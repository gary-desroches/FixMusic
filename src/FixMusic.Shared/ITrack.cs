using System.IO;
using TagLib;

namespace FixMusic
{
    public interface ITrack
    {
        FileInfo File { get; }
        Tag Metadata { get; }
        string Format(string format);
        void Move(FileInfo destination);
        void Move(string destinationDirectoryFormat);
        void Rename(string format, string fileNameFormatVariousArtists);
        void Save();
    }
}