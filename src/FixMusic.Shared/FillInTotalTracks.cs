using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixMusic
{
    public class FillInTotalTracks : ITrackCommand
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

            track.Metadata.TrackCount = (uint)collection.MaxTrackNumbers.ElementAt((int)track.Metadata.Disc - 1);
        }
    }
}
