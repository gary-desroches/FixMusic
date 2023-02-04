using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace FixMusic.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm(AppSettings appSettings)
        {
            if (appSettings is null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }

            _appSettings = appSettings;

            _controller = new FixMusicController();
            _model = new FixMusicModel(appSettings, _controller, new WindowsFormsErrorPresenter());

            _model.ConvertFilesChanged += _model_ConvertFilesChanged;
            _model.AssignCoverArtChanged += _model_AssignCoverArtChanged;
            _model.CoverArtPathChanged += _model_CoverArtPathChanged;
            _model.FileNameFormatChanged += _model_FileNameFormatChanged;
            _model.FileNameFormatVariousArtistsChanged += _model_FileNameFormatVariousArtistsChanged;
            _model.FixedArtistConflictsChanged += _model_FixedArtistConflictsChanged;
            _model.SourcePathChanged += _model_SourcePathChanged;
            _model.MoveFilesToMusicLibraryChanged += _model_MoveFilesToMusicLibraryChanged;
            _model.MoveTheChanged += _model_MoveTheChanged;
            _model.ConverterArgumentsFormatChanged += _model_ConverterArgumentsFormatChanged;
            _model.ConverterExecutablePathChanged += _model_ConverterExecutableChanged;
            _model.MusicLibraryPathChanged += _model_MusicLibraryDirectoryChanged;
            _model.MusicLibraryPathFormatChanged += _model_MusicLibraryDirectoryFormatChanged;
            _model.RenameFilesChanged += _model_RenameFilesChanged;
            _model.RollIntoOneDiscChanged += _model_RollIntoOneDiscChanged;
            _model.FillInTotalTracksChanged += _model_FillInTotalTracksChanged;

            InitializeComponent();
        }

        private void _model_FillInTotalTracksChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _fillInTotalTracksCheckBox.Checked = ea.Value;
            }
        }

        private void _model_MusicLibraryDirectoryChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _musicLibraryDirectoryTextBox.Text = ea.Value;
            }
        }

        private void _model_RollIntoOneDiscChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _oneDiscCheckBox.Checked = ea.Value;
            }
        }
        private void _model_RenameFilesChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _renameCheckBox.Checked = ea.Value;
            }
        }
        private void _model_MusicLibraryDirectoryFormatChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _musicLibraryPathFormatTextBox.Text = ea.Value;
            }
        }
        private void _model_ConverterExecutableChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _converterExecutableTextBox.Text = ea.Value;
            }
        }
        private void _model_ConverterArgumentsFormatChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _converterCommandLineTextBox.Text = ea.Value;
            }
        }
        private void _model_MoveTheChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _moveTheCheckBox.Checked = ea.Value;
            }
        }
        private void _model_MoveFilesToMusicLibraryChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _moveToLibraryCheckBox.Checked = ea.Value;
            }
        }
        private void _model_SourcePathChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _sourceDirectoryTextBox.Text = ea.Value;
            }
        }
        private void _model_FixedArtistConflictsChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _artistConflictFixerCheckBox.Checked = ea.Value;
            }
        }
        private void _model_FileNameFormatVariousArtistsChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _fileNameFormatVariousArtistsTextBox.Text = ea.Value;
            }
        }
        private void _model_FileNameFormatChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _fileNameFormatTextBox.Text = ea.Value;
            }
        }
        private void _model_CoverArtPathChanged(object? sender, ValueEventArgs<string> ea)
        {
            if (!_changingController)
            {
                _coverArtTextBox.Text = ea.Value;
            }
        }
        private void _model_AssignCoverArtChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _coverArtCheckBox.Checked = ea.Value;
            }
        }

        private void _model_ConvertFilesChanged(object? sender, ValueEventArgs<bool> ea)
        {
            if (!_changingController)
            {
                _convertCheckBox.Checked = ea.Value;
            }
        }

        private void _startButton_Click(object sender, EventArgs ea)
        {
            _model.Start();
        }

        private readonly IFixMusicController _controller;
        private readonly IFixMusicModel _model;

        private bool _changingController;
        private bool _updating;

        private void _sourceDirectoryTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.SourcePath = _sourceDirectoryTextBox.Text;
        }

        private void _coverArtTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.CoverArtPath = _coverArtTextBox.Text;
        }

        private void _musicLibraryDirectoryTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.MusicLibraryPath = _musicLibraryDirectoryTextBox.Text;
        }

        private void _musicLibraryDirectoryFormatTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.MusicLibraryPathFormat = _musicLibraryPathFormatTextBox.Text;
        }

        private void _converterTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.ConverterExecutablePath = _converterExecutableTextBox.Text;
        }

        private void _converterCommandLineTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);
            _controller.ConverterArgumentsFormat = _converterCommandLineTextBox.Text;
        }

        private void _fileNameFormatTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.FileNameFormat = _fileNameFormatTextBox.Text;
        }

        private void _fileNameFormatVariousArtistsTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.FileNameFormatVariousArtists = _fileNameFormatVariousArtistsTextBox.Text;
        }

        private void SetText(Action<string> setter, string? newText)
        {
            Debug.Assert(setter != null);

            if (!String.IsNullOrEmpty(newText))
            {
                setter(newText);
            }
        }

        private void MainForm_Load(object sender, EventArgs ea)
        {
            _updating = true;
            using var dummy = new ActionOnDispose(() => _updating = false);

            SetText((value) => _sourceDirectoryTextBox.Text = value, _model.SourcePath);
            SetText((value) => _musicLibraryDirectoryTextBox.Text = value, _model.MusicLibraryPath);
            SetText((value) => _musicLibraryPathFormatTextBox.Text = value, _model.MusicLibraryPathFormat);
            SetText((value) => _coverArtTextBox.Text = value, _model.CoverArtPath);
            SetText((value) => _converterExecutableTextBox.Text = value, _model.ConverterExecutablePath);
            SetText((value) => _converterCommandLineTextBox.Text = value, _model.ConverterArgumentsFormat);
            SetText((value) => _fileNameFormatTextBox.Text = value, _model.FileNameFormat);
            SetText((value) => _fileNameFormatVariousArtistsTextBox.Text = value, _model.FileNameFormatVariousArtists);
            SetText((value) => _sourceFilterTextBox.Text = value, _model.SourceFilter);
            SetText((value) => _coverArtFileNameFormatTextBox.Text = value, _model.CoverArtFileNameFormat);
            SetText((value) => _coverArtExtensionsTextBox.Text = value, _model.CoverArtExtensions);
            SetText((value) => _converterExtensionTextBox.Text = value, _model.ConverterExtension);

            _artistConflictFixerCheckBox.Checked = _model.FixArtistConflicts;
            _moveTheCheckBox.Checked = _model.MoveThe;
            _coverArtCheckBox.Checked = _model.AssignCoverArt;
            _oneDiscCheckBox.Checked = _model.RollIntoOneDisc;
            _renameCheckBox.Checked = _model.RenameFiles;
            _moveToLibraryCheckBox.Checked = _model.MoveFilesToMusicLibrary;
            _convertCheckBox.Checked = _model.ConvertFiles;
            _fillInTotalTracksCheckBox.Checked = _model.FillInTotalTracks;
        }

        private void BrowseForFile(TextBox textBox, string title, string filter)
        {
            var folderDialog = new OpenFileDialog()
            {
                Title = title,
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = filter
            };

            if (textBox.Text.Trim().Length > 0)
            {
                folderDialog.InitialDirectory = textBox.Text;
            }

            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = folderDialog.FileName;
            }
        }

        private void BrowseForDirectory(TextBox textBox, string description)
        {
            var folderDialog = new FolderBrowserDialog()
            {
                Description = description
            };

            if (textBox.Text.Trim().Length > 0)
            {
                folderDialog.SelectedPath = textBox.Text;
            }

            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox.Text = folderDialog.SelectedPath;
            }
        }
        private void _musicLibraryDirectoryBrowseButton_Click(object sender, EventArgs ea)
        {
            BrowseForDirectory(_musicLibraryDirectoryTextBox, "Select Music Library Directory");
        }

        private void _sourceDirectoryBrowseButton_Click(object sender, EventArgs ea)
        {
            BrowseForDirectory(_sourceDirectoryTextBox, "Select Input Directory");
        }

        private void _coverArtBrowseButton_Click(object sender, EventArgs ea)
        {
            BrowseForDirectory(_coverArtTextBox, "Select Cover Art Directory");
        }

        private void _converterBrowseButton_Click(object sender, EventArgs ea)
        {
            BrowseForFile(_converterExecutableTextBox, "Converter Executable", "*.exe");
        }

        private void _artistConflictFixerCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.FixArtistConflicts = _artistConflictFixerCheckBox.Checked;
        }

        private void _moveTheCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.MoveThe = _moveTheCheckBox.Checked;
        }

        private void _coverArtCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.AssignCoverArt = _coverArtCheckBox.Checked;
        }

        private void _oneDiscCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.RollIntoOneDisc = _oneDiscCheckBox.Checked;
        }

        private void _renameCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.RenameFiles = _renameCheckBox.Checked;
        }

        private void _moveToLibraryCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.MoveFilesToMusicLibrary = _moveToLibraryCheckBox.Checked;
        }

        private void _convertCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.ConvertFiles = _convertCheckBox.Checked;
        }

        private void _coverArtFileNameFormatTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.CoverArtFileNameFormat = _coverArtFileNameFormatTextBox.Text;
        }

        private void _coverArtExtensionsTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.CoverArtExtensions = _coverArtExtensionsTextBox.Text;
        }

        private void _converterExtensionTextBox_TextChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.ConverterExtension = _converterExtensionTextBox.Text;
        }

        private readonly AppSettings _appSettings;

        private void _fillInTotalTracksCheckBox_CheckedChanged(object sender, EventArgs ea)
        {
            if (_updating)
            {
                return;
            }

            _changingController = true;
            using var dummy = new ActionOnDispose(() => _changingController = false);

            _controller.FillInTotalTracks = _fillInTotalTracksCheckBox.Checked;
        }
    }
}
