using System;
using System.Collections.Generic;
using System.IO;

namespace FixMusic
{
    public class CoverArtAssigner : ITrackCommand
    {
        public CoverArtAssigner(DirectoryInfo coverArtDirectory, string fileNameFormat, IEnumerable<string> extensions)
        {
            if (coverArtDirectory is null)
            {
                throw new ArgumentNullException(nameof(coverArtDirectory));
            }

            if (String.IsNullOrEmpty(fileNameFormat))
            {
                throw new ArgumentException($"{nameof(fileNameFormat)} cannot be null or empty", nameof(fileNameFormat));
            }

            if (extensions is null)
            {
                throw new ArgumentNullException(nameof(extensions));
            }

            _coverArtDirectory = coverArtDirectory;
            _fileNameFormat = fileNameFormat;
            _extensions = extensions;
        }

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

            if (track.Metadata.Pictures.Length == 0)
            {
                foreach (string extension in _extensions)
                {
                    var coverArtFile = new FileInfo(
                        Path.Combine(
                            _coverArtDirectory.FullName,
                            $"{track.Format(_fileNameFormat)}.{extension}"
                        )
                    );

                    if (coverArtFile.Exists)
                    {
                        track.Metadata.Pictures = new TagLib.IPicture[]
                        {
                            new TagLib.Picture(coverArtFile.FullName)
                        };

                        break;
                    }
                }
            }
        }

        private readonly DirectoryInfo _coverArtDirectory;
        private readonly string _fileNameFormat;
        private readonly IEnumerable<string> _extensions;
    }
}
