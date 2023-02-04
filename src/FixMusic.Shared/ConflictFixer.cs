using System;

namespace FixMusic
{
    public class ConflictFixer : ITrackCommand
    {
        public void Execute(ITrack track, ITrackCollection collection)
        {
            if (track is null)
            {
                throw new ArgumentNullException(nameof(track));
            }

            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (track.Metadata.AlbumArtists.Length > 0 || track.Metadata.Performers.Length > 0)
            {
                string value = string.Empty;
                if (track.Metadata.AlbumArtists.Length == 0)
                {
                    track.Metadata.AlbumArtists = track.Metadata.Performers;
                }
                else if (track.Metadata.Performers.Length == 0)
                {
                    track.Metadata.Performers = track.Metadata.AlbumArtists;
                }
            }
        }
    }
}
