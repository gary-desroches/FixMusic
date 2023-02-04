using System;
using System.Diagnostics;

namespace FixMusic
{
    public class TheMover : ITrackCommand
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

            track.Metadata.Album = MoveThe(track.Metadata.Album);
            track.Metadata.AlbumArtists[0] = MoveThe(track.Metadata.AlbumArtists[0]);
            track.Metadata.Performers[0] = MoveThe(track.Metadata.Performers[0]);
        }

        private string MoveThe(string text)
        {
            Debug.Assert(!String.IsNullOrEmpty(text));

            if (text.StartsWith("the ", StringComparison.CurrentCultureIgnoreCase))
            {
                string the = text[0..3];
                return $"{text[4..]}, {the}";
            }

            return text;
        }
    }
}
