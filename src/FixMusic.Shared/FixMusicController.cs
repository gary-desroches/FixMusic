using System;

namespace FixMusic
{
    public class FixMusicController : IFixMusicController
    {
        public FixMusicController()
        {
        }

        public string MusicLibraryPath
        {
            set { OnMusicLibraryDirectoryChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _MusicLibraryDirectoryChanged;
        public event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged
        {
            add { _MusicLibraryDirectoryChanged += value; }
            remove { _MusicLibraryDirectoryChanged -= value; }
        }
        protected virtual void OnMusicLibraryDirectoryChanged(ValueEventArgs<string> ea)
        {
            _MusicLibraryDirectoryChanged?.Invoke(this, ea);
        }

        public string MusicLibraryPathFormat
        {
            set { OnMusicLibraryDirectoryFormatChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _MusicLibraryDirectoryFormatChanged;
        public event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged
        {
            add { _MusicLibraryDirectoryFormatChanged += value; }
            remove { _MusicLibraryDirectoryFormatChanged -= value; }
        }
        protected virtual void OnMusicLibraryDirectoryFormatChanged(ValueEventArgs<string> ea)
        {
            _MusicLibraryDirectoryFormatChanged?.Invoke(this, ea);
        }

        public string SourcePath
        {
            set { OnSourceDirectoryChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _SourceDirectoryChanged;
        public event EventHandler<ValueEventArgs<string>> SourcePathChanged
        {
            add { _SourceDirectoryChanged += value; }
            remove { _SourceDirectoryChanged -= value; }
        }
        protected virtual void OnSourceDirectoryChanged(ValueEventArgs<string> ea)
        {
            _SourceDirectoryChanged?.Invoke(this, ea);
        }

        public string CoverArtPath
        {
            set { OnCoverArtDirectoryChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _CoverArtDirectoryChanged;
        public event EventHandler<ValueEventArgs<string>> CoverArtPathChanged
        {
            add { _CoverArtDirectoryChanged += value; }
            remove { _CoverArtDirectoryChanged -= value; }
        }
        protected virtual void OnCoverArtDirectoryChanged(ValueEventArgs<string> ea)
        {
            _CoverArtDirectoryChanged?.Invoke(this, ea);
        }

        public string CoverArtFileNameFormat
        {
            set { OnCoverArtFileNameFormatChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _CoverArtFileNameFormatChanged;
        public event EventHandler<ValueEventArgs<string>> CoverArtFileNameFormatChanged
        {
            add { _CoverArtFileNameFormatChanged += value; }
            remove { _CoverArtFileNameFormatChanged -= value; }
        }
        protected virtual void OnCoverArtFileNameFormatChanged(ValueEventArgs<string> ea)
        {
            _CoverArtFileNameFormatChanged?.Invoke(this, ea);
        }

        public string CoverArtExtensions
        {
            set { OnCoverArtExtensionsChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _CoverArtExtensionsChanged;
        public event EventHandler<ValueEventArgs<string>> CoverArtExtensionsChanged
        {
            add { _CoverArtExtensionsChanged += value; }
            remove { _CoverArtExtensionsChanged -= value; }
        }
        protected virtual void OnCoverArtExtensionsChanged(ValueEventArgs<string> ea)
        {
            _CoverArtExtensionsChanged?.Invoke(this, ea);
        }

        public string ConverterExtension
        {
            set { OnConverterExtensionChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _ConverterExtensionChanged;
        public event EventHandler<ValueEventArgs<string>> ConverterExtensionChanged
        {
            add { _ConverterExtensionChanged += value; }
            remove { _ConverterExtensionChanged -= value; }
        }
        protected virtual void OnConverterExtensionChanged(ValueEventArgs<string> ea)
        {
            _ConverterExtensionChanged?.Invoke(this, ea);
        }

        public string FileNameFormat
        {
            set { OnFileNameFormatChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _FileNameFormatChanged;
        public event EventHandler<ValueEventArgs<string>> FileNameFormatChanged
        {
            add { _FileNameFormatChanged += value; }
            remove { _FileNameFormatChanged -= value; }
        }
        protected virtual void OnFileNameFormatChanged(ValueEventArgs<string> ea)
        {
            _FileNameFormatChanged?.Invoke(this, ea);
        }

        public string SourceFilter
        {
            set { OnSourceFilterChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _SourceFilterChanged;
        public event EventHandler<ValueEventArgs<string>> SourceFilterChanged
        {
            add { _SourceFilterChanged += value; }
            remove { _SourceFilterChanged -= value; }
        }
        protected virtual void OnSourceFilterChanged(ValueEventArgs<string> ea)
        {
            _SourceFilterChanged?.Invoke(this, ea);
        }

        public string ConverterExecutablePath
        {
            set { OnConverterExecutablePathChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _ConverterExecutablePathChanged;
        public event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged
        {
            add { _ConverterExecutablePathChanged += value; }
            remove { _ConverterExecutablePathChanged -= value; }
        }
        protected virtual void OnConverterExecutablePathChanged(ValueEventArgs<string> ea)
        {
            _ConverterExecutablePathChanged?.Invoke(this, ea);
        }

        public string ConverterArgumentsFormat
        {
            set { OnConverterArgumentsFormatChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _ConverterArgumentsFormatChanged;
        public event EventHandler<ValueEventArgs<string>> ConverterArgumentsFormatChanged
        {
            add { _ConverterArgumentsFormatChanged += value; }
            remove { _ConverterArgumentsFormatChanged -= value; }
        }
        protected virtual void OnConverterArgumentsFormatChanged(ValueEventArgs<string> ea)
        {
            _ConverterArgumentsFormatChanged?.Invoke(this, ea);
        }

        public string FileNameFormatVariousArtists
        {
            set { OnFileNameFormatVariousArtistsChanged(new ValueEventArgs<string>(value)); }
        }
        private event EventHandler<ValueEventArgs<string>>? _FileNameFormatVariousArtistsChanged;
        public event EventHandler<ValueEventArgs<string>> FileNameFormatVariousArtistsChanged
        {
            add { _FileNameFormatVariousArtistsChanged += value; }
            remove { _FileNameFormatVariousArtistsChanged -= value; }
        }
        protected virtual void OnFileNameFormatVariousArtistsChanged(ValueEventArgs<string> ea)
        {
            _FileNameFormatVariousArtistsChanged?.Invoke(this, ea);
        }


        public bool FixArtistConflicts
        {
            set { OnFixedArtistConflictsChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _FixedArtistConflictsChanged;
        public event EventHandler<ValueEventArgs<bool>> FixedArtistConflictsChanged
        {
            add { _FixedArtistConflictsChanged += value; }
            remove { _FixedArtistConflictsChanged -= value; }
        }
        protected virtual void OnFixedArtistConflictsChanged(ValueEventArgs<bool> ea)
        {
            _FixedArtistConflictsChanged?.Invoke(this, ea);
        }

        public bool FillInTotalTracks
        {
            set { OnFillInTotalTracksChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _FillInTotalTracksChanged;
        public event EventHandler<ValueEventArgs<bool>> FillInTotalTracksChanged
        {
            add { _FillInTotalTracksChanged += value; }
            remove { _FillInTotalTracksChanged -= value; }
        }
        protected virtual void OnFillInTotalTracksChanged(ValueEventArgs<bool> ea)
        {
            _FillInTotalTracksChanged?.Invoke(this, ea);
        }

        public bool MoveThe
        {
            set { OnMoveTheChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _MoveTheChanged;
        public event EventHandler<ValueEventArgs<bool>> MoveTheChanged
        {
            add { _MoveTheChanged += value; }
            remove { _MoveTheChanged -= value; }
        }
        protected virtual void OnMoveTheChanged(ValueEventArgs<bool> ea)
        {
            _MoveTheChanged?.Invoke(this, ea);
        }

        public bool AssignCoverArt
        {
            set { OnAssignCoverArtChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _AssignCoverArtChanged;
        public event EventHandler<ValueEventArgs<bool>> AssignCoverArtChanged
        {
            add { _AssignCoverArtChanged += value; }
            remove { _AssignCoverArtChanged -= value; }
        }
        protected virtual void OnAssignCoverArtChanged(ValueEventArgs<bool> ea)
        {
            _AssignCoverArtChanged?.Invoke(this, ea);
        }

        public bool RollIntoOneDisc
        {
            set { OnRollIntoOneDiscChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _RollIntoOneDiscChanged;
        public event EventHandler<ValueEventArgs<bool>> RollIntoOneDiscChanged
        {
            add { _RollIntoOneDiscChanged += value; }
            remove { _RollIntoOneDiscChanged -= value; }
        }
        protected virtual void OnRollIntoOneDiscChanged(ValueEventArgs<bool> ea)
        {
            _RollIntoOneDiscChanged?.Invoke(this, ea);
        }

        public bool RenameFiles
        {
            set { OnRenameFilesChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _RenameFilesChanged;
        public event EventHandler<ValueEventArgs<bool>> RenameFilesChanged
        {
            add { _RenameFilesChanged += value; }
            remove { _RenameFilesChanged -= value; }
        }
        protected virtual void OnRenameFilesChanged(ValueEventArgs<bool> ea)
        {
            _RenameFilesChanged?.Invoke(this, ea);
        }

        public bool MoveFilesToMusicLibrary
        {
            set { OnMoveFilesToMusicLibraryChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _MoveFilesToMusicLibraryChanged;
        public event EventHandler<ValueEventArgs<bool>> MoveFilesToMusicLibraryChanged
        {
            add { _MoveFilesToMusicLibraryChanged += value; }
            remove { _MoveFilesToMusicLibraryChanged -= value; }
        }
        protected virtual void OnMoveFilesToMusicLibraryChanged(ValueEventArgs<bool> ea)
        {
            _MoveFilesToMusicLibraryChanged?.Invoke(this, ea);
        }

        public bool ConvertFiles
        {
            set { OnConvertFilesChanged(new ValueEventArgs<bool>(value)); }
        }
        private event EventHandler<ValueEventArgs<bool>>? _ConvertFilesChanged;
        public event EventHandler<ValueEventArgs<bool>> ConvertFilesChanged
        {
            add { _ConvertFilesChanged += value; }
            remove { _ConvertFilesChanged -= value; }
        }
        protected virtual void OnConvertFilesChanged(ValueEventArgs<bool> ea)
        {
            _ConvertFilesChanged?.Invoke(this, ea);
        }
    }
}
