using System;
using System.Collections.Generic;
using System.Linq;

namespace FixMusic
{
    public class OneDisc : IMultitrackCommand
    {
        public void Execute(IEnumerable<ITrack> tracks, ITrackCollection collection)
        {
            if (tracks is null)
            {
                throw new ArgumentNullException(nameof(tracks));
            }

            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection.TotalDiscs == 1)
            {
                return;
            }

            if (collection.TotalDiscs == 0)
            {
                foreach (ITrack track in tracks)
                {
                    track.Metadata.Disc = 1;
                    track.Metadata.DiscCount = 1;
                }
            }
            else
            {
                foreach (ITrack track in tracks)
                {
                    track.Metadata.DiscCount = 1;
                    track.Metadata.TrackCount = (uint)collection.GetTracksAcrossAllDiscs();

                    if (track.Metadata.Disc > 1)
                    {
                        track.Metadata.Track += (uint)collection.GetTracksAcrossDiscs((int)track.Metadata.Disc);
                        track.Metadata.Disc = 1;
                    }
                }
            }
        }
    }
}
