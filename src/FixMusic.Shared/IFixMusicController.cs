using System;

namespace FixMusic
{
    public interface IFixMusicController
    {
        string MusicLibraryPath { set; }
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathChanged;
        string MusicLibraryPathFormat { set; }
        event EventHandler<ValueEventArgs<string>> MusicLibraryPathFormatChanged;
        string SourcePath { set; }
        event EventHandler<ValueEventArgs<string>> SourcePathChanged;
        string CoverArtPath { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtPathChanged;
        string CoverArtFileNameFormat { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtFileNameFormatChanged;
        string FileNameFormat { set; }
        event EventHandler<ValueEventArgs<string>> FileNameFormatChanged;
        string SourceFilter { set; }
        event EventHandler<ValueEventArgs<string>> SourceFilterChanged;
        string ConverterExecutablePath { set; }
        event EventHandler<ValueEventArgs<string>> ConverterExecutablePathChanged;
        string ConverterArgumentsFormat { set; }
        event EventHandler<ValueEventArgs<string>> ConverterArgumentsFormatChanged;
        string FileNameFormatVariousArtists { set; }
        event EventHandler<ValueEventArgs<string>> FileNameFormatVariousArtistsChanged;
        string CoverArtExtensions { set; }
        event EventHandler<ValueEventArgs<string>> CoverArtExtensionsChanged;
        string ConverterExtension { set; }
        event EventHandler<ValueEventArgs<string>> ConverterExtensionChanged;
        bool FixArtistConflicts { set; }
        event EventHandler<ValueEventArgs<bool>> FixedArtistConflictsChanged;
        bool FillInTotalTracks { set; }
        event EventHandler<ValueEventArgs<bool>> FillInTotalTracksChanged;
        bool MoveThe { set; }
        event EventHandler<ValueEventArgs<bool>> MoveTheChanged;
        bool AssignCoverArt { set; }
        event EventHandler<ValueEventArgs<bool>> AssignCoverArtChanged;
        bool RollIntoOneDisc { set; }
        event EventHandler<ValueEventArgs<bool>> RollIntoOneDiscChanged;
        bool RenameFiles { set; }
        event EventHandler<ValueEventArgs<bool>> RenameFilesChanged;
        bool MoveFilesToMusicLibrary { set; }
        event EventHandler<ValueEventArgs<bool>> MoveFilesToMusicLibraryChanged;
        bool ConvertFiles { set; }
        event EventHandler<ValueEventArgs<bool>> ConvertFilesChanged;
    }
}
