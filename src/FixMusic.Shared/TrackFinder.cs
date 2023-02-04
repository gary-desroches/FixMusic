using System;
using System.Collections.Generic;
using System.IO;

namespace FixMusic
{
    public class TrackFinder : ITrackFinder
    {
        public TrackFinder(ITrackFactory trackFactory, DirectoryInfo sourceDirectory)
        {
            if (trackFactory is null)
            {
                throw new ArgumentNullException(nameof(trackFactory));
            }

            if (sourceDirectory is null)
            {
                throw new ArgumentNullException(nameof(sourceDirectory));
            }

            _trackFactory = trackFactory;
            _sourceDirectory = sourceDirectory;
        }

        public IEnumerable<ITrack> FindTracks(string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                throw new ArgumentException($"{nameof(filter)} cannot be null or empty", nameof(filter));
            }

            foreach (FileInfo file in _sourceDirectory.EnumerateFiles(filter))
            {
                yield return _trackFactory.Create(file);
            }
        }

        private readonly ITrackFactory _trackFactory;
        private readonly DirectoryInfo _sourceDirectory;
    }
}
