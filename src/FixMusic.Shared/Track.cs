using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace FixMusic
{
    public class Track : IDisposable, ITrack
    {
        public Track(FileInfo file, TagLib.File tagFile, IEnumerable<MetadataFieldFileNameReplacement> metadataFieldFileNameReplacements)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (tagFile is null)
            {
                throw new ArgumentNullException(nameof(tagFile));
            }

            if (metadataFieldFileNameReplacements is null)
            {
                throw new ArgumentNullException(nameof(metadataFieldFileNameReplacements));
            }

            _file = file;
            _tagFile = tagFile;
            _metadataFieldFileNameReplacements = metadataFieldFileNameReplacements;
        }

        public string Format(string format)
        {
            Debug.Assert(!String.IsNullOrEmpty(format));

            return format
                .Replace("%artist%", FormatField(Metadata.Performers[0]), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%albumartist%", FormatField(Metadata.AlbumArtists[0]), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%album%", FormatField(Metadata.Album), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%title%", FormatField(Metadata.Title), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%tracknumber%", FormatField(Metadata.Track.ToString("00")), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%totaltracks%", FormatField(Metadata.TrackCount.ToString()), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%discnumber%", FormatField(Metadata.Disc.ToString()), StringComparison.CurrentCultureIgnoreCase)
                .Replace("%totaldiscs%", FormatField(Metadata.DiscCount.ToString()), StringComparison.CurrentCultureIgnoreCase);
        }

        private string FormatField(string metadataField)
        {
            Debug.Assert(!String.IsNullOrEmpty(metadataField));

            string replacementText = metadataField;
            foreach (var replacement in _metadataFieldFileNameReplacements)
            {
                replacementText = replacementText.Replace(replacement.Find, replacement.Replace, StringComparison.CurrentCultureIgnoreCase);
            }

            return replacementText;

            /*return metadataField
                .Replace("*", "+", StringComparison.CurrentCultureIgnoreCase)
                .Replace("\\", "-", StringComparison.CurrentCultureIgnoreCase)
                .Replace("/", "-", StringComparison.CurrentCultureIgnoreCase)
                .Replace(":", "", StringComparison.CurrentCultureIgnoreCase);*/
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

            string formatted = string.Empty;
            if (Metadata.AlbumArtists[0].Length > 0 && Metadata.Performers[0].Length > 0
             && Metadata.AlbumArtists[0] != Metadata.Performers[0])
            {
                formatted = fileNameFormatVariousArtists;
            }
            else
            {
                formatted = format;
            }

            var destination = new FileInfo(
                Path.Combine(
                    _file.Directory!.FullName,
                    $"{Format(formatted)}{_file.Extension}"
                )
            );

            if (!_file.Compare(destination))
            {
                _file.MoveTo(destination.FullName);
                _file = destination;
            }
        }

        public void Move(FileInfo destination)
        {
            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (!_file.Compare(destination))
            {
                if (!destination.Directory!.Exists)
                {
                    destination.Directory.Create();
                }

                _file.MoveTo(destination.FullName);
                _file = destination;
            }
        }

        public void Move(string destinationDirectoryFormat)
        {
            if (String.IsNullOrEmpty(destinationDirectoryFormat))
            {
                throw new ArgumentException($"{nameof(destinationDirectoryFormat)} cannot be null or empty", nameof(destinationDirectoryFormat));
            }

            var destinationFile = new FileInfo(
                Path.Combine(
                    Format(destinationDirectoryFormat),
                    _file.Name
                )
            );

            Move(destinationFile);
        }

        public void Save()
        {
            _tagFile.Save();
        }

        private FileInfo _file;
        public FileInfo File => _file;

        private readonly TagLib.File _tagFile;
        public TagLib.Tag Metadata => _tagFile.Tag;

        private readonly IEnumerable<MetadataFieldFileNameReplacement> _metadataFieldFileNameReplacements;
        public IEnumerable<MetadataFieldFileNameReplacement> MetadataFieldFileNameReplacements => _metadataFieldFileNameReplacements;

        #region Dispose Pattern

        protected virtual void Dispose(bool isExplicit)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isExplicit)
            {
                _tagFile.Dispose();
            }

            _isDisposed = true;
        }

        public void Dispose() => Dispose(isExplicit: true);

        private bool _isDisposed;

        #endregion
    }
}
