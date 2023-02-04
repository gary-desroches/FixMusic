using System;
using System.Collections.Generic;
using System.IO;

namespace FixMusic
{
    public class TrackFactory : ITrackFactory
    {
        public TrackFactory(IEnumerable<MetadataFieldFileNameReplacement> metadataFieldFileNameReplacements)
        {
            if (metadataFieldFileNameReplacements is null)
            {
                throw new ArgumentNullException(nameof(metadataFieldFileNameReplacements));
            }

            _metadataFieldFileNameReplacements = metadataFieldFileNameReplacements;
        }

        public ITrack Create(FileInfo file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            return new Track(file, TagLib.File.Create(file.FullName), _metadataFieldFileNameReplacements);
        }
        
        private readonly IEnumerable<MetadataFieldFileNameReplacement> _metadataFieldFileNameReplacements;
    }
}
