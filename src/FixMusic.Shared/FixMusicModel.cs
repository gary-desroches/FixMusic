using System;
using System.Collections.Generic;
using System.IO;

namespace FixMusic
{
    public class FixMusicModel : IFixMusicModel
    {
        public FixMusicModel(IAppSettings appSettings, IFixMusicController controller, IErrorPresenter errorPresenter)
        {
            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }

            if (controller is null)
            {
                throw new ArgumentNullException(nameof(controller));
            }

            if (errorPresenter is null)
            {
                throw new ArgumentNullException(nameof(errorPresenter));
            }

            _appSettings = appSettings;
            _errorPresenter = errorPresenter;

            _controller = controller;

            _controller.ConvertFilesChanged += _controller_ConvertFilesChanged;
            _controller.AssignCoverArtChanged += _controller_AssignCoverArtChanged;
            _controller.CoverArtPathChanged += _controller_CoverArtDirectoryChanged;
            _controller.CoverArtFileNameFormatChanged += _controller_CoverArtFileNameFormatChanged;
            _controller.CoverArtExtensionsChanged += _controller_CoverArtExtensionsChanged;
            _controller.ConverterExtensionChanged += _controller_ConverterExtensionChanged;
            _controller.FileNameFormatChanged += _controller_FileNameFormatChanged;
            _controller.FileNameFormatVariousArtistsChanged += _controller_FileNameFormatVariousArtistsChanged;
            _controller.FixedArtistConflictsChanged += _controller_FixedArtistConflictsChanged;
            _controller.SourcePathChanged += _controller_SourceDirectoryChanged;
            _controller.MoveFilesToMusicLibraryChanged += _controller_MoveFilesToMusicLibraryChanged;
            _controller.MoveTheChanged += _controller_MoveTheChanged;
            _controller.ConverterArgumentsFormatChanged += _controller_ConverterArgumentsFormatChanged;
            _controller.ConverterExecutablePathChanged += _controller_ConverterExecutablePathChanged;
            _controller.MusicLibraryPathFormatChanged += _controller_MusicLibraryDirectoryFormatChanged;
            _controller.RenameFilesChanged += _controller_RenameFilesChanged;
            _controller.RollIntoOneDiscChanged += _controller_RollIntoOneDiscChanged;
            _controller.FillInTotalTracksChanged += _controller_FillInTotalTracksChanged;
        }

        private void _controller_FillInTotalTracksChanged(object? sender, ValueEventArgs<bool> ea) => FillInTotalTracks = ea.Value;
        private void _controller_ConverterExtensionChanged(object? sender, ValueEventArgs<string> ea) => ConverterExtension = ea.Value;
        private void _controller_CoverArtExtensionsChanged(object? sender, ValueEventArgs<string> ea) => CoverArtExtensions = ea.Value;
        private void _controller_CoverArtFileNameFormatChanged(object? sender, ValueEventArgs<string> ea) => CoverArtFileNameFormat = ea.Value;
        private void _controller_RollIntoOneDiscChanged(object? sender, ValueEventArgs<bool> ea) => RollIntoOneDisc = ea.Value;
        private void _controller_RenameFilesChanged(object? sender, ValueEventArgs<bool> ea) => RenameFiles = ea.Value;
        private void _controller_MusicLibraryDirectoryFormatChanged(object? sender, ValueEventArgs<string> ea) => MusicLibraryPathFormat = ea.Value;
        private void _controller_ConverterExecutablePathChanged(object? sender, ValueEventArgs<string> ea) => ConverterExecutablePath = ea.Value;
        private void _controller_ConverterArgumentsFormatChanged(object? sender, ValueEventArgs<string> ea) => ConverterArgumentsFormat = ea.Value;
        private void _controller_MoveTheChanged(object? sender, ValueEventArgs<bool> ea) => MoveThe = ea.Value;
        private void _controller_MoveFilesToMusicLibraryChanged(object? sender, ValueEventArgs<bool> ea) => MoveFilesToMusicLibrary = ea.Value;
        private void _controller_SourceDirectoryChanged(object? sender, ValueEventArgs<string> ea) => SourcePath = ea.Value;
        private void _controller_FixedArtistConflictsChanged(object? sender, ValueEventArgs<bool> ea) => FixArtistConflicts = ea.Value;
        private void _controller_FileNameFormatVariousArtistsChanged(object? sender, ValueEventArgs<string> ea) => FileNameFormatVariousArtists = ea.Value;
        private void _controller_FileNameFormatChanged(object? sender, ValueEventArgs<string> ea) => FileNameFormat = ea.Value;
        private void _controller_CoverArtDirectoryChanged(object? sender, ValueEventArgs<string> ea) => CoverArtPath = ea.Value;
        private void _controller_AssignCoverArtChanged(object? sender, ValueEventArgs<bool> ea) => AssignCoverArt = ea.Value;
        private void _controller_ConvertFilesChanged(object? sender, ValueEventArgs<bool> ea) => ConvertFiles = ea.Value;

        private bool Validate()
        {
            if (SourcePath == null)
            {
                _errorPresenter.DisplayError("Input directory not set.");
                return false;
            }

            if (!Directory.Exists(SourcePath))
            {
                _errorPresenter.DisplayError("Input directory could not be found.");
                return false;
            }

            if (AssignCoverArt)
            {
                if (!Directory.Exists(CoverArtPath))
                {
                    _errorPresenter.DisplayError("Cover art directory could not be found.");
                    return false;
                }

                if (String.IsNullOrEmpty(CoverArtFileNameFormat))
                {
                    _errorPresenter.DisplayError("Cover art file name format cannot be empty.");
                    return false;
                }

                if (String.IsNullOrEmpty(CoverArtExtensions))
                {
                    _errorPresenter.DisplayError("Cover art extensions cannot be empty.");
                    return false;
                }
            }

            if (ConvertFiles)
            {
                if (!File.Exists(ConverterExecutablePath))
                {
                    _errorPresenter.DisplayError("Converter exeutable file could not be found.");
                    return false;
                }

                if (String.IsNullOrEmpty(ConverterArgumentsFormat))
                {
                    _errorPresenter.DisplayError($"{nameof(ConverterArgumentsFormat)} cannot be null or empty.");
                    return false;
                }

                if (String.IsNullOrEmpty(ConverterExtension))
                {
                    _errorPresenter.DisplayError($"{nameof(ConverterExtension)} cannot be null or empty.");
                    return false;
                }
            }

            return true;
        }

        public void Start()
        {
            if (!Validate())
            {
                return;
            }

            var trackFactory = new TrackFactory(_appSettings.MetadataFieldFileNameReplacements);
            var trackFinder = new TrackFinder(trackFactory, new DirectoryInfo(SourcePath));
            using var tracks = new TrackCollection(trackFactory, trackFinder, SourceFilter, FileNameFormat);
            var firstCommands = new List<ITrackCommand>();

            if (FixArtistConflicts)
            {
                firstCommands.Add(new ConflictFixer());
            }

            if (FillInTotalTracks)
            {
                firstCommands.Add(new FillInTotalTracks());
            }

            if (AssignCoverArt)
            {
                firstCommands.Add(
                    new CoverArtAssigner(
                        new DirectoryInfo(CoverArtPath),
                        CoverArtFileNameFormat,
                        CoverArtExtensions.Split(',')
                    )
                );
            }

            if (MoveThe)
            {
                firstCommands.Add(new TheMover());
            }

            bool metadataChanged = false;
            if (firstCommands.Count > 0)
            {
                metadataChanged = true;
                tracks.ExecuteCommands(firstCommands);
            }

            if (RollIntoOneDisc)
            {
                metadataChanged = true;
                tracks.ExecuteMultitrackCommands(new IMultitrackCommand[] { new OneDisc() });
            }

            if (metadataChanged)
            {
                tracks.Save();
            }

            if (RenameFiles)
            {
                tracks.Rename(FileNameFormat, FileNameFormatVariousArtists);
            }

            if (MoveFilesToMusicLibrary)
            {
                tracks.Move(Path.Combine(MusicLibraryPath, MusicLibraryPathFormat));
            }

            if (ConvertFiles)
            {
                tracks.ExecuteCommandsInParallel(new ITrackCommand[] { new FileConverter(new FileInfo(ConverterExecutablePath), ConverterArgumentsFormat, ConverterExtension) });
            }
        }

        private readonly IErrorPresenter _errorPresenter;

        public string MusicLibraryPath
        {
            get => _appSettings.MusicLibraryPath;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(MusicLibraryPath));
                }

                if (String.Compare(_appSettings.MusicLibraryPath, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.MusicLibraryPath = value;
                    OnMusicLibraryPathChanged(new ValueEventArgs<string>(value));
                }
            }
        }


        public string MusicLibraryPathFormat
        {
            get => _appSettings.MusicLibraryPathFormat;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(MusicLibraryPathFormat));
                }

                if (String.Compare(_appSettings.MusicLibraryPathFormat, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.MusicLibraryPathFormat = value;
                    OnMusicLibraryDirectoryFormatChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        private string _sourcePath = string.Empty;
        public string SourcePath
        {
            get => _sourcePath;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(SourcePath));
                }

                if (string.Compare(_sourcePath, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _sourcePath = value;
                    OnSourcePathChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        public string CoverArtPath
        {
            get => _appSettings.CoverArtPath;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(CoverArtPath));
                }

                if (string.Compare(_appSettings.CoverArtPath, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.CoverArtPath = value;
                    OnCoverArtPathChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        public string FileNameFormat
        {
            get => _appSettings.FileNameFormat;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(FileNameFormat)} cannot be null or empty", nameof(FileNameFormat));
                }

                if (String.Compare(_appSettings.FileNameFormat, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.FileNameFormat = value;
                    OnFileNameFormatChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        public string ConverterExecutablePath
        {
            get => _appSettings.ConverterExecutablePath;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(ConverterExecutablePath));
                }

                if (string.Compare(_appSettings.ConverterExecutablePath, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.ConverterExecutablePath = value;
                    OnConverterExecutablePathChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        public string FileNameFormatVariousArtists
        {
            get => _appSettings.FileNameFormatVariousArtists;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(FileNameFormatVariousArtists)} cannot be null or empty", nameof(FileNameFormatVariousArtists));
                }

                if (String.Compare(_appSettings.FileNameFormatVariousArtists, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.FileNameFormatVariousArtists = value;
                    OnFileNameFormatVariousArtistsChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        public string SourceFilter
        {
            get => _appSettings.SourceFilter;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(SourceFilter)} cannot be null or empty", nameof(SourceFilter));
                }

                if (String.Compare(_appSettings.SourceFilter, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.SourceFilter = value;
                    OnSourceFilterChanged(new ValueEventArgs<string>(value));
                }
            }
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

        public string ConverterArgumentsFormat
        {
            get => _appSettings.ConverterArgumentsFormat;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(ConverterArgumentsFormat));
                }

                if (String.Compare(_appSettings.ConverterArgumentsFormat, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.ConverterArgumentsFormat = value;
                    OnConverterArgumentsFormatChanged(new ValueEventArgs<string>(value));
                }
            }
        }

        //private bool _fixArtistConflicts;
        public bool FixArtistConflicts
        {
            get => _appSettings.FixArtistConflicts;
            set
            {
                if (this._appSettings.FixArtistConflicts != value)
                {
                    _appSettings.FixArtistConflicts = value;
                    OnFixedArtistConflictsChanged(new ValueEventArgs<bool>(value));
                }
            }
        }


        //private bool _fillInTotalTracks;
        public bool FillInTotalTracks
        {
            get => _appSettings.FillInTotalTracks;
            set
            {
                if (_appSettings.FillInTotalTracks != value)
                {
                    _appSettings.FillInTotalTracks = value;
                    OnFillInTotalTracksChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _moveThe;
        public bool MoveThe
        {
            get => _appSettings.MoveThe;
            set
            {
                if (_appSettings.MoveThe != value)
                {
                    _appSettings.MoveThe = value;
                    OnMoveTheChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _assignCoverArt;
        public bool AssignCoverArt
        {
            get => _appSettings.AssignCoverArt;
            set
            {
                if (_appSettings.AssignCoverArt != value)
                {
                    _appSettings.AssignCoverArt = value;
                    OnAssignCoverArtChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _rollIntoOneDisc;
        public bool RollIntoOneDisc
        {
            get => _appSettings.RollIntoOneDisc;
            set
            {
                if (_appSettings.RollIntoOneDisc != value)
                {
                    _appSettings.RollIntoOneDisc = value;
                    OnRollIntoOneDiscChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _renameFiles;
        public bool RenameFiles
        {
            get => _appSettings.RenameFiles;
            set
            {
                if (_appSettings.RenameFiles != value)
                {
                    _appSettings.RenameFiles = value;
                    OnRenameFilesChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _moveFilesToMusicLibrary;
        public bool MoveFilesToMusicLibrary
        {
            get => _appSettings.MoveFilesToMusicLibrary;
            set
            {
                if (_appSettings.MoveFilesToMusicLibrary != value)
                {
                    _appSettings.MoveFilesToMusicLibrary = value;
                    OnMoveFilesToMusicLibraryChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        //private bool _convertFiles;
        public bool ConvertFiles
        {
            get => _appSettings.ConvertFiles;
            set
            {
                if (_appSettings.ConvertFiles != value)
                {
                    _appSettings.ConvertFiles = value;
                    OnConvertFilesChanged(new ValueEventArgs<bool>(value));
                }
            }
        }

        public string CoverArtFileNameFormat
        {
            get => _appSettings.CoverArtFileNameFormat;
            set
            {
                if (string.Compare(_appSettings.CoverArtFileNameFormat, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.CoverArtFileNameFormat = value;
                    OnCoverArtFileNameFormatChanged(new ValueEventArgs<string>(value));
                }
            }
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
            get => _appSettings.CoverArtExtensions;
            set
            {
                if (string.Compare(_appSettings.CoverArtExtensions, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.CoverArtExtensions = value;
                    OnCoverArtExtensionsChanged(new ValueEventArgs<string>(value));
                }
            }
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
            get => _appSettings.ConverterExtension;
            set
            {
                if (string.Compare(_appSettings.ConverterExtension, value, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    _appSettings.ConverterExtension = value;
                    OnConverterExtensionChanged(new ValueEventArgs<string>(value));
                }
            }
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


        private readonly IFixMusicController _controller;

        private event EventHandler<ValueEventArgs<string>>? _MusicLibraryPathChanged;
        public event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged
        {
            add { _MusicLibraryPathChanged += value; }
            remove { _MusicLibraryPathChanged -= value; }
        }
        protected virtual void OnMusicLibraryPathChanged(ValueEventArgs<string> ea)
        {
            _MusicLibraryPathChanged?.Invoke(this, ea);
        }

        private event EventHandler<ValueEventArgs<string>>? _MusicLibraryPathFormatChanged;
        public event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged
        {
            add { _MusicLibraryPathFormatChanged += value; }
            remove { _MusicLibraryPathFormatChanged -= value; }
        }
        protected virtual void OnMusicLibraryDirectoryFormatChanged(ValueEventArgs<string> ea)
        {
            _MusicLibraryPathFormatChanged?.Invoke(this, ea);
        }

        private event EventHandler<ValueEventArgs<string>>? _SourcePathChanged;
        public event EventHandler<ValueEventArgs<string>> SourcePathChanged
        {
            add { _SourcePathChanged += value; }
            remove { _SourcePathChanged -= value; }
        }
        protected virtual void OnSourcePathChanged(ValueEventArgs<string> ea)
        {
            _SourcePathChanged?.Invoke(this, ea);
        }

        private event EventHandler<ValueEventArgs<string>>? _CoverArtPathChanged;
        public event EventHandler<ValueEventArgs<string>> CoverArtPathChanged
        {
            add { _CoverArtPathChanged += value; }
            remove { _CoverArtPathChanged -= value; }
        }
        protected virtual void OnCoverArtPathChanged(ValueEventArgs<string> ea)
        {
            _CoverArtPathChanged?.Invoke(this, ea);
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

        private event EventHandler<ValueEventArgs<string>>? _ConverterExecutableChanged;
        public event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged
        {
            add { _ConverterExecutableChanged += value; }
            remove { _ConverterExecutableChanged -= value; }
        }
        protected virtual void OnConverterExecutablePathChanged(ValueEventArgs<string> ea)
        {
            _ConverterExecutableChanged?.Invoke(this, ea);
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

        private readonly IAppSettings _appSettings;

        #region Dispose Pattern

        protected virtual void Dispose(bool isExplicit)
        {
            if (_isDisposed)
            {
                return;
            }

            if (isExplicit)
            {
                _controller.ConvertFilesChanged -= _controller_ConvertFilesChanged;
                _controller.AssignCoverArtChanged -= _controller_AssignCoverArtChanged;
                _controller.CoverArtPathChanged -= _controller_CoverArtDirectoryChanged;
                _controller.CoverArtFileNameFormatChanged -= _controller_CoverArtFileNameFormatChanged;
                _controller.CoverArtExtensionsChanged -= _controller_CoverArtExtensionsChanged;
                _controller.ConverterExtensionChanged -= _controller_ConverterExtensionChanged;
                _controller.FileNameFormatChanged -= _controller_FileNameFormatChanged;
                _controller.FileNameFormatVariousArtistsChanged -= _controller_FileNameFormatVariousArtistsChanged;
                _controller.FixedArtistConflictsChanged -= _controller_FixedArtistConflictsChanged;
                _controller.SourcePathChanged -= _controller_SourceDirectoryChanged;
                _controller.MoveFilesToMusicLibraryChanged -= _controller_MoveFilesToMusicLibraryChanged;
                _controller.MoveTheChanged -= _controller_MoveTheChanged;
                _controller.ConverterArgumentsFormatChanged -= _controller_ConverterArgumentsFormatChanged;
                _controller.ConverterExecutablePathChanged -= _controller_ConverterExecutablePathChanged;
                _controller.MusicLibraryPathFormatChanged -= _controller_MusicLibraryDirectoryFormatChanged;
                _controller.RenameFilesChanged -= _controller_RenameFilesChanged;
                _controller.RollIntoOneDiscChanged -= _controller_RollIntoOneDiscChanged;
                _controller.FillInTotalTracksChanged -= _controller_FillInTotalTracksChanged;
            }

            _isDisposed = true;
        }

        public void Dispose() => Dispose(isExplicit: true);

        private bool _isDisposed;

        #endregion
    }
}
