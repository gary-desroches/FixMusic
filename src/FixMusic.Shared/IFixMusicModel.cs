using System;

namespace FixMusic
{
    public interface IFixMusicModel : IDisposable
    {
        bool ConvertFiles { get; set; }
        bool AssignCoverArt { get; set; }
        string CoverArtPath { get; set; }
        string CoverArtFileNameFormat { get; set; }
        string CoverArtExtensions { get; set; }
        string ConverterExtension { get; set; }
        string FileNameFormat { get; set; }
        string SourceFilter { get; set; }
        string FileNameFormatVariousArtists { get; set; }
        bool FixArtistConflicts { get; set; }
        bool FillInTotalTracks { get; set; }
        string SourcePath { get; set; }
        bool MoveFilesToMusicLibrary { get; set; }
        bool MoveThe { get; set; }
        string ConverterArgumentsFormat { get; set; }
        string ConverterExecutablePath { get; set; }
        string MusicLibraryPath { get; set; }
        string MusicLibraryPathFormat { get; set; }
        bool RenameFiles { get; set; }
        bool RollIntoOneDisc { get; set; }

        event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged;
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged;
        event EventHandler<ValueEventArgs<string>> SourcePathChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtPathChanged;
        event EventHandler<ValueEventArgs<string>> FileNameFormatChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtFileNameFormatChanged;
        event EventHandler<ValueEventArgs<string>> CoverArtExtensionsChanged;
        event EventHandler<ValueEventArgs<string>> ConverterExtensionChanged;
        event EventHandler<ValueEventArgs<string>> SourceFilterChanged;
        event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged;
        event EventHandler<ValueEventArgs<string>> ConverterArgumentsFormatChanged;
        event EventHandler<ValueEventArgs<string>> FileNameFormatVariousArtistsChanged;
        event EventHandler<ValueEventArgs<bool>> FixedArtistConflictsChanged;
        event EventHandler<ValueEventArgs<bool>> FillInTotalTracksChanged;
        event EventHandler<ValueEventArgs<bool>> MoveTheChanged;
        event EventHandler<ValueEventArgs<bool>> AssignCoverArtChanged;
        event EventHandler<ValueEventArgs<bool>> RollIntoOneDiscChanged;
        event EventHandler<ValueEventArgs<bool>> RenameFilesChanged;
        event EventHandler<ValueEventArgs<bool>> MoveFilesToMusicLibraryChanged;
        event EventHandler<ValueEventArgs<bool>> ConvertFilesChanged;

        void Start();
    }
}