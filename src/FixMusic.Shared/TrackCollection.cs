/*

Copyright (c) 2023 Gary Des Roches

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation files
(the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

Any person wishing to distribute modifications to the Software is
asked to send the modifications to the original developer so that
they can be incorporated into the canonical version.  This is,
however, not a binding provision of this license.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FixMusic
{
    public class TrackCollection : IDisposable, ITrackCollection
    {
        public TrackCollection(ITrackFactory trackFactory, ITrackFinder trackFinder, string sourceFilter, string newFileNameFormat)
        {
            if (trackFactory is null)
            {
                throw new ArgumentNullException(nameof(trackFactory));
            }

            if (trackFinder is null)
            {
                throw new ArgumentNullException(nameof(trackFinder));
            }

            if (String.IsNullOrEmpty(sourceFilter))
            {
                throw new ArgumentException($"{nameof(sourceFilter)} cannot be null or empty", nameof(sourceFilter));
            }

            if (String.IsNullOrEmpty(newFileNameFormat))
            {
                throw new ArgumentException($"{nameof(newFileNameFormat)} cannot be null or empty", nameof(newFileNameFormat));
            }

            _trackFactory = trackFactory;
            _newFileNameFormat = newFileNameFormat;
            _tracks = new List<ITrack>();

            foreach (ITrack track in trackFinder.FindTracks(sourceFilter))
            {
                Add(track);
            }
        }

        public void ExecuteCommands(IEnumerable<ITrackCommand> commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            foreach (ITrack track in _tracks.ToList())
            {
                foreach (ITrackCommand command in commands)
                {
                    command.Execute(track, this);
                }
            }
        }

        public void ExecuteCommandsInParallel(IEnumerable<ITrackCommand> commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            Parallel.ForEach(
                _tracks.ToList(),
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                },
                (track) =>
                {
                    foreach (ITrackCommand command in commands)
                    {
                        command.Execute(track, this);
                    }
                }
            );
        }

        public void ExecuteMultitrackCommands(IEnumerable<IMultitrackCommand> commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            foreach (IMultitrackCommand command in commands)
            {
                command.Execute(_tracks, this);
            }
        }

        public void Save()
        {
            foreach (ITrack track in _tracks)
            {
                track.Save();
            }
        }

        public void Rename(string format, string fileNameFormatVariousArtists)
        {
            if (String.IsNullOrEmpty(format))
            {
                throw new ArgumentException($"{nameof(format)} cannot be null or empty", nameof(format));
            }

            if (String.IsNullOrEmpty(fileNameFormatVariousArtists))
            {
                throw new ArgumentException($"{nameof(fileNameFormatVariousArtists)} cannot be null or empty", nameof(fileNameFormatVariousArtists));
            }

            foreach (ITrack track in _tracks)
            {
                track.Rename(format, fileNameFormatVariousArtists);
            }
        }

        public ITrack Add(FileInfo file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            ITrack track = _trackFactory.Create(file);

            lock (this)
            {
                Add(track);
            }

            return track;
        }

        private void Add(ITrack track)
        {
            Debug.Assert(track != null);

            if (_tracks.Contains(track))
            {
                return;
            }

            if ((int)track.Metadata.Disc == 0)
            {
                track.Metadata.Disc = 1;
            }

            if ((int)track.Metadata.DiscCount == 0)
            {
                track.Metadata.DiscCount = 1;
            }

            _maxDiscNumber = Math.Max(_maxDiscNumber, (int)track.Metadata.Disc);

            while (_maxTrackNumbers.Count < _maxDiscNumber)
            {
                _maxTrackNumbers.Add(0);
            }

            if (track.Metadata.Disc > 0)
            {
                _maxTrackNumbers[(int)track.Metadata.Disc - 1] =
                    Math.Max(_maxTrackNumbers[(int)track.Metadata.Disc - 1], (int)track.Metadata.Track);
            }

            _tracks.Add(track);
        }

        public void Move(string destinationDirectoryFormat)
        {
            if (String.IsNullOrEmpty(destinationDirectoryFormat))
            {
                throw new ArgumentException($"{nameof(destinationDirectoryFormat)} cannot be null or empty", nameof(destinationDirectoryFormat));
            }

            foreach (ITrack track in _tracks)
            {
                track.Move(destinationDirectoryFormat);
            }
        }

        public int Count => _tracks.Count;

        private int _maxDiscNumber;
        public int TotalDiscs => _maxDiscNumber;

        private List<int> _maxTrackNumbers = new List<int>();
        public IReadOnlyCollection<int> MaxTrackNumbers => new ReadOnlyCollection<int>(_maxTrackNumbers);
        public int GetTracksAcrossDiscs(int discNumber)
        {
            return _maxTrackNumbers.Take((int)discNumber - 1).Aggregate((x, y) => x + y);
        }

        public int GetTracksAcrossAllDiscs()
        {
            return GetTracksAcrossDiscs(_maxTrackNumbers.Count - 1);
        }

        private readonly string _newFileNameFormat;
        private readonly List<ITrack> _tracks = new List<ITrack>();

        private readonly ITrackFactory _trackFactory;

        #region Dispose Pattern

        protected virtual void Dispose(bool isExplicit)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isExplicit)
            {
                foreach (Track track in _tracks)
                {
                    track.Dispose();
                }
            }

            _isDisposed = true;
        }

        public void Dispose() => Dispose(isExplicit: true);

        private bool _isDisposed;

        #endregion
    }
}
