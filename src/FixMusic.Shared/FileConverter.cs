using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FixMusic
{
    public class FileConverter : ITrackCommand
    {
        public FileConverter(FileInfo converterExecutable, string converterArgumentsFormat, string targetExtension)
        {
            if (converterExecutable is null)
            {
                throw new ArgumentNullException(nameof(converterExecutable));
            }

            if (String.IsNullOrEmpty(converterArgumentsFormat))
            {
                throw new ArgumentException($"{nameof(converterArgumentsFormat)} cannot be null or empty", nameof(converterArgumentsFormat));
            }

            if (String.IsNullOrEmpty(targetExtension))
            {
                throw new ArgumentException($"{nameof(targetExtension)} cannot be null or empty", nameof(targetExtension));
            }

            _converterExecutable = converterExecutable;
            _converterArgumentsFormat = converterArgumentsFormat;
            _targetExtension = targetExtension;
        }

        public void Execute(ITrack sourceTrack, ITrackCollection collection)
        {
            if (sourceTrack is null)
            {
                throw new ArgumentNullException(nameof(sourceTrack));
            }

            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (String.Compare(sourceTrack.File.Extension, $".{_targetExtension}") == 0)
            {
                return;
            }

            var targetFile = new FileInfo(sourceTrack.File.FullName.Replace(sourceTrack.File.GetExtension(), $".{_targetExtension}", StringComparison.CurrentCultureIgnoreCase));
            if (!targetFile.Exists)
            {
                var startInfo = new ProcessStartInfo()
                {
                    FileName = _converterExecutable.FullName,
                    CreateNoWindow = true,
                    ErrorDialog = false,
                    WorkingDirectory = _converterExecutable.Directory!.FullName,
                    //Arguments = $"-y -i \"{sourceTrack.File.FullName}\" -codec:a libmp3lame -q:a 0 -map_metadata 0 -id3v2_version 3 -write_id3v1 1 -c:v copy \"{mp3File.FullName}\""
                    //Arguments = $"-y -i \"{sourceTrack.File.FullName}\" -map_metadata -1 -codec:a libmp3lame -q:a 0 -c:v copy \"{mp3File.FullName}\""
                    // -y -i "%sourceTrack%" -map_metadata -1 -codec:a libmp3lame -q:a 0 -c:v copy "%destinationTrack%"
                    Arguments = _converterArgumentsFormat
                        .Replace("%sourcetrack%", $"{sourceTrack.File.FullName}", StringComparison.CurrentCultureIgnoreCase)
                        .Replace("%destinationtrack%", $"{targetFile.FullName}", StringComparison.CurrentCultureIgnoreCase)
                };

                var process = new Process()
                {
                    StartInfo = startInfo
                };

                process.Start();
                process.WaitForExit();
            }

            if (targetFile.Exists)
            {
                ITrack convertedTrack = collection.Add(targetFile);
                CopyMetadata(sourceTrack, convertedTrack);
            }
        }

        private static void CopyMetadata(ITrack sourceTrack, ITrack destinationTrack)
        {
            bool wasChanged = false;
            if (destinationTrack.Metadata.Album != sourceTrack.Metadata.Album)
            {
                destinationTrack.Metadata.Album = sourceTrack.Metadata.Album;
                wasChanged = true;
            }
            if (!destinationTrack.Metadata.AlbumArtists.SequenceEqual(sourceTrack.Metadata.AlbumArtists))
            {
                destinationTrack.Metadata.AlbumArtists = (string[])sourceTrack.Metadata.AlbumArtists.Clone();
                wasChanged = true;
            }
            if (!destinationTrack.Metadata.Performers.SequenceEqual(sourceTrack.Metadata.Performers))
            {
                destinationTrack.Metadata.Performers = (string[])sourceTrack.Metadata.Performers.Clone();
                wasChanged = true;
            }
            if (!destinationTrack.Metadata.Composers.SequenceEqual(sourceTrack.Metadata.Composers))
            {
                destinationTrack.Metadata.Composers = (string[])sourceTrack.Metadata.Composers.Clone();
                wasChanged = true;
            }
            if (!destinationTrack.Metadata.Genres.SequenceEqual(sourceTrack.Metadata.Genres))
            {
                destinationTrack.Metadata.Genres = (string[])sourceTrack.Metadata.Genres.Clone();
                wasChanged = true;
            }
            if (destinationTrack.Metadata.Comment != sourceTrack.Metadata.Comment)
            {
                destinationTrack.Metadata.Comment = sourceTrack.Metadata.Comment;
                wasChanged = true;
            }
            if (destinationTrack.Metadata.Lyrics != sourceTrack.Metadata.Lyrics)
            {
                destinationTrack.Metadata.Lyrics = sourceTrack.Metadata.Lyrics;
                wasChanged = true;
            }
            if (destinationTrack.Metadata.Title != sourceTrack.Metadata.Title)
            {
                destinationTrack.Metadata.Title = sourceTrack.Metadata.Title;
                wasChanged = true;
            }
            if (destinationTrack.Metadata.Year != sourceTrack.Metadata.Year)
            {
                destinationTrack.Metadata.Year = sourceTrack.Metadata.Year;
                wasChanged = true;
            }
            if (destinationTrack.Metadata.Disc != sourceTrack.Metadata.Disc)
            {
                destinationTrack.Metadata.Disc = sourceTrack.Metadata.Disc;
                wasChanged = true;
            }
            if (destinationTrack.Metadata.DiscCount != sourceTrack.Metadata.DiscCount)
            {
                destinationTrack.Metadata.DiscCount = sourceTrack.Metadata.DiscCount;
                wasChanged = true;
            }

            bool id3v2Found = false;
            if (destinationTrack.Metadata is TagLib.CombinedTag combinedTag)
            {
                IEnumerable<TagLib.Id3v2.Tag> id3v2Tags =
                    from tag in combinedTag.Tags
                    where tag is TagLib.Id3v2.Tag
                    select (TagLib.Id3v2.Tag)tag;

                if (id3v2Tags.Count() > 0)
                {
                    id3v2Found = true;
                    TagLib.Id3v2.Tag id3v2Tag = id3v2Tags.First()!;
                    wasChanged =
                        id3v2Tag.SetTrackAndTotal(sourceTrack.Metadata.Track, sourceTrack.Metadata.TrackCount)
                        ? true
                        : wasChanged;
                }
            }

            if (!id3v2Found)
            {
                if (destinationTrack.Metadata.Track != sourceTrack.Metadata.Track)
                {
                    destinationTrack.Metadata.Track = sourceTrack.Metadata.Track;
                    wasChanged = true;
                }
                if (destinationTrack.Metadata.TrackCount != sourceTrack.Metadata.TrackCount)
                {
                    destinationTrack.Metadata.TrackCount = sourceTrack.Metadata.TrackCount;
                    wasChanged = true;
                }
            }

            if (wasChanged)
            {
                destinationTrack.Save();
            }
        }

        private readonly FileInfo _converterExecutable;
        private readonly string _converterArgumentsFormat;
        private readonly string _targetExtension;
    }
}
